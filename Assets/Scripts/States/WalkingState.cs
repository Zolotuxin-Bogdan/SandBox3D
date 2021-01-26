using Assets.FSM;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class WalkingState: State
    {
        private Animator _animator;
        public override void Start()
        {
            _animator = StatesMachineManager.instance.Player.GetComponent<Animator>();
            _animator.Play(StatesMachineManager.instance.WALK_ANIMATION);
        }

        public override void Close()
        {
            //throw new System.NotImplementedException();
        }
    }
}