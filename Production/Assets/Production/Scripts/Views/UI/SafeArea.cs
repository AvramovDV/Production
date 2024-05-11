using UnityEngine;

namespace Avramov.Production
{
    public class SafeArea : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        private void Start()
        {
            SetSafeArea();
        }

        private void SetSafeArea()
        {
            var safe = Screen.safeArea;

            Vector2 anchorMin = safe.position;
            Vector2 anchorMax = safe.position + safe.size;

            float width = Screen.width;
            float height = Screen.height;
            anchorMin.x /= width;
            anchorMin.y /= height;
            anchorMax.x /= width;
            anchorMax.y /= height;

            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
    }
}
