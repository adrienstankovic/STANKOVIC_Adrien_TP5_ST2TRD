using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Test
{
    [TestFixture]
    public class TestQuality
    {
        [Test]
        public void quality_with_sellIn_over_0()
        {
            /*
             * This test is made on the quality parameter for a "+5 Dexterity Vest" with sellIn over 0,
             * thr quality should decrease by 1
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 10-1 = 9
            Assert.AreEqual(9 , Items[0].Quality);
        }
        
        [Test]
        public void quality_with_sellIn_at_0()
        {
            /*
             * This test is made on the quality parameter for a "+5 Dexterity Vest" with sellIn at 0,
             * the quality should decrease by 2
             */ 
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 10-2 = 9
            Assert.AreEqual(8 , Items[0].Quality);
        }
        
        [Test]
        public void quality_with_sellIn_below_0()
        {
            /*
             * This test is made on the quality parameter for a "+5 Dexterity Vest" with sellIn below 0, the sell by date has passed,
             * the quality should decrease by 2
             */ 
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -2, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 10-2 = 8
            Assert.AreEqual(8 , Items[0].Quality);
        }
        
        [Test]
        public void quality_with_quality_at_0()
        {
            /*
             * This test is made on the quality parameter for a "+5 Dexterity Vest" with sellIn below 0,the quality is equal to 0,
             * the quality should decrease by 1, however, the quality can't be negative
             */ 
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should stay equal to 0
            Assert.AreEqual(0, Items[0].Quality);
        }
        
    }
}