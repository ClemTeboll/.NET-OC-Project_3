using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Moq;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.IntegrationTests
{
    public class IntegrationTests
    {

        [Fact]
        public void CheckProductIsSaved()
        {
            // Arrange
            Mock<ICart> mockCart = new Mock<ICart>();
            Mock<IOrderRepository> mockOrder = new Mock<IOrderRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            Mock<IProductService> mockProductService = new Mock<IProductService>();
            Mock<IStringLocalizer<ProductService>> mockStringLocalizer = new Mock<IStringLocalizer<ProductService>>();

            var productService = new ProductService(mockCart.Object, mockProductRepository.Object, mockOrder.Object, mockStringLocalizer.Object);

            ProductViewModel product = new ProductViewModel()
            {
                Name = "Product",
                Price = "11",
                Description = "Test",
                Stock = "0",
                Details = "test"
            };

            // Act
            productService.SaveProduct(product);

            //bool expected = true;
            //bool actual;

            var options = new DbContextOptionsBuilder<AppIdentityDbContext>()
                .UseInMemoryDatabase(databaseName: "Identity")
                .Options;

            using (var context = new AppIdentityDbContext(options))
            {
                // actual
            }

            // Assert

            //Assert.True(expected == actual);
        }

        //[Fact]
        //public void CheckProductIsDeleted()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}
    }
}
