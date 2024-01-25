using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;
using TK_Project.Persistance.Context;

namespace TK_Project.Tests.DatabaseTests
{
    public class ProductTest
    {
        [Fact]
        public async void GetByIDProduct_ShouldGetByIDProductToDatabase()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByIDDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                //Act
                var product = new Product()
                {
                    Id = 1,
                    Name = "TestName",
                    Description = "Test",
                    Price = 10,
                    Stock = 50,
                    Status = true,
                    CategoryId = 1
                };
                await context.Products.AddAsync(product);
                var retrievedProduct = await context.Products.FindAsync(1);

                //Assert
                Assert.NotNull(retrievedProduct);
                Assert.Equal("TestName", retrievedProduct.Name);
                Assert.Equal(10, retrievedProduct.Price);
            }
        }

        [Fact]
        public async void AddProduct_ShouldAddProductToDatabase()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddProductDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                //Act
                var product = new Product()
                {
                    Id = 1,
                    Name = "TestName",
                    Description = "Test",
                    Price = 10,
                    Stock = 50,
                    Status = true,
                    CategoryId = 1
                };
                await context.Products.AddAsync(product);

                //Assert
                var addedProduct = await context.Set<Product>().FindAsync(1);
                Assert.NotNull(addedProduct);
                Assert.Equal("TestName", addedProduct.Name);
                Assert.Equal(10, addedProduct.Price);
            }
        }

        [Fact]
        public async void UpdateProduct_ShouldUpdateProductToDatabase()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateProductDB")
                .EnableSensitiveDataLogging(false)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                //Act
                var product = new Product()
                {
                    Id = 1,
                    Name = "TestName",
                    Description = "Test",
                    Price = 10,
                    Stock = 50,
                    Status = true,
                    CategoryId = 1
                };
                await context.Products.AddAsync(product);

                product.Name = "UpdatedName";
                product.Price = 99;

                context.Set<Product>().Update(product);

                //Assert
                var updatedProduct = await context.Set<Product>().FindAsync(1);
                Assert.NotNull(updatedProduct);
                Assert.Equal("UpdatedName", updatedProduct.Name);
                Assert.Equal(99, updatedProduct.Price);
            }
        }

        [Fact]
        public async void RemoveProduct_ShouldRemoveProductToDatabase()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RemoveProductDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                //Act
                var product = new Product()
                {
                    Id = 1,
                    Name = "TestName",
                    Description = "Test",
                    Price = 10,
                    Stock = 50,
                    Status = true,
                    CategoryId = 1
                };
                context.Products.Add(product);
                context.Products.Remove(product);

                //Assert
                var addedProduct = await context.Set<Product>().FindAsync(1);
                Assert.Null(addedProduct);
            }
        }
    }
}
