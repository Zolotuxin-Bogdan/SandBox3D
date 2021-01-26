using Assets.FSM;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class IdleState: State
    {
        private Animator _animator;

        public IdleState()
        {
            _animator = StatesMachineManager.instance.Player.GetComponent<Animator>();
        }
        public override void Start()
        {
            _animator.Play(StatesMachineManager.instance.IDLE_ANIMATION);
        }

        public override void Close()
        {
            //throw new System.NotImplementedException();
        }
    }
}