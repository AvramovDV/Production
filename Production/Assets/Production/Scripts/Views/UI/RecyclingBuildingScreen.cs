using UnityEngine;
using UnityEngine.UI;


namespace Avramov.Production
{
    public class RecyclingBuildingScreen : BaseScreen
    {
        [field: SerializeField] public Button ResourceButton1 { get; private set; }
        [field: SerializeField] public Button ResourceButton2 { get; private set; }
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public Button StopButton { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
        [field: SerializeField] public Image ResourceImage1 { get; private set; }
        [field: SerializeField] public Image ResourceImage2 { get; private set; }
        [field: SerializeField] public Image ResultImage { get; private set; }
    }
}
