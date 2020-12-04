using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.UserSettings
{
    public class GameSettings
    {
        /// <summary>
        /// game screen resolution
        /// </summary>
        public Vector2 ScreenResolution { get; set; }
        /// <summary>
        /// should the game be in full screen mode
        /// </summary>
        public bool IsFullscreen { get; set; }
        public Quality ShadowQuality { get; set; }
        /// <summary>
        /// distance to draw shadows
        /// </summary>
        public Distance ShadowDistance { get; set; }
        public Quality GraphicQuality { get; set; }
        /// <summary>
        /// game background music
        /// </summary>
        public int MusicVolume { get; set; }
        /// <summary>
        /// ambient sound volume
        /// </summary>
        public int SfxVolume { get; set; }
        /// <summary>
        /// game interface language
        /// </summary>
        public Languages Language { get; set; }
        /// <summary>
        /// in-game mouse sensitivity, set for horizontal and vertical axis
        /// </summary>
        public float MouseSensitivity { get; set; }
    }
}