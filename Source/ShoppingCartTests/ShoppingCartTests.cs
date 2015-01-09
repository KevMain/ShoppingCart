using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void ShoppingCart_WhenCreated_ThenIsEmpty()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act

            //Assert
            Assert.AreEqual(0, cart.Products.Count);
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndScrewdriverAdded_ThenContainsOneProduct()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Screwdriver("Description", new Money(1)));
            
            //Assert
            Assert.AreEqual(1, cart.Products.Count);
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndMultipleScrewdriversAdded_ThenContainsCorrectAmountOfProducts()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            var products = new Random().Next(10);

            for (var i = 0; i < products; i++)
            {
                cart.AddProduct(new Screwdriver("Description", new Money(1)));
            }

            //Assert
            Assert.AreEqual(products, cart.Products.Count);
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndScrewdriverAdded_ThenTotalPriceIsEqualToPrice()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Screwdriver("Description", new Money(5.99m)));

            //Assert
            Assert.AreEqual(5.99m, cart.GetTotalPrice());
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndMulitpleScrewdriversAdded_ThenTotalPriceIsEqualToPricesCombined()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Screwdriver("Description", new Money(4m)));
            cart.AddProduct(new Screwdriver("Description", new Money(7m)));

            //Assert
            Assert.AreEqual(11m, cart.GetTotalPrice());
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndCheeseAdded_ThenContainsOneProduct()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Cheese("Description", new Money(7m), new DateTime(2015, 1, 8)));

            //Assert
            Assert.AreEqual(1, cart.Products.Count);
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndMultipleCheeseAdded_ThenContainsAmountOfProducts()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            var products = new Random().Next(10);

            for (var i = 0; i < products; i++)
            {
                cart.AddProduct(new Cheese("Description", new Money(7m), new DateTime(2015, 1, 8)));
            }
            
            //Assert
            Assert.AreEqual(products, cart.Products.Count);
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndCheeseAdded_ThenTotalPriceIsEqualToPrice()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Cheese("Description", new Money(7m), new DateTime(2015, 1, 8)));

            //Assert
            Assert.AreEqual(7m, cart.GetTotalPrice());
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndMulitpleCheesesAdded_ThenTotalPriceIsEqualToPricesCombined()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Cheese("Description", new Money(7m), new DateTime(2015, 1, 8)));
            cart.AddProduct(new Cheese("Description", new Money(7m), new DateTime(2015, 1, 8)));

            //Assert
            Assert.AreEqual(14m, cart.GetTotalPrice());
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedAndScrewdriverAddedAndCheeseAdded_ThenContains2Products()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Screwdriver("Description", new Money(4m)));
            cart.AddProduct(new Cheese("Description", new Money(7m), new DateTime(2015, 1, 8)));

            //Assert
            Assert.AreEqual(2, cart.Products.Count);
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedCheeseWithExpiryDateOfTodayAdded_Then50PercentDiscountApplied()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            cart.AddProduct(new Cheese("Description", new Money(8m), DateTime.Now.Date));

            //Assert
            Assert.AreEqual(4m, cart.GetTotalPrice());
        }


        [TestMethod]
        public void ShoppingCart_WhenCreatedWithABundleOfScrewdriverAndCheeseWhichHasNotExpired_Then10PercentDiscountApplied()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            var products = new List<IProduct>
                {
                    new Screwdriver("Description", new Money(5m)),
                    new Cheese("Description", new Money(5m), new DateTime(2015, 1, 8))
                };

            cart.AddProduct(new Bundle(products));
            
            //Assert
            Assert.AreEqual(9m, cart.GetTotalPrice());
        }

        [TestMethod]
        public void ShoppingCart_WhenCreatedWithABundleOfScrewdriverAndCheeseWhichHasExpired_ThenCheeseDiscountPlus10PercentDiscountApplied()
        {
            //Arrange
            var cart = new ShoppingCart.ShoppingCart();

            //Act
            var products = new List<IProduct>
                {
                    new Screwdriver("Description", new Money(5m)),
                    new Cheese("Description", new Money(10m), DateTime.Now.Date)
                };

            cart.AddProduct(new Bundle(products));

            //Assert
            Assert.AreEqual(9m, cart.GetTotalPrice());
        }
    }
}
