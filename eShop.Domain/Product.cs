namespace eShop.Domain
{
    public class Product : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
		//public Guid CartId { get; set; }
		//public Cart? Carts { get; set; } = null;
    }
}
