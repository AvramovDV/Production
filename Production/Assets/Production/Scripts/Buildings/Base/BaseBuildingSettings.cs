using UnityEngine;

namespace Avramov.Production
{
    public abstract class BaseBuildingSettings : ScriptableObject
    {
        [field: SerializeField] public BuildType BuildType { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }

        public abstract BaseBuildingModel GetModel(InventoryModel inventory);
    }
}
