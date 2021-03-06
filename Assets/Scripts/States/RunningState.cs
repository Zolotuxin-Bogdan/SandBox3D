﻿using Assets.FSM;
using Assets.Scripts.Tools_and_Managers;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class RunningState : State
    {
        private Animator _animator;
        public override void Start()
        {
            _animator = PlayerStatesManager.instance.Player.GetComponent<Animator>();
            _animator.Play(PlayerStatesManager.instance.RUN_ANIMATION);
        }

        public override void Close()
        {
            //throw new System.NotImplementedException();
        }
    }
}
