using Assets.Scripts.UserSettings;
using UnityEngine;

public class ActionKeyBindings : KeyboardBindings
{

    public KeyBind AttackKey { get; set; } = new KeyBind("Attack", KeyCode.Mouse0);
    public KeyBind DropKey { get; set; } = new KeyBind("Drop item", KeyCode.Q);
    public KeyBind UseKey { get; set; } = new KeyBind("Use", KeyCode.Mouse1);
    public KeyBind CrouchingKey {get; set;} = new KeyBind("Crouching", KeyCode.LeftShift);

    public override KeyBind[] GetBinds()
    {
        return new KeyBind[]{AttackKey, DropKey, UseKey, CrouchingKey};
    }
}
