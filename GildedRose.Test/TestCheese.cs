using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Test
{
    [TestFixture]
    public class TestCheese
    {
        [Test]
        public void cheese_quality_with_sellIn_over_0()
        {
            /*
             * This test is made on the quality parameter for a "Aged Brie" with a SellIn over 0,
             * the quality should increase by 1
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            //app.UpdateQuality();
            app.new_updateQuality();
            
            // Assert
            // The quality should be equal to 10+1 = 11
            Assert.AreEqual(11 , Items[0].Quality);
        }
        
        [Test]
        public void cheese_quality_with_sellIn_at_0()
        {
            /*
             * This test is made on the quality parameter for a "Aged Brie" with a SellIn at 0,
             * the quality should increase by 2
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            //app.UpdateQuality();
            app.new_updateQuality();
            
            // Assert
            // The quality should be equal to 10+2 = 11
            Assert.AreEqual(12 , Items[0].Quality);
        }
        
        [Test]
        public void cheese_quality_with_sellIn_below_0()
        {
            /*
             * This test is made on the quality parameter for a "Aged Brie" with a SellIn below 0,
             * the quality should increase by 2
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -4, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            //app.UpdateQuality();
            app.new_updateQuality();
            
            // Assert
            // The quality should be equal to 10+2 = 11
            Assert.AreEqual(12 , Items[0].Quality);
        }
        
        [Test]
        public void cheese_quality_with_quality_over_50()
        {
            /*
             * This test is made on the quality parameter for a "Aged Brie" with a SellIn below 0 and quality at 49,
             * the quality should increase by 2, however, the quality can't be over 50
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -4, Quality = 49 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            //app.UpdateQuality();
            app.new_updateQuality();
            
            // Assert
            // The quality should be equal to the maximum value: 50
            Assert.AreEqual(50 , Items[0].Quality);
        }
    }
}