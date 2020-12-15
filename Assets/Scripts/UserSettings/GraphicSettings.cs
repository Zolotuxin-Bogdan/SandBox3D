using System;
using System.ComponentModel;
using Assets.Scripts.Enums;

namespace Assets.Scripts.UserSettings
{
    public class GraphicSettings
    {
        /// <summary>
        /// game graphic quality
        /// </summary>
        public Quality quality
        {
            get => _quality;
            set
            {
                if (!Enum.IsDefined(typeof(Quality), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(Quality));
                _quality = value;
            }
        }
        /// <summary>
        /// should the game be in full screen mode
        /// </summary>
        public bool fullscreen { get; set; }
        /// <summary>
        /// brightness level of game objects
        /// </summary>
        public float brightness
        {
            get => _brightness;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _brightness = value;
            }
        }

        /// <summary>
        /// world draw distance
        /// </summary>
        public int renderDistance
        {
            get => _renderDistance;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 16) throw new ArgumentOutOfRangeException(nameof(value));
                _renderDistance = value;
            }
        }

        /// <summary>
        /// Enable/Disable clouds
        /// </summary>
        public bool clouds { get; set; }
        /// <summary>
        /// Enable/Disable view bobbing
        /// </summary>
        public bool viewBobbing { get; set; }
        /// <summary>
        /// Enable/Disable smooth lighting
        /// </summary>
        public bool smoothLighting { get; set; }
        /// <summary>
        /// Enable/Disable vertical sync
        /// </summary>
        public bool useVSync { get; set; }
        /// <summary>
        /// GUI size relative to original
        /// </summary>
        public int guiScale
        {
            get => _guiScale;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 6) throw new ArgumentOutOfRangeException(nameof(value));
                _guiScale = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float mipmap
        {
            get => _mipmap;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 4) throw new ArgumentOutOfRangeException(nameof(value));
                _mipmap = value;
            }
        }

        /// <summary>
        /// max count of frames per second (121 - mean that frames count is unlimited)
        /// </summary>
        public int maxFramerate
        {
            get => _maxFramerate;
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 121) throw new ArgumentOutOfRangeException(nameof(value));
                _maxFramerate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BiomeBlend biomeBlend
        {
            get => _biomeBlend;
            set
            {
                if (!Enum.IsDefined(typeof(BiomeBlend), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(BiomeBlend));
                _biomeBlend = value;
            }
        }

        /// <summary>
        /// Enable/Disable shadows entity
        /// </summary>
        public bool entityShadows { get; set;}

        Quality _quality;
        float _brightness;
        int _renderDistance;
        int _guiScale;
        float _mipmap;
        int _maxFramerate;
        BiomeBlend _biomeBlend;
    }
}