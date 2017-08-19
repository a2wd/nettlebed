namespace GildedRose.Core
{
    using global::GildedRose.Core.Inventory;
    using System.Collections.Generic;
    using System.Linq;

    public class GildedRose
    {
        private IList<InventoryItem> InventoryItems;
        private IList<Item> Items;

        public GildedRose(IList<InventoryItem> inventoryItems)
        {
            InventoryItems = inventoryItems;
            Items = inventoryItems.Select(i => i.GetItem()).ToList();
        }

        public void UpdateQuality()
        {
            foreach (var inventoryItem in InventoryItems)
            {
                inventoryItem.UpdateSellInAndQuality();
            }
        }
    }
}
