using System;
using System.ComponentModel;
using Assets.Scripts.Enums;

namespace Assets.Scripts.UserSettings
{
    public class MultiplayerSettings
    {
        public ChatDisplayStates displayState
        {
            get => displayState;
            set
            {
                if (!Enum.IsDefined(typeof(ChatDisplayStates), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(ChatDisplayStates));
                displayState = value;
            }
        }

        public bool allowWebLinks { get; set; }
        public bool allowPromptOnLinks { get; set; }
        public bool allowColorsInChat { get; set; }
        public bool allowCape { get; set; }
        public float scale
        {
            get => scale;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                scale = value;
            }
        }

        public float opacity
        {
            get => opacity;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                opacity = value;
            }
        }

        public float unfocusedHeight
        {
            get => unfocusedHeight;
            set
            {
                if (value < 20) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                unfocusedHeight = value;
            }
        }

        public float focusedHeight
        {
            get => focusedHeight;
            set
            {
                if (value < 20) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 180) throw new ArgumentOutOfRangeException(nameof(value));
                focusedHeight = value;
            }
        }

        public float width
        {
            get => width;
            set
            {
                if (value < 40) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > 320) throw new ArgumentOutOfRangeException(nameof(value));
                width = value;
            }
        }
    }
}