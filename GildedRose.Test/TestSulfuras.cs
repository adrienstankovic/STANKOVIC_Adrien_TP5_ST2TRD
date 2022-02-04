using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Test
{
    [TestFixture]
    public class TestSulfuras
    {
        [Test]
        public void sulfuras_quality_and_sellIn_Test()
        {
            /*
             * This test is made on the quality parameter for a "sulfuras" item
             * the sellIn and the quality should stay the same
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 4, Quality = 50 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The sellin should stay at 4
            Assert.AreEqual(4, Items[0].SellIn);
            // The quality should stay at 50
            Assert.AreEqual(50 , Items[0].Quality);
        }
    }
}