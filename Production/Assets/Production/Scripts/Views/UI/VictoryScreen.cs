using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class VictoryScreen : BaseScreen
    {
        [field: SerializeField] public Button OkButton { get; private set; }
        [field: SerializeField] public Transform PanelTransform { get; private set; }
        [field: SerializeField] public Transform StartPoint { get; private set; }
        [field: SerializeField] public Transform EndPoint { get; private set; }
        [field: SerializeField] public float Speed {  get; private set; }
    }
}
