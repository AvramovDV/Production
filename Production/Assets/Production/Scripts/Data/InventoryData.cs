using System;
using System.Collections.Generic;

namespace Avramov.Production
{
    [Serializable]
    public struct InventoryData
    {
        public List<ItemData> Items;

        public int Coins;
    }
}
