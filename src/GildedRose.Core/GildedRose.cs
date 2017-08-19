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

        private bool IsNamedItem(string name)
        {
            return name == Constants.Names.BackstagePasses;
        }

        public void UpdateQuality()
        {
            foreach (var inventoryItem in InventoryItems)
            {
                var item = inventoryItem.GetItem();
                if(IsNamedItem(item.Name) == false)
                {
                    inventoryItem.UpdateSellInAndQuality();
                }
            }

            for (var i = 0; i < Items.Count; i++)
            {
                if(IsNamedItem(Items[i].Name) == false)
                {
                    continue;
                }

                if (Items[i].Name != Constants.Names.Brie && Items[i].Name != Constants.Names.BackstagePasses)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != Constants.Names.Sulfuras)
                        {
                            Items[i].Quality = Items[i].Quality - Constants.Rates.Quality;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == Constants.Names.BackstagePasses)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + Constants.Rates.Quality;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + Constants.Rates.Quality;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != Constants.Names.Sulfuras)
                {
                    Items[i].SellIn = Items[i].SellIn - Constants.Rates.SellIn;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != Constants.Names.Brie)
                    {
                        if (Items[i].Name != Constants.Names.BackstagePasses)
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != Constants.Names.Sulfuras)
                                {
                                    Items[i].Quality = Items[i].Quality - Constants.Rates.Quality;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + Constants.Rates.Quality;
                        }
                    }
                }
            }
        }
    }
}
