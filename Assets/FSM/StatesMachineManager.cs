using Assets.Scripts.Enums;
using Assets.Scripts.States;
using UnityEngine;
    
namespace Assets.FSM
{
    public class StatesMachineManager : MonoBehaviour {

        public static StatesMachineManager instance;

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