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

        public bool allowWebLinks { get; set; } = true;
        public bool allowPromptOnLinks { get; set; } = true;
        public bool allowColorsInChat { get; set; } = true;
        public bool allowCape { get; set; } = true;
        public int scale
        {
            get => _scale;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _scale = value;
            }
        }

        public int opacity
        {
            get => _opacity;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _opacity = value;
            }
        }

        public int unfocusedHeight
        {
            get => _unfocusedHeight;
            set
            {
                if (value < 20) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                _unfocusedHeight = value;
            }
        }

        public int focusedHeight
        {
            get => _focusedHeight;
            set
            {
                if (value < 20) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                _focusedHeight = value;
            }
        }

        public int width
        {
            get => _width;
            set
            {
                if (value < 40) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 320) throw new ArgumentOutOfRangeException(nameof(value));
                _width = value;
            }
        }
        ChatDisplayStates _displayState = ChatDisplayStates.Shown;
        int _scale = 100;
        int _opacity = 100;
        int _unfocusedHeight = 100;
        int _focusedHeight = 100;
        int _width = 320;
    }
}