using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Assets.Scripts;
using TMPro;
using UnityEngine.UI;

namespace Assets.DebugConsole
{
    public class ConsoleGUI : MonoBehaviour
    {
        [SerializeField] TMP_InputField input;
        [SerializeField] GameObject uGUI;
        [SerializeField] ScrollRect output;

        public float ChatWidth { get; private set; } 
        public float ChatHeight { get; private set; }
        public float MessageWidth { get; private set; }
        public float MessageHeight { get; private set; }
        public string Nickname = "Player";

        protected string message;
        private void Start()
        {
            ChatWidth = SettingsManager.Instance.GetSettings().multiplayer.width;
            ChatHeight = SettingsManager.Instance.GetSettings().multiplayer.focusedHeight;
            MessageWidth = SettingsManager.Instance.GetSettings().multiplayer.width; 
            MessageHeight = SettingsManager.Instance.GetSettings().multiplayer.unfocusedHeight / 3f;
            
            Debug.Log($"ch:{ChatHeight};cw:{ChatWidth};mw{MessageWidth};mh:{MessageHeight}");
            uGUI.GetComponent<RectTransform>().sizeDelta = new Vector2(ChatWidth, ChatHeight * 2f);
            input.GetComponent<RectTransform>().sizeDelta = new Vector2(MessageWidth, MessageHeight);
            output.GetComponent<RectTransform>().sizeDelta = new Vector2(ChatWidth, ChatHeight + MessageHeight * 2f);
            output.content.GetComponent<RectTransform>().sizeDelta = new Vector2(ChatWidth, ChatHeight);

            input.onSubmit.AddListener(AddMessage);
            uGUI.SetActive(false);
        }

        public void OpenConsole()
        {
            Cursor.visible = true;
            uGUI.SetActive(true);
            input.enabled = true;
            input.Select();
        }

        public void CloseConsole()
        {
            uGUI.SetActive(false);
            Cursor.visible = false;
            input.text = string.Empty;
            input.enabled = false;
        }


        public void AddMessage(string message)
        {
            if (message.Length == 0) return;
            if (message[0].Equals('/'))
            {
                string command = new string(message.Skip(1).ToArray());
                OnSubmitCommand?.Invoke(command);
                var formattedText = this.message.Split('\n');
                foreach (var str in formattedText)
                {
                    var msg = new GameObject("Message");
                    msg.AddComponent<RectTransform>();

                    var font = msg.AddComponent<TextMeshProUGUI>(); 
                    font.fontSize = 16f;
                    font.text = str;
                    msg.transform.SetParent(output.content.transform);
                }
            }
            else
            {
                var msg = new GameObject("Message");
                msg.AddComponent<RectTransform>();

                var font = msg.AddComponent<TextMeshProUGUI>();
                font.fontSize = 16f; 
                font.text = $"[{Nickname}]: {message}";
                msg.transform.SetParent(output.content.transform);
            }
        }

        private static void ShowSingleMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            Debug.Log(message);
            this.message = message;
        }

        public event Action<string> OnSubmitCommand;
    }
}

