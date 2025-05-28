namespace eShop.Domain
{
    public class Cart : AuditableEntity
    {
        public Guid CartId { get; set; }
        public ICollection<Product>? Products  { get; } = new List<Product>();
    }
}
