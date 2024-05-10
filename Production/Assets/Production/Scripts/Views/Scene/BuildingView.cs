using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class BuildingView : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField] public RectTransform ProductionIndicator { get; private set; }
        [field: SerializeField] public Image ItemImage { get; private set; }
        [field: SerializeField] public Image ProgressImage { get; private set; }

        [SerializeField] private Vector3 _offset;

        public event Action ClickEvent;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            ProductionIndicator.anchoredPosition = _camera.WorldToScreenPoint(transform.position + _offset);
        }

        public void OnPointerClick(PointerEventData eventData) => ClickEvent?.Invoke();
    }
}
