using Microsoft.EntityFrameworkCore;
using P3AddNewFunctionalityDotNetCore.Data;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace P3AddNewFunctionalityDotNetCore.IntegrationTests
{
    public class IntegrationTests
    {
        public class connectionHelper : IDisposable
        {
            private bool disposedValue;

            public P3Referential CreateInMemory()
            {
                var options = new DbContextOptionsBuilder<P3Referential>()
                .UseInMemoryDatabase(databaseName: "P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a")
                .Options;

                P3Referential context = new P3Referential(options);
                if (context != null)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                return context;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                        return;

                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }

        [Fact]
        public void CheckProductIsSaved()
        {
            // Assert
            connectionHelper connection = new connectionHelper();
            using (P3Referential context = connection.CreateInMemory())
            {
                Product product = new Product()
                {
                    Name = "Product",
                    Price = 10,
                    Description = "Test",
                    Details = "test",
                    Quantity = 12
                };

                ProductRepository productService = new ProductRepository(context);
                productService.SaveProduct(product);

                // Act
                List<Product> results = productService.GetAllProducts().ToList();

                // Assert
                Assert.NotEmpty(results);
            }
        }

        [Fact]
        public void CheckProductIsDeleted()
        {
            // Arrange
            var connection = new connectionHelper();
            using (var context = connection.CreateInMemory())
            {
                Product product = new Product()
                {
                    Name = "Product",
                    Price = 10,
                    Description = "Test",
                    Details = "test",
                    Quantity = 12
                };

                ProductRepository productService = new ProductRepository(context);
                productService.SaveProduct(product);
                productService.DeleteProduct(product.Id);

                // Act
                List<Product> results = productService.GetAllProducts().ToList();

                // Assert
                Assert.Empty(results);
            }
        }
    }
}
