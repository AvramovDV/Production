using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class ResourceBuildingScreen : BaseScreen
    {
        [field: SerializeField] public Button ItemButton { get; private set; }
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public Button StopButton { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
        [field: SerializeField] public Image ItemImage { get; private set; }
    }
}
