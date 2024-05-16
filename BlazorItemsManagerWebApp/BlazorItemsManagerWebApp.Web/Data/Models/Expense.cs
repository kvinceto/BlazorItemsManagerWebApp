namespace BlazorItemsManagerWebApp.Web.Data.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string? ExpenceNumber { get; set; }

        public int ItemId { get; set; }

        public decimal ItemQuantity { get; set; }

        public decimal ItemAmountPerUnit { get; set; }

        public decimal ItemTotalAmount { get; set; }

        public DateTime DateOfIsue { get; set; }

        public string UserId { get; set; } = null!;
    }
}
