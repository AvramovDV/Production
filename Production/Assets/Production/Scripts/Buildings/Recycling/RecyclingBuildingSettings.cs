using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    [CreateAssetMenu(fileName = "RecyclingBuildingSettings", menuName = "Production/RecyclingBuildingSettings")]
    public class RecyclingBuildingSettings : BaseBuildingSettings
    {
        [field: SerializeField] public float ProductionTime { get; private set; }

        [SerializeField] private List<ItemTypes> _items;

        public IReadOnlyList<ItemTypes> Items => _items;

        public override BaseBuildingModel GetModel(InventoryModel inventory)
        {
            return new RecyclingBuildingModel(this, inventory);
        }
    }
}
