using System.Collections.Generic;
using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Tools_and_Managers
{
    public class LocalizationManager : MonoBehaviour
    {
        private void Start()
        {
            UpdateLocalization();
        }

        public static void UpdateLocalization()
        {
            Localizer.RegisterController(MenuController.Instance);
        }
    }
}