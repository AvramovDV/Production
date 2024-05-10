using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Avramov.Production
{
    [CreateAssetMenu(fileName = "ItemsSettings", menuName = "Production/ItemsSettings")]
    public class ItemsSettings : ScriptableObject
    {
        [Serializable]
        public class ItemConfig
        {
            [field: SerializeField] public ItemTypes ItemType { get; private set; }
            [field: SerializeField] public int Price { get; private set; }

            [SerializeField] private List<ItemTypes> _subItems;

            public IReadOnlyList<ItemTypes> SubItems => _subItems;
        }

        [SerializeField] private List<ItemConfig> _itemsConfigs;

        public ItemConfig GetItemConfig(ItemTypes itemType) => _itemsConfigs.Find(x => x.ItemType == itemType);

        public ItemModel GetItemModel(ItemData itemData)
        {
            ItemModel model = new ItemModel(itemData, GetItemConfig(itemData.Type));
            return model;
        }

        public InventoryData GetDefaultPlayerData()
        {
            InventoryData playerData = new InventoryData()
            {
                Coins = 0,
                Items = _itemsConfigs.Select(x => new ItemData() { Count = 0, Type = x.ItemType }).ToList()
            };

            return playerData;
        }

        public ItemTypes FindProduct(params ItemTypes[] subitems)
        {
            return _itemsConfigs.Find(x => CheckSubItems(subitems, x.SubItems))?.ItemType ?? ItemTypes.None;
        }

        private bool CheckSubItems(ItemTypes[] subitems1, IReadOnlyList<ItemTypes> subitems2, bool withOrder = true)
        {
            if (subitems1 == null)
                return false;

            if (subitems1.Length != subitems2.Count)
                return false;

            for (int i = 0; i < subitems1.Length; i++)
            {
                if (withOrder)
                {
                    if (subitems1[i] != subitems2[i])
                        return false;
                }
                else
                {
                    if (!subitems2.Contains(subitems1[i]))
                        return false;
                }

            }

            return true;
        }
    }
}
