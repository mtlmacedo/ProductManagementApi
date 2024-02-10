namespace ProductManagementApi.Domain
{
    public class Product : IProduct
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierCnpj { get; set; }
    }

    public enum ProductStatus
    {
        Active,
        Inactive
    }
}
