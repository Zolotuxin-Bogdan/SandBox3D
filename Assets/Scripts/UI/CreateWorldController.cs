using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class CreateWorldController : MonoBehaviour
    {
        public Button cancel;
        public Button create;
        public Button worldType;
        public TextMeshProUGUI worldName;
        public TMP_InputField inputField;
        public bool isRecreate = false;
        public string parentWorldName;
        void Start()
        {
            cancel.onClick.AddListener(CancelCallback);
            create.onClick.AddListener(CreateCallback);
            worldType.onClick.AddListener(WorldTypeCallback);
            inputField.onValueChanged.AddListener(InputFieldCallback);
            if (isRecreate)
            {
                inputField.text = $"Copy of {parentWorldName}";    
            }
        }

        private void WorldTypeCallback()
        {
            var wType = worldType.GetComponentInChildren<TextMeshProUGUI>().text;
        }

        private void CancelCallback()
        {
            action.Invoke(CreateWorldEvents.OnCancelClicked); 
        }

        private void CreateCallback()
        {
            action.Invoke(CreateWorldEvents.OnCreateClicked);
        }

        private void InputFieldCallback(string arg0)
        {
            if (arg0 == "")
                worldName.text = "Will be saved in: World";
            else
                worldName.text = "Will be saved in: " + arg0;
        }

        protected UnityAction<CreateWorldEvents> action;
        public void AddListener(UnityAction<CreateWorldEvents> action)
        {
            this.action = action;
        }
    }
}