namespace eShop.Domain
{
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
    }
}
