using ProductManagementApi.Domain;

namespace ProductManagementApi.Application
{
     public class ProductDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierCnpj { get; set; }
    }
}
   