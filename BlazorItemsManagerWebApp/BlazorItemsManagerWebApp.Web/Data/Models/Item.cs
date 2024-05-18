namespace BlazorItemsManagerWebApp.Web.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public decimal CurrentQuantity { get; set; } = 0.00M;

        public decimal CurrentUnitPrice { get; set; } = 0.00M;

        public string Unit { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime LastModifiedAt { get; set; }

        public string UserId { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
