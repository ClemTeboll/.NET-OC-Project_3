using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using Moq;
using P3AddNewFunctionalityDotNetCore.Data;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary> 

        private readonly ICart cart;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IStringLocalizer<ProductService> localizer;

        // product name check
        // mocking in all tests cases
        // mock database -> mock datas --> mock error messages

        [Fact]
        public void CheckName()
        {
            // Arrange
            IProductService productService = new ProductService(cart, productRepository, orderRepository, localizer);

            // Act
            Product newError = productService.CheckProductModelErrors();

            // Assert
            //Assert.Same("", product.Name);
            //Assert.Equal(1, 1);
        }

        //[Fact]
        //public void CheckPrice()    
        //{
        //    // Arrange


        //    // Act


        //    // Assert

        //}

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