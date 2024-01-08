public class Product
{
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid SupplierId { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
}
