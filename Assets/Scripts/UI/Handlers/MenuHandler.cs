using System;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.UI.Handlers
{
    public class MenuHandler : MonoBehaviour
    {
        public GameObject MenuGUI;
        public GameObject SingleplayerMenuGUI;
        public GameObject MultiplayerMenuGUI;
        public GameObject CreateWorldGUI;
        public GameObject LoadWorldGUI;
        public GameObject SettingsCanvas;
        public GameObject Background;

        MenuController menuController;
        SingleplayerMenuController singleplayerMenuController;
        MultiplayerMenuController multiplayerMenuController;
        CreateWorldController createWorldController;
        WorldLoadingController loadWorldController;
        SettingsHandler settingsHandler;
        // Start is called before the first frame update
        void Start()
        {
            ScriptsInitialization();
            HandlersInitialization();

            Cursor.visible = true;
            MenuGUI.SetActive(true);
            Background.SetActive(true);
            SingleplayerMenuGUI.SetActive(false);
            MultiplayerMenuGUI.SetActive(false);
            CreateWorldGUI.SetActive(false);
            LoadWorldGUI.SetActive(false);
        }

        #region Initialization 
        protected void ScriptsInitialization(){
            menuController = MenuGUI.GetComponent<MenuController>();
            singleplayerMenuController = SingleplayerMenuGUI.GetComponent<SingleplayerMenuController>();
            multiplayerMenuController = MultiplayerMenuGUI.GetComponent<MultiplayerMenuController>();
            createWorldController = CreateWorldGUI.GetComponent<CreateWorldController>();
            loadWorldController = LoadWorldGUI.GetComponent<WorldLoadingController>();
            settingsHandler = SettingsCanvas.GetComponent<SettingsHandler>();
        }

        protected void HandlersInitialization(){
            menuController.AddListener(MenuCallbackHandler);
            singleplayerMenuController.AddListener(SingleplayerCallbackHandler);
            multiplayerMenuController.AddListener(MultuplayerCallbackHandler);
            createWorldController.AddListener(CreateWorldCallbackHandler);
            loadWorldController.AddListener(LoadWorldCallbackHandler);
        }
        #endregion

        #region HandlersImplementation

        private void LoadWorldCallbackHandler()
        {
            LoadWorldGUI.SetActive(false);
            MenuGUI.SetActive(false);
        }

        private void CreateWorldCallbackHandler(CreateWorldEvents arg0)
        {
            switch (arg0)
            {
                case CreateWorldEvents.OnCancelClicked:
                    CreateWorldGUI.SetActive(false);
                    SingleplayerMenuGUI.SetActive(true);
                    break;
                case CreateWorldEvents.OnCreateClicked:
                    CreateWorldGUI.SetActive(false);
                    LoadWorldGUI.SetActive(true);
                    loadWorldController.LoadWorld(createWorldController.generationType);
                    Background.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(arg0), arg0, nameof(arg0));
            }
        }

        private void MultuplayerCallbackHandler(MultiplayerMenuEvents arg0)
        {
            switch (arg0)
            {
                case MultiplayerMenuEvents.OnCancelClicked:
                    MultiplayerMenuGUI.SetActive(false);
                    MenuGUI.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(arg0), arg0, nameof(arg0));
            }
        }

        private void SingleplayerCallbackHandler(SingleplayerMenuEvents arg0)
        {
            switch (arg0)
            {
                case SingleplayerMenuEvents.OnCancelClicked:
                    SingleplayerMenuGUI.SetActive(false);
                    MenuGUI.SetActive(true);
                    break; 
                case SingleplayerMenuEvents.OnCreateWorldClicked:
                    SingleplayerMenuGUI.SetActive(false);
                    CreateWorldGUI.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(arg0), arg0, nameof(arg0));
            }
        }

        private void MenuCallbackHandler(MenuEvents arg0)
        {
            switch (arg0)
            {
                case MenuEvents.OnMultiplayerClicked:
                    MenuGUI.SetActive(false);
                    MultiplayerMenuGUI.SetActive(true);
                    break;
                case MenuEvents.OnSettingsClicked:
                    SettingsCanvas.SetActive(true);
                    settingsHandler.Settings.SetActive(true);
                    settingsHandler.Background.SetActive(true);
                    break;
                case MenuEvents.OnSinglePlayerClicked:
                    MenuGUI.SetActive(false);
                    SingleplayerMenuGUI.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(arg0), arg0, nameof(arg0));
            }
        }
        #endregion
    }
    
}
