namespace GildedRose.Core.Inventory
{
    public interface IInventoryItem
    {
        Item GetItem();
        void UpdateSellInAndQuality();
    }
}