using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Avramov.Production
{
    public class StartScreen : BaseScreen
    {
        [field: SerializeField] public Button StartButton { get; private set; }

        [SerializeField] private List<CountTriggerSelector> _resourceBuildingsSelectors;

        public IReadOnlyList<CountTriggerSelector> ResourceBuildingsSelectors => _resourceBuildingsSelectors;
    }
}
