using System.Collections.Generic;
using Unity_RPGProject.Abstracts.States;

namespace Unity_RPGProject.States
{
    public class StateMachine
    {
        List<StateTransformer> _stateTransformers = new List<StateTransformer>();
        List<StateTransformer> _anyTransformer = new List<StateTransformer>();


        IState _currentState;

        public void SetState(IState state)
        {
            if (_currentState == state) return;

            _currentState?.OnExit();

            _currentState = state;

            _currentState.OnEnter();
        }

        public void Tick()
        {
            StateTransformer stateTransformer = CheckForTransformer();

            if (stateTransformer != null)
            {
                SetState(stateTransformer.To);
            }

            _currentState.Tick();
        }

        public void FixedTick()
        {
            _currentState.FixedTick();
        }

        public void LateTick()
        {
            _currentState.LateTick();
        }

        private StateTransformer CheckForTransformer()
        {
            foreach (StateTransformer stateTransformer in _anyTransformer)
            {
                if (stateTransformer.Condition.Invoke()) return stateTransformer;
            }

            foreach (StateTransformer stateTransformer in _stateTransformers)
            {
                if (stateTransformer.Condition.Invoke() && _currentState == stateTransformer.From) return stateTransformer;
            }
            return null;
        }

        public void AddState(IState to, IState from, System.Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(from, to, condition);
            _stateTransformers.Add(stateTransformer);
        }

        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(null, to, condition);
            _anyTransformer.Add(stateTransformer);
        }

    }
}


