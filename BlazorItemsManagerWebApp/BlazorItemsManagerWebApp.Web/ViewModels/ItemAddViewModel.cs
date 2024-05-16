namespace BlazorItemsManagerWebApp.Web.ViewModels
{
    public class ItemAddViewModel
    {
        private string name = string.Empty;
        private string? description = null;
        private decimal currentQuantity = 0.00M;
        private decimal currentUnitPrice = 0.00M;
        private string userId = "1173086B-9A67-48A2-BF3B-958E69321A64";

        public ItemAddViewModel()
        {

        }

        public string Name { get => name; set => name = value; }

        public string? Description { get => this.description; set => this.description = value; }

        public decimal CurrentQuantity { get => this.currentQuantity; set => this.currentQuantity = value; }

        public decimal CurrentUnitPrice { get => this.currentUnitPrice; set => this.currentUnitPrice = value; }

        public string UserId { get => this.userId; set => this.userId = value; }
    }
}
