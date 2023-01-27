using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using Moq;
using P3AddNewFunctionalityDotNetCore.Data;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Xunit;
using Xunit.Sdk;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary> 

        // product name check
        // mocking in all tests cases
        // mock database -> mock datas --> mock error messages

        [Fact]
        public void CheckName()
        {
            // Arrange
            Mock<ICart> mockCart = new Mock<ICart>();
            Mock<IOrderRepository> mockOrder = new Mock<IOrderRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            Mock<IProductService> mockProductService = new Mock<IProductService>();
            Mock<IStringLocalizer<ProductService>> mockStringLocalizer = new Mock<IStringLocalizer<ProductService>>();

            var error = new LocalizedString("MissingName", "Please enter a name");
            mockStringLocalizer.Setup(ml => ml["MissingName"]).Returns(error);


          
            var productService = new ProductService(mockCart.Object, mockProductRepository.Object, mockOrder.Object, mockStringLocalizer.Object);

            ProductViewModel product = new ProductViewModel()
            {
                Name = null,
                Price = "11",
                Description = "Test",
                Stock = "12",
                Details = "test"
            };

            // Act
            var newError = productService.CheckProductModelErrors(product);


            // Assert
            Assert.Contains("Please enter a name", newError);
        }

        [Fact]
        public void CheckPrice()
        {
            // Arrange
            Mock<ICart> mockCart = new Mock<ICart>();
            Mock<IOrderRepository> mockOrder = new Mock<IOrderRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            Mock<IProductService> mockProductService = new Mock<IProductService>();
            Mock<IStringLocalizer<ProductService>> mockStringLocalizer = new Mock<IStringLocalizer<ProductService>>();

            var error = new LocalizedString("MissingPrice", "Please add a price");
            mockStringLocalizer.Setup(ml => ml["MissingPrice"]).Returns(error);



            var productService = new ProductService(mockCart.Object, mockProductRepository.Object, mockOrder.Object, mockStringLocalizer.Object);

            ProductViewModel product = new ProductViewModel()
            {
                Name = "Product",
                Price = null,
                Description = "Test",
                Stock = "12",
                Details = "test"
            };

            // Act
            var newError = productService.CheckProductModelErrors(product);

            // Assert
            Assert.Contains("Please add a price", newError);
        }

        //[Fact]
        //public void CheckPriceNotANumber()
        //{
        //    // Arrange


        //    // Act


        //    // Assert

        //}

        //[Fact]
        //public void CheckPriceNotGreaterThanZero()
        //{
        //    // Arrange


        //    // Act


        //    // Assert

        //}

        //[Fact]
        //public void CheckMissingQuantity()
        //{
        //    // Arrange


        //    // Act


        //    // Assert

        //}

        //[Fact]
        //public void CheckQuantityNotAnInteger()
        //{
        //    // Arrange


        //    // Act


        //    // Assert

        //}

        //[Fact]
        //public void CheckQuantityNotGreaterThanZero()
        //{
        //    // Arrange


        //    // Act


        //    // Assert

        //}
    }
}