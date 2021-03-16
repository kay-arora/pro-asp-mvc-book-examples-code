using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EssentialTools.Models;
using System.Linq;
using Moq;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "WaterSports", Price = 275M},
            new Product {Name = "LifeJacket", Category = "WaterSports", Price = 48.9M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.5M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 39.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            //arrange using Moq
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);

            //// arrange
            //var discounter = new MinimumDiscountHelper();
            //var target = new LinqValueCalculator(discounter);
            //var goalTotal = products.Sum(e => e.Price);

            //act
            var result = target.ValueProducts(products);

            //assert
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }
    }
}
