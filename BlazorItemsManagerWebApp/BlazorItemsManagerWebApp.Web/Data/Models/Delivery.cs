namespace BlazorItemsManagerWebApp.Web.Data.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public string? DelivaryNumber { get; set; }

        public int ItemId { get; set; }

        public decimal Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal TotalPrice { get; set; }

        public string DeliveredBy { get; set; } = null!;

        public DateTime DeliveredAt { get; set; }

        public string UserId { get; set; } = null!;
    }
}
