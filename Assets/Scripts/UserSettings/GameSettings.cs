using System;
using System.ComponentModel;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.UserSettings
{
    public class GameSettings
    {
        /// <summary>
        /// game screen resolution
        /// </summary>
        public Vector2 screenResolution
        {
            get => screenResolution;
            set
            {
                switch (value.x)
                {
                    case 640 when value.y.Equals(360):
                    case 800 when value.y.Equals(600):
                    case 1024 when value.y.Equals(768):
                    case 1360 when value.y.Equals(768):
                    case 1280 when value.y.Equals(800):
                    case 1440 when value.y.Equals(900):
                    case 1600 when value.y.Equals(900):
                    case 1920 when value.y.Equals(1080):
                        screenResolution = value;
                        break;
                }
                if (value.x.Equals(1920) && value.y.Equals(1200))
                {
                    screenResolution = value;
                }
            }
        }

        /// <summary>
        /// game background music
        /// </summary>
        public int musicVolume
        {
            get => musicVolume;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                musicVolume = value;
            }
        }

        /// <summary>
        /// ambient sound volume
        /// </summary>
        public int sfxVolume
        {
            get => sfxVolume;
            set
            {
                if (value < 0 ) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                sfxVolume = value;
            }
        }

        /// <summary>
        /// game interface language
        /// </summary>
        public Languages language
        {
            get => language; 
            set
            {
                if (!Enum.IsDefined(typeof(Languages), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(Languages));
                language = value;
            }
        }

        /// <summary>
        /// in-game mouse sensitivity, set for horizontal and vertical axis
        /// </summary>
        public float mouseSensitivity
        {
            get => mouseSensitivity;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 200) throw new ArgumentOutOfRangeException(nameof(value));
                mouseSensitivity = value;
            }
        }

        /// <summary>
        /// contain difficulty for current game 
        /// </summary>
        public Difficulty difficulty
        {
            get => difficulty;
            set
            {
                if (!Enum.IsDefined(typeof(Difficulty), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(Difficulty));
                difficulty = value;
            }
        }
        /// <summary>
        /// Enable/Disable iverting mouse movement
        /// </summary>
        public bool invertMouse { get; set; }
        /// <summary>
        /// Enable/Disable touchscreen 
        /// </summary>
        public bool touchscreenMode { get; set; }
        /// <summary>
        /// player line of sight
        /// </summary>
        public int fov
        {
            get => fov;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                fov = value;
            }
        }

        public GraphicSettings graphic;

        public MultiplayerSettings multiplayer; 
    }
}