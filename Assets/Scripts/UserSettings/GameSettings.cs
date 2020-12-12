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
        /// <summary>
        /// distance to draw shadows
        /// </summary>
        public Distance ShadowDistance { get; set; }
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
        /// <summary>
        /// contain difficulty for current game 
        /// </summary>
        public Difficulty Difficulty { get; set; }
        /// <summary>
        /// Enable/Disable iverting mouse movement
        /// </summary>
        public FlagState InvertMouse { get; set; }
        /// <summary>
        /// Enable/Disable touchscreen 
        /// </summary>
        public FlagState TouchscreenMode { get; set; }
        /// <summary>
        /// player line of sight
        /// </summary>
        public int FOV { get; set; }
        /// <summary>
        /// game shadows quality
        /// </summary>
        public Quality Shadows { get; set; }
        /// <summary>
        /// game graphic quality
        /// </summary>
        public Quality Graphic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MipmapLevels Mipmap{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Brightness Brightness { get; set; }
        /// <summary>
        /// max count of frames per second (121 - mean that frames count is unlimited)
        /// </summary>
        public int MaxFramerate { get; set; }
        /// <summary>
        /// world draw distance
        /// </summary>
        public int RenderDistance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BiomeBlend BiomeBlend { get; set; }
        /// <summary>
        /// Enable/Disable shadows entity
        /// </summary>
        public bool EntityShadows { get; set;}
        /// <summary>
        /// Enable/Disable clouds
        /// </summary>
        public bool Clouds { get; set; }
        /// <summary>
        /// Enable/Disable view bobbing
        /// </summary>
        public bool ViewBobbing { get; set; }
        /// <summary>
        /// Enable/Disable smooth lighting
        /// </summary>
        public bool SmoothLighting { get; set; }
        /// <summary>
        /// Enable/Disable vertical sync
        /// </summary>
        public bool UseVSync { get; set; }
        /// <summary>
        /// GUI size relative to original
        /// </summary>
        public int GUIScale { get; set; }
    }
}