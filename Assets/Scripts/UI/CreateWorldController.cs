using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using Assets.WorldGeneration;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WorldGenerationType = Assets.Scripts.Enums.WorldGenerationType;

namespace Assets.Scripts.UI
{
    public class CreateWorldController : MonoBehaviour, ILocalization
    {
        public Button Cancel;
        public Button Create;
        public Button WorldType;
        public Button CreateWorldLabel;
        public TextMeshProUGUI WorldName;
        public TMP_InputField InputField;
        public bool Recreate = false;
        public string ParentWorldName;
        public WorldGenerationType GenerationType;

        public static CreateWorldController Instance;
        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            GenerationType = WorldGenerationType.Perlin;

            Cancel.onClick.AddListener(CancelCallback);
            Create.onClick.AddListener(CreateCallback);
            WorldType.onClick.AddListener(WorldTypeCallback);
            InputField.onValueChanged.AddListener(InputFieldCallback);
            WorldType.GetComponentInChildren<TextMeshProUGUI>().text = "World Type: Primitive Realistic";
            if (Recreate)
            {
                InputField.text = $"Copy of {ParentWorldName}";    
            }
        }

        private void WorldTypeCallback()
        {
            var wType = WorldType.GetComponentInChildren<TextMeshProUGUI>().text;
            if (wType.Contains("Primitive Realistic"))
            {
                wType = "World Type: Flat";
                GenerationType = WorldGenerationType.Flat;
            }
            else if (wType.Contains("Flat"))
            {
                wType = "World Type: Primitive Realistic";
                GenerationType = WorldGenerationType.Perlin;
            }
            WorldType.GetComponentInChildren<TextMeshProUGUI>().text = wType;
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
                WorldName.text = "Will be saved in: World";
            else
                WorldName.text = "Will be saved in: " + arg0;
        }

        protected UnityAction<CreateWorldEvents> action;

        public CreateWorldController(Button create)
        {
            Create = create;
        }

        public void AddListener(UnityAction<CreateWorldEvents> action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            throw new System.NotImplementedException();
        }
    }
}