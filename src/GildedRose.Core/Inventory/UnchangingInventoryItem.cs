namespace GildedRose.Core.Inventory
{
    public class UnchangingInventoryItem : InventoryItem
    {
        public UnchangingInventoryItem(Item item) : base(item)
        {
        }

        protected override void UpdateQuality()
        {
        }

        protected override void UpdateSellIn()
        {
        }
    }
}
