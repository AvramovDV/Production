using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class ItemView : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public TMP_Text CountText { get; private set; }
    }
}
