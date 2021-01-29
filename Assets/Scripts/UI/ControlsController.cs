using System;
using System.Collections;
using System.Collections.Generic;
using Assets.InputSystem;
using Assets.Scripts.UserSettings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ControlsController: MonoBehaviour
    {
        public GameObject Item;
        public ScrollRect ControlsList;
        public Button ResetAllKeys;
        public Button Done;

        List<KeyboardBindings> keysCollection;
        bool waitingKey;
        KeyBind selectedKey;
        TextMeshProUGUI labelOfSelectedKey;

        private void Start() {
            keysCollection = new List<KeyboardBindings>();
            Done.onClick.AddListener(Submit);
            ResetAllKeys.onClick.AddListener(ResetKeys);
            keysCollection.Add(new MovementKeyBindings());
            keysCollection.Add(new ActionKeyBindings());
            ShowControls();
        }

        private void ResetKeys()
        {
            foreach (var child in keysCollection)
            {
                var keyBinds = child.GetBinds();
                foreach (var keyBind in keyBinds)
                {
                    keyBind.ResetKey();
                }   
            }
        }

        private void ShowControls()
        {
            foreach (var child in keysCollection)
            {
                var keyBinds = child.GetBinds();
                foreach (var keyBind in keyBinds)
                {
                    CreateControlsItem(keyBind, ControlsList.content.transform);
                }
            }
        }

        private void CreateControlsItem(KeyBind keyBind, Transform parent)
        {
            var newItem = Instantiate(Item);
            var labels = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            labels[0].text = keyBind.description;
            labels[1].text = keyBind.keyCode.ToString();
            var buttons = newItem.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(
                () => {
                    labels[1].text = "Enter Key";
                    labels[1].fontStyle = FontStyles.Bold;
                    labelOfSelectedKey = labels[1];
                    selectedKey = keyBind;
                    waitingKey = true;
                }
            );
            buttons[1].onClick.AddListener(
                () => {
                    keyBind.ResetKey();
                    labels[1].text = keyBind.keyCode.ToString();
                }
            );
            newItem.SetActive(true);
            newItem.transform.SetParent(parent);
        }

        private void OnGUI() {
            if (waitingKey){
                if (Event.current.isKey)
                {
                    selectedKey.keyCode = Event.current.keyCode;
                    labelOfSelectedKey.text = selectedKey.keyCode.ToString();
                    labelOfSelectedKey.fontStyle = FontStyles.Normal;
                    waitingKey = false;
                }
            }
        }
        
        private void Submit()
        {
            action.Invoke();
        }

        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}