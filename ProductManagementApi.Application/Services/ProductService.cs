using System;
using System.Linq;
using AutoMapper;
using ProductManagementApi.Domain;
using ProductManagementApi.Infrastructure;

namespace ProductManagementApi.Application
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductDto GetProductById(int id)
        {
            var product = _repository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public IQueryable<ProductDto> GetProducts()
        {
            var products = _repository.GetAll();
            return _mapper.ProjectTo<ProductDto>(products);
        }

        public void AddProduct(ProductDto productDto)
        {
            ValidateDates(productDto.ManufacturingDate, productDto.ExpiryDate);
            var product = _mapper.Map<Product>(productDto);
            _repository.Add(product);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            ValidateDates(productDto.ManufacturingDate, productDto.ExpiryDate);
            var product = _mapper.Map<Product>(productDto);
            _repository.Update(product);
        }

        public void SoftDeleteProduct(int id)
        {
            _repository.SoftDelete(id);
        }

        private void ValidateDates(DateTime manufacturingDate, DateTime expiryDate)
        {
            if (manufacturingDate >= expiryDate)
            {
                throw new InvalidOperationException("Manufacturing date must be before expiry date.");
            }
        }
    }
}
