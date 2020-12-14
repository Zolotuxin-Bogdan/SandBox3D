using System;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.UserSettings
{
    public class GameSettings
    {
        /// <summary>
        /// game screen resolution
        /// </summary>
        [Obsolete("Property ScreenResolution is deprecated and will be updated soon.", false)]
        public Vector2 ScreenResolution { get; set; }
        /// <summary>
        /// distance to draw shadows
        /// </summary>
        [Obsolete("Property ShadowDistance is deprecated and will be removed soon.", false)]
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
        /// 
        /// </summary>
        [Obsolete("Property Mipmap is deprecated and will be removed soon.", false)]
        public MipmapLevels Mipmap{ get; set; }
        /// <summary>
        /// max count of frames per second (121 - mean that frames count is unlimited)
        /// </summary>
        [Obsolete("Property MaxFramerate is deprecated and will be removed soon.", false)]
        public int MaxFramerate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Obsolete("Property BiomeBlend is deprecated and will be removed soon.", false)]
        public BiomeBlend BiomeBlend { get; set; }
        /// <summary>
        /// Enable/Disable shadows entity
        /// </summary>
        [Obsolete("Property EntityShadows is deprecated and will be removed soon.", false)]
        public bool EntityShadows { get; set;}

        // VIDEO(GRAPHIC) SETTINGS
        
        /// <summary>
        /// game graphic quality
        /// </summary>
        public Quality graphic_quality { get; set; }
        /// <summary>
        /// should the game be in full screen mode
        /// </summary>
        public bool graphic_fullscreen { get; set; }
        /// <summary>
        /// brightness level of game objects
        /// </summary>
        public Brightness graphic_brightness { get; set; }
        /// <summary>
        /// world draw distance
        /// </summary>
        public int graphic_renderDistance { get; set; }
        /// <summary>
        /// Enable/Disable clouds
        /// </summary>
        public bool graphic_clouds { get; set; }
        /// <summary>
        /// Enable/Disable view bobbing
        /// </summary>
        public bool graphic_viewBobbing { get; set; }
        /// <summary>
        /// Enable/Disable smooth lighting
        /// </summary>
        public bool graphic_smoothLighting { get; set; }
        /// <summary>
        /// Enable/Disable vertical sync
        /// </summary>
        public bool graphic_useVSync { get; set; }
        /// <summary>
        /// GUI size relative to original
        /// </summary>
        public int graphic_guiScale { get; set; }

        // CHAT AND MULTIPLAYER SETTINGS

        public ChatDisplayStates chat_displayState { get; set; }
        public bool chat_allowWebLinks { get; set; }
        public bool chat_allowPromptOnLinks { get; set; }
        public bool chat_allowColorsInChat { get; set; }
        public bool multiplayer_allowCape { get; set; }
        public float chat_scale { get; set; }
        public float chat_opacity { get; set; }
        public float chat_unfocusedHeight { get; set; }
        public float chat_focusedHeight { get; set; }
        public float chat_width { get; set; }
    }
}