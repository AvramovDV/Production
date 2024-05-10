using System;

namespace Avramov.Production
{
    public abstract class BaseState
    {
        public event Action<Type> SwitchStateEvent;

        public abstract void Start();
        public abstract void Update();
        public abstract void End();

        protected void SwitchState<T>() => SwitchStateEvent(typeof(T));
    }
}
