namespace BlazorItemsManegerWebAppDevExpress.Web.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; } = 0.00M;

        public string CreatedAd { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
