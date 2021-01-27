using UnityEngine;

namespace Assets.Scripts
{
    public class AttackController 
    {
        public void DoAction(string actionType) {
            if (actionType.ToLower() == "dig")
                Dig();
            if (actionType.ToLower() == "combat")
                Combat();
            if (actionType.ToLower() == "fire")
                Fire();

        }

        protected void Dig() {

        }

        protected void Combat() {

        }

        protected void Fire() {

        }
    }
}