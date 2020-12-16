using UnityEngine;

namespace Assets.Scripts.UserSettings
{
    public struct KeyBind
    {
        public string description;
        public KeyCode keyCode;
        readonly KeyCode originalKeyCode;
        public KeyBind(string description, KeyCode keyCode)
        {
            this.description = description;
            this.keyCode = originalKeyCode = keyCode;
        }

        public void ResetKey()
        {
            keyCode = originalKeyCode;
        }
    }
}