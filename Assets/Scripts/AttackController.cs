using System;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts
{
    public class AttackController 
    {
        public float delay { get; set; }

        public void DoAction(ActionType action) {
            switch (action)
            {
                case ActionType.Dig:
                    Dig();
                    break;
                case ActionType.Combat:
                    Combat();
                    break;
                case ActionType.Fire:
                    Fire();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

        }

        protected void Dig() {

        }

        protected void Combat() {

        }

        protected void Fire() {

        }
    }
}