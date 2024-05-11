using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    [CreateAssetMenu(fileName = "Assets", menuName = "Production/Assets")]
    public class Assets : ScriptableObject
    {
        [Serializable]
        public class ItemSprite
        {
            [field: SerializeField] public ItemTypes ItemType { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
        }

        [SerializeField] private List<ItemSprite> _itemSprites;
        [SerializeField] private List<BuildingView> _buildingPrefabs;

        public Sprite GetItemSprite(ItemTypes itemType)  => _itemSprites.Find(x => x.ItemType == itemType).Sprite;

        public T GetBuilding<T>() where T : BuildingView => (T)_buildingPrefabs.Find(x => x is T);
    }
}
