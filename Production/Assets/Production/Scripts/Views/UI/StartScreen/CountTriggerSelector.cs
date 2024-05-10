using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class CountTriggerSelector : MonoBehaviour
    {
        [field: SerializeField] public int Count { get; private set; }

        [SerializeField] private Toggle _toggle;
        [SerializeField] private TMP_Text _countText;

        public bool IsOn =>_toggle.isOn;

        private void OnValidate()
        {
            _countText.text = Count.ToString();
        }
    }
}
