using System;
using System.Linq;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Console
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

            uGUI.GetComponent<RectTransform>().sizeDelta = new Vector2(ChatWidth, ChatHeight * 2f);
            input.GetComponent<RectTransform>().sizeDelta = new Vector2(MessageWidth, MessageHeight);
            output.GetComponent<RectTransform>().sizeDelta = new Vector2(ChatWidth, ChatHeight + MessageHeight * 2f);
            output.content.GetComponent<RectTransform>().sizeDelta = new Vector2(ChatWidth, ChatHeight);

            input.onSubmit.AddListener(AddMessage);
            uGUI.SetActive(false);
        }

        public void OpenConsole()
        {
            uGUI.SetActive(true);
            Cursor.visible = true;
            input.enabled = true;
            input.Select();
        }

        public void CloseConsole()
        {
            Cursor.visible = false;
            input.text = string.Empty;
            input.enabled = false;
            uGUI.SetActive(false);
        }


        public void AddMessage(string message)
        {
            if (message.Length == 0) return;
            if (message[0].Equals('/'))
            {
                string command = new string(message.Skip(1).ToArray());
                OnSubmitCommand?.Invoke(command);
                var formattedText = this.message.Split('\n');
                foreach (var textLine in formattedText)
                {
                    print(textLine.Length);
                    print(ChatWidth / 12);
                    var msg = new GameObject("Message");
                    msg.AddComponent<RectTransform>();

                    var font = msg.AddComponent<TextMeshProUGUI>(); 
                    font.fontSize = 12f;
                    font.text = textLine;
                    msg.transform.SetParent(output.content.transform);
                    SnapTo(msg.GetComponent<RectTransform>());
                }
            }
            else
            {
                var msg = new GameObject("Message");
                msg.AddComponent<RectTransform>();

                var font = msg.AddComponent<TextMeshProUGUI>();
                font.fontSize = 12f; 
                font.text = $"[{Nickname}]: {message}";
                msg.transform.SetParent(output.content.transform);
                SnapTo(msg.GetComponent<RectTransform>());
            }
            input.text = "";
        }

        public void SnapTo(RectTransform target)
        {
            Canvas.ForceUpdateCanvases();

            output.GetComponent<RectTransform>().anchoredPosition =
                (Vector2) output.transform.InverseTransformPoint(output.GetComponent<RectTransform>().position)
                - (Vector2) output.transform.InverseTransformPoint(target.position);
        }


        public void Log(string message)
        {
            this.message = message;
        }

        public event Action<string> OnSubmitCommand;
    }
}

