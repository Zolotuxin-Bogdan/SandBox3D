using UnityEngine;

namespace Assets.Scripts.UserSettings
{
    public class MovementKeyBindings: KeyboardBindings
    {
        public KeyBind KeyRight { get; set; } = new KeyBind("Move Right", KeyCode.D);
        public KeyBind KeyLeft { get; set; } = new KeyBind("Move Left", KeyCode.A);
        public KeyBind KeyForward { get; set; } = new KeyBind("MoveForward", KeyCode.W);
        public KeyBind KeyBack { get; set; } = new KeyBind("Move Back", KeyCode.S);
        public KeyBind KeyJump { get; set; } = new KeyBind("Jump", KeyCode.Space);

        public override KeyBind[] GetBinds()
        {
            return new KeyBind[]{KeyRight, KeyLeft, KeyForward, KeyBack, KeyJump};
        }
    }
}