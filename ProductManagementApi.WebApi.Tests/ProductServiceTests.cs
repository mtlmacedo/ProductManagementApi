using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagementApi.Application;
using ProductManagementApi.Domain;
using ProductManagementApi.Infrastructure;
using Xunit;

namespace ProductManagementApi.WebApi.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddProduct_ValidDates_ShouldAddProduct()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "AddProduct_ValidDates_ShouldAddProduct")
                .Options;

            using (var context = new ProductContext(options))
            {
                var repository = new ProductRepository(context);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()));
                var productService = new ProductService(repository, mapper);

                productService.AddProduct(new ProductDto
                {
                    Description = "Test Product",
                    Status = ProductStatus.Active,
                    ManufacturingDate = DateTime.Now.AddDays(-1),
                    ExpiryDate = DateTime.Now.AddDays(7),
                    SupplierCode = 1,
                    SupplierDescription = "Test Supplier",
                    SupplierCnpj = "12345678901234"
                });

                Assert.Equal(1, context.Products.Count());
            }
        }

        [Fact]
        public void AddProduct_InvalidDates_ShouldThrowException()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "AddProduct_InvalidDates_ShouldThrowException")
                .Options;

            using (var context = new ProductContext(options))
            {
                var repository = new ProductRepository(context);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()));
                var productService = new ProductService(repository, mapper);

                Assert.Throws<InvalidOperationException>(() =>
                    productService.AddProduct(new ProductDto
                    {
                        Description = "Test Product",
                        Status = ProductStatus.Active,
                        ManufacturingDate = DateTime.Now.AddDays(1),
                        ExpiryDate = DateTime.Now.AddDays(-1),
                        SupplierCode = 1,
                        SupplierDescription = "Test Supplier",
                        SupplierCnpj = "12345678901234"
                    }));
            }
        }
    }
}
