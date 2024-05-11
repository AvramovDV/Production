using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class ResourceBuildingView : BuildingView
    {
        [field: SerializeField] public RectTransform ProductionIndicator { get; private set; }
        [field: SerializeField] public Image ItemImage { get; private set; }
        [field: SerializeField] public Image ProgressImage { get; private set; }

        [SerializeField] private Vector3 _offset;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            SetupUIPosition();
        }

        public void SetupUIPosition() => ProductionIndicator.anchoredPosition = _camera.WorldToScreenPoint(transform.position + _offset);
    }
}
