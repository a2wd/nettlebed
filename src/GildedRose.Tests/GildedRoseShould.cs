namespace GildedRose.Tests
{
    using GildedRose.Core;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class GildedRoseShould
    {
        [Test]
        public void BeAbleToRunAnNunitTest()
        {
			IList<Item> Items = new List<Item> { new Item{Name = "foo", SellIn = 0, Quality = 0} };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual("fixme", Items[0].Name);
        }
    }
}
