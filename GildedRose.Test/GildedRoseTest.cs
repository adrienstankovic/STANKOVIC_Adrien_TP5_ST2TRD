﻿using NUnit.Framework;
using System.Collections.Generic;
using csharp;
using GildedRose;

namespace GildedRose.Test
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
    }
}
