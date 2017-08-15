﻿namespace GildedRose.Core
{
    using global::GildedRose.Core.Inventory;
    using System.Collections.Generic;
    using System.Linq;

    public class GildedRose
    {
        private IList<IInventoryItem> InventoryItems;
        private IList<Item> Items;

        public GildedRose(IList<IInventoryItem> inventoryItems)
        {
            InventoryItems = inventoryItems;
            Items = inventoryItems.Select(i => i.GetItem()).ToList();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
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
