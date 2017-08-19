namespace GildedRose.Core.Inventory
{
    public class IncreasingQualityInventoryItem : InventoryItem
    {
        public IncreasingQualityInventoryItem(Item item) : base(item)
        {
        }

        protected override void UpdateQuality()
        {
            if (_item.Quality < Constants.Values.MaxQuality)
            {
                _item.Quality = _item.Quality + Constants.Rates.Quality;
            }
        }
    }
}
