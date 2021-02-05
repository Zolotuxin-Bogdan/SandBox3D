using UnityEngine;

namespace Assets.InputSystem
{
    public class ActionKeyBindings : KeyboardBindings
    {

        public KeyBind AttackKey { get; set; } = new KeyBind("Attack", KeyCode.Mouse0);
        public KeyBind DropKey { get; set; } = new KeyBind("Drop item", KeyCode.Q);
        public KeyBind UseKey { get; set; } = new KeyBind("Use", KeyCode.Mouse1);
        public KeyBind CrouchingKey {get; set;} = new KeyBind("Crouching", KeyCode.LeftShift);
        public KeyBind InventoryKey { get; set; } = new KeyBind("Open/Close inventory", KeyCode.E);
        //public KeyBind ChatKey { get; set; } = new KeyBind("Open chat", KeyCode.T);
        public KeyBind ConsoleKey { get; set; } = new KeyBind("Open console", KeyCode.Slash);

        public override KeyBind[] GetBinds()
        {
            return new KeyBind[]{AttackKey, DropKey, UseKey, CrouchingKey};
        }
    }
}
