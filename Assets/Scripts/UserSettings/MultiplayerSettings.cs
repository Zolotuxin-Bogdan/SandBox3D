using System;
using System.ComponentModel;
using Assets.Scripts.Enums;

namespace Assets.Scripts.UserSettings
{
    public class MultiplayerSettings
    {
        public ChatDisplayStates displayState
        {
            get => _displayState;
            set
            {
                if (!Enum.IsDefined(typeof(ChatDisplayStates), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(ChatDisplayStates));
                _displayState = value;
            }
        }

        public bool allowWebLinks { get; set; }
        public bool allowPromptOnLinks { get; set; }
        public bool allowColorsInChat { get; set; }
        public bool allowCape { get; set; }
        public float scale
        {
            get => _scale;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _scale = value;
            }
        }

        public float opacity
        {
            get => _opacity;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _opacity = value;
            }
        }

        public float unfocusedHeight
        {
            get => _unfocusedHeight;
            set
            {
                if (value < 20) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                _unfocusedHeight = value;
            }
        }

        public float focusedHeight
        {
            get => _focusedHeight;
            set
            {
                if (value < 20) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                _focusedHeight = value;
            }
        }

        public float width
        {
            get => _width;
            set
            {
                if (value < 40) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 320) throw new ArgumentOutOfRangeException(nameof(value));
                _width = value;
            }
        }
        ChatDisplayStates _displayState;
        float _scale;
        float _opacity;
        float _unfocusedHeight;
        float _focusedHeight;
        float _width;
    }
}