namespace Assets.FSM
{
    public abstract class State
    {
        protected StatesMachine _statesMachine;

        public void SetStatesMachine(StatesMachine machine)
        {
            _statesMachine = machine;
        }

        public abstract void Start();
        public abstract void Close();
    }
}