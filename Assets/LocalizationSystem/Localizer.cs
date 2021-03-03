using UnityEngine;

namespace Assets.LocalizationSystem
{
    public class Localizer
    {
        public static void RegisterController<TController>(TController controller) where TController : ILocalization
        {
            controller.SetLocalization();
        }
    }
}