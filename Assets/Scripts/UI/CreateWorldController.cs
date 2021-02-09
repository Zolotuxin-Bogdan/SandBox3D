using Assets.Scripts.Enums;
using Assets.WorldGeneration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WorldGenerationType = Assets.Scripts.Enums.WorldGenerationType;

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
        protected WorldGenerationType generationType;
        void Start()
        {
            generationType = WorldGenerationType.Perlin;

            cancel.onClick.AddListener(CancelCallback);
            create.onClick.AddListener(CreateCallback);
            worldType.onClick.AddListener(WorldTypeCallback);
            inputField.onValueChanged.AddListener(InputFieldCallback);
            worldType.GetComponentInChildren<TextMeshProUGUI>().text = "World Type: Primitive Realistic";
            if (isRecreate)
            {
                inputField.text = $"Copy of {parentWorldName}";    
            }
        }

        private void WorldTypeCallback()
        {
            var wType = worldType.GetComponentInChildren<TextMeshProUGUI>().text;
            if (wType.Contains("Primitive Realistic"))
            {
                wType = "World Type: Flat";
                generationType = WorldGenerationType.Flat;
            }
            else if (wType.Contains("Flat"))
            {
                wType = "World Type: Primitive Realistic";
                generationType = WorldGenerationType.Perlin;
            }
            worldType.GetComponentInChildren<TextMeshProUGUI>().text = wType;
        }

        private void CancelCallback()
        {
            action.Invoke(CreateWorldEvents.OnCancelClicked); 
        }

        private void CreateCallback()
        {
            //action.Invoke(CreateWorldEvents.OnCreateClicked);
            BlockInstanceManager.Instance.GenerateWorld(WorldGeneratorFactory.GetWorldGenerator(generationType));
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