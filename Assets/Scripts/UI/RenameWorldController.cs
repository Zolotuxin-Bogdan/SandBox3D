using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class RenameWorldController : MonoBehaviour, ILocalization
    {
        public Button renameWorld;
        public Button cancel;
        public TMP_InputField worldName;

        public string sourceWorldName;

        public static RenameWorldController Instance;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            renameWorld.onClick.AddListener(RenameWorldCallback);
            cancel.onClick.AddListener(CancelCallback);
            worldName.text = sourceWorldName;
        }

        private void CancelCallback()
        {
            action.Invoke();
        }

        private void RenameWorldCallback()
        {
            System.IO.File.Move(
                Application.dataPath + "\\saves\\" + sourceWorldName,
                Application.dataPath + "\\saves\\" + worldName.text
            );
        }

        protected UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            cancel.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.cancel.ToString());
            /*renameWorld.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.rename_world.ToString());*/
            worldName.GetComponentInChildren<TextMeshProUGUI>().text =
                LocalizationSystem.LocalizationSystem.GetLocalizedValue(LocalizationKeys.world_name.ToString());
        }
    }
}
