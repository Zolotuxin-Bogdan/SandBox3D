using Assets.FSM;
using Assets.Scripts.Enums;
using Assets.Scripts.States;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerStatesManager : MonoBehaviour {

        public static PlayerStatesManager instance;

        // Animation States
        public readonly string IDLE_ANIMATION = "STEVE_IDLE_ANIMATION";
        public readonly string WALK_ANIMATION = "STEVE_WALK_ANIMATION";
        public readonly string RUN_ANIMATION = "STEVE_RUN_ANIMATION";

        public GameObject Player;

        StatesMachine statesMachine;
        private void Awake() {
            instance = this;
            statesMachine = new StatesMachine(new IdleState());
            statesMachine.StartState();
        } 

        public void SwitchState(CharacterStates state) {
            statesMachine.CloseState();
            switch (state)
            {
                case CharacterStates.Run:
                    statesMachine.SwitchTo(new RunningState());
                    break;
                case CharacterStates.Walk:
                    statesMachine.SwitchTo(new WalkingState());
                    break;
                case CharacterStates.Idle:
                    statesMachine.SwitchTo(new IdleState());
                    break;
                case CharacterStates.Attack:
                    statesMachine.SwitchTo(new AttackState());
                    break;
                case CharacterStates.Die:
                    statesMachine.SwitchTo(new DyingState());
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(state), null, nameof(state));
            }
            statesMachine.StartState();
        }
    }
}