namespace GildedRose.Tests
{
    using GildedRose.Core;
    using GildedRose.Core.Inventory;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class GildedRoseShould
    {
        [Test]
        public void LowerSellInAndQualityForAnItem()
        {
            var sellIn = 1;
            var quality = 1;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(sellIn - 1, item[0].GetItem().SellIn);
            Assert.AreEqual(quality - 1, item[0].GetItem().Quality);
        }

        [Test]
        public void NeverLowerQualityBelow0()
        {
            var sellIn = 1;
            var quality = 1;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].GetItem().Quality);
        }

        public void NeverLowerSellInBelow0()
        {
            var sellIn = 1;
            var quality = 1;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].GetItem().SellIn);
        }

        [Test]
        public void LowerQualityInMultiplesOfTwoWhenPastSellIn()
        {
            var sellIn = 0;
            var quality = 2;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].GetItem().Quality);
        }

        [Test]
        public void IncreaseTheQualityOfBrieWithAge()
        {
            var sellIn = 1;
            var quality = 1;
            var name = Constants.Names.Brie;
            var item = new Item
            {
                Name = name,
                Quality = quality,
                SellIn = sellIn
            };

            var inventoryItem = new IncreasingQualityInventoryItem(item);

            var inventoryItemList = new List<InventoryItem>
            {
                inventoryItem
            };

            var gildedRose = new GildedRose(inventoryItemList);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 1, item.Quality);
        }

        [Test]
        public void NeverIncreaseQualityAbove50()
        {
            var sellIn = 1;
            var quality = 50;
            var name = Constants.Names.Brie;
            var item = new Item
            {
                Name = name,
                Quality = quality,
                SellIn = sellIn
            };

            var inventoryItem = new IncreasingQualityInventoryItem(item);

            var inventoryItemList = new List<InventoryItem>
            {
                inventoryItem
            };

            var gildedRose = new GildedRose(inventoryItemList);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality, item.Quality);
        }

        [Test]
        public void NeverChangeThePropertiesOfSulfuras()
        {
            var sellIn = 10;
            var quality = Constants.Qualities.Sulfuras;
            var name = Constants.Names.Sulfuras;

            var item = new Item
            {
                Name = name,
                Quality = quality,
                SellIn = sellIn
            };

            var inventoryItem = new UnchangingInventoryItem(item);

            var inventoryItemList = new List<InventoryItem>
            {
                inventoryItem
            };

            var gildedRose = new GildedRose(inventoryItemList);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality, item.Quality);
            Assert.AreEqual(sellIn, item.SellIn);
        }

        [Test]
        public void IncreaseBackstagePassQualityWhileSellInIsAbove10()
        {

            var sellIn = 20;
            var quality = 10;
            var name = Constants.Names.BackstagePasses;
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 1, item[0].GetItem().Quality);
            Assert.AreEqual(sellIn - 1, item[0].GetItem().SellIn);
        }

        [Test]
        public void IncreaseBackstagePassQualityBy2WhileSellInIsBetween5And10()
        {

            var sellIn = 10;
            var quality = 10;
            var name = Constants.Names.BackstagePasses;
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 2, item[0].GetItem().Quality);
            Assert.AreEqual(sellIn - 1, item[0].GetItem().SellIn);
        }

        [Test]
        public void IncreaseBackstagePassQualityBy3WhileSellInIsBetween0And5()
        {

            var sellIn = 5;
            var quality = 10;
            var name = Constants.Names.BackstagePasses;
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 3, item[0].GetItem().Quality);
            Assert.AreEqual(sellIn - 1, item[0].GetItem().SellIn);
        }

        [Test]
        public void DecreaseBackstagePassQualityTo0WhenSellInIsBelow1()
        {
            var sellIn = 0;
            var quality = 10;
            var name = Constants.Names.BackstagePasses;
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].GetItem().Quality);
            Assert.AreEqual(sellIn - 1, item[0].GetItem().SellIn);
        }

        #region Helpers
        private IList<InventoryItem> GetSampleItemAsList(int sellIn, int quality)
        {
            var emptyName = string.Empty;

            return GetNamedSampleItemAsList(sellIn, quality, emptyName);
        }

        private IList<InventoryItem> GetNamedSampleItemAsList(int sellIn, int quality, string name)
        {
            var itemList = new List<InventoryItem>();
            var item = new Item
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };

            var inventoryItem = new RegularInventoryItem(item);

            itemList.Add(inventoryItem);

            return itemList;
        }
        #endregion
    }
}
