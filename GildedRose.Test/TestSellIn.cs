using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Test
{
    [TestFixture]
    public class TestSellIn
    {
        [Test]
        public void sellInTest()
        {
            // This test is made on the quality parameter for a "+5 Dexterity Vest"
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 15 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The sellIn should be equal to 10-1 = 9
            Assert.AreEqual(9 , Items[0].SellIn);
        }
    }
}