using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class StoreBuildingScreen : BaseScreen
    {
        [field: SerializeField] public Button ItemButton { get; private set; }
        [field: SerializeField] public Button SellButton { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
        [field: SerializeField] public Image ItemImage { get; private set; }
        [field: SerializeField] public Image EnableSellImage { get; private set; }
        [field: SerializeField] public Image DisableSellImage { get; private set; }
        [field: SerializeField] public TMP_Text PriceText { get; private set; }
    }
}
