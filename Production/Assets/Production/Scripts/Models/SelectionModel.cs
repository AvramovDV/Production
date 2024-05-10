using System;

namespace Avramov.Production
{
    public class SelectionModel
    {
        public ISelectable Selectable { get; private set; }

        public event Action SelectionChangedEvent;

        public void Select(ISelectable selectable)
        {
            Selectable = selectable;
            SelectionChangedEvent?.Invoke();
        }
    }
}
