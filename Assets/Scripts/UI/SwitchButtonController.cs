using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SwitchButtonController: MonoBehaviour
    {
        private Button _button;
        private Text _text;
        //Unity Start Message
        void Start()
        {
            _button.onClick.AddListener(UpdateText);
        }

        void UpdateText()
        {
            
        }
    }
}