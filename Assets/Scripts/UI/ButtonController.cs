using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ButtonController: MonoBehaviour
    {
        private Button _button;
        //Unity Start Message
        void Start()
        {
            _button.onClick.AddListener(OpenSomeWindow);
        }

        void OpenSomeWindow() { }
    }
}