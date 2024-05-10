using System;
using System.Collections.Generic;

namespace Avramov.Production
{
    public class StateMachine
    {
        private Dictionary<Type, BaseState> _states = new Dictionary<Type, BaseState>();

        private BaseState _currentState;

        public void Update()
        {
            _currentState?.Update();
        }

        public void AddState<T>(T state) where T : BaseState
        {
            _states.Add(typeof(T), state);
            state.SwitchStateEvent += SwitchState;
        }

        public void SwitchState<T>() => SwitchState(typeof(T));

        public void SwitchState(Type state)
        {
            _currentState?.End();
            _currentState = _states[state];
            _currentState.Start();
        }
    }
}
