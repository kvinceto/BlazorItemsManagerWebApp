namespace BlazorItemsManagerWebApp.Web.ViewModels
{
    public class ItemEditViewModel
    {
        //Fields
        private int id;
        private string name = string.Empty;
        private string? description = null;
        private decimal currentQuantity = 0.00M;
        private decimal currentUnitPrice = 0.00M;
        private string userId = string.Empty;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        //Flags
        private bool isIdValid;
        private bool isNameValid;
        private bool isCurrentQuantityValid;
        private bool isCurrentUnitPriceValid;
        private bool isUserIdValid;


        public ItemEditViewModel()
        {

        }

        //Properties
        public int Id { get => id; set => id = value; }

        public string Name { get => name; set => name = value; }

        public string? Description { get => this.description; set => this.description = value; }

        public decimal CurrentQuantity { get => this.currentQuantity; set => this.currentQuantity = value; }

        public decimal CurrentUnitPrice { get => this.currentUnitPrice; set => this.currentUnitPrice = value; }

        public string UserId { get => this.userId; set => this.userId = value; }

        public DateTime CreatedAt { get => this.createdAt; set => this.createdAt = value; }

        public DateTime LastModifiedAt { get => this.lastModifiedAt; set => this.lastModifiedAt = value; }

        public bool IsDeleted { get; set; }

        public bool CheckValues()
        {
            isIdValid = this.id > 0 ? true : false;
            isNameValid = !string.IsNullOrWhiteSpace(this.name);
            isCurrentQuantityValid = this.currentQuantity >= 0.00M;
            isCurrentUnitPriceValid = this.currentUnitPrice >= 0.00M;
            isUserIdValid = !string.IsNullOrWhiteSpace(this.userId);

            return isIdValid || isNameValid || isCurrentQuantityValid || isCurrentUnitPriceValid || isUserIdValid;
        }
    }
}
