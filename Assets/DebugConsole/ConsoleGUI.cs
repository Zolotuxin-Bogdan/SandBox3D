using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

namespace Assets.DebugConsole
{
    public class ConsoleGUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI input;
        [SerializeField] GameObject uGUI;
        [SerializeField] ScrollRect chat;
        private void Awake() {

        }

        public void OpenConsole()
        {
            throw new NotImplementedException();
        }

        public void CloseConsole()
        {
            throw new NotImplementedException();
        }

        public event Action<string> OnSubmitCommand;
    }
}

