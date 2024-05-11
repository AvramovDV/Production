using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Avramov.Production
{
    public class BuildingView : MonoBehaviour, IPointerClickHandler
    {
        public event Action ClickEvent;

        public void OnPointerClick(PointerEventData eventData) => ClickEvent?.Invoke();
    }
}
