using TMPro;
using UnityEngine;

namespace Avramov.Production
{
    public class MainScreen : BaseScreen
    {
        [field: SerializeField] public Transform ItemsPanelTransform { get; private set; }
        [field: SerializeField] public ItemView ItemPrefab { get; private set; }
        [field: SerializeField] public TMP_Text CoinsText { get; private set; }
    }
}
