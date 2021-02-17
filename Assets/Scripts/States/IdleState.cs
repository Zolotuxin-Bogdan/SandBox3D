using Assets.FSM;
using Assets.Scripts.Tools_and_Managers;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class IdleState: State
    {
        private Animator _animator;

        public IdleState()
        {
            _animator = PlayerStatesManager.instance.Player.GetComponent<Animator>();
        }
        public override void Start()
        {
            _animator.Play(PlayerStatesManager.instance.IDLE_ANIMATION);
        }

        public override void Close()
        {
            //throw new System.NotImplementedException();
        }
    }
}