namespace BlazorItemsManegerWebAppDevExpress.Web.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; } = 0.00M;

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
