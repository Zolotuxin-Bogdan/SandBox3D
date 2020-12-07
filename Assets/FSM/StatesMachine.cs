using UnityEngine;

namespace Assets.FSM
{
    public class StatesMachine
    {
        private State _state = null;

        public StatesMachine(State state)
        {
            SwitchTo(state);
        }

        public void SwitchTo(State state)
        {
            Debug.Log($"StatesMachine: Switch to {state.GetType().Name}");
            _state = state;
            state.SetStatesMachine(this);
        }

        public void StartState()
        {
            _state.Start();
        }

        public void CloseState()
        {
            _state.Close();
        }
    }
}