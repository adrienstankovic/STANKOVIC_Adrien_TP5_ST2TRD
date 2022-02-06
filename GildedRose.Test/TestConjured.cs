using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Test
{
    [TestFixture]
    public class TestConjured
    {
        [Test]
        public void conjured_quality_with_sellIn_over_0()
        {
            // This test is made on the quality parameter for a "conjured" item
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6} };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            //app.UpdateQuality();
            app.new_updateQuality();
            
            // Assert
            // The quality should be equal to 6-2 = 4
            Assert.AreEqual(4 , Items[0].Quality);
        }
        
        [Test]
        public void conjured_quality_with_sellIn_under_0()
        {
            // This test is made on the quality parameter for a "conjured" item
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item {Name = "Conjured Mana Cake", SellIn = -2, Quality = 6} };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            //app.UpdateQuality();
            app.new_updateQuality();
            
            // Assert
            // The quality should be equal to 6-4 = 2
            Assert.AreEqual(2 , Items[0].Quality);
        }
    }
}