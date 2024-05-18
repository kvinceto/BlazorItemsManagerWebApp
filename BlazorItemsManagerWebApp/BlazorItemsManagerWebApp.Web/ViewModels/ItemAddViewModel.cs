namespace BlazorItemsManagerWebApp.Web.ViewModels
{
    using static Common.ApplicationConstants.ItemConstants;

    public class ItemAddViewModel
    {
        //Fields
        private string name = string.Empty;
        private string? description = null;
        private string unit = string.Empty;
        private decimal currentQuantity = 0.00M;
        private decimal currentUnitPrice = 0.00M;
        private string userId = "";

        //Flags
        private bool isNameValid;
        private bool isDescriptionValid;
        private bool isUnitValid;
        private bool isCurrentQuantityValid;
        private bool isCurrentUnitPriceValid;

        public ItemAddViewModel()
        {

        }

        //Properties
        public string Name { get => name; set => name = value; }

        public string? Description { get => this.description; set => this.description = value; }

        public decimal CurrentQuantity { get => this.currentQuantity; set => this.currentQuantity = value; }

        public decimal CurrentUnitPrice { get => this.currentUnitPrice; set => this.currentUnitPrice = value; }

        public string UserId { get => this.userId; set => this.userId = value; }

        public string Unit { get => this.unit; set => this.unit = value; }

        //Methods
        public bool CheckValues()
        {
            if (string.IsNullOrWhiteSpace(this.name) || this.name.Length > NameMaxLength)
            {
                this.isNameValid = false;
            }
            else
            {
                this.isNameValid = true;
            }

            if ((this.description != null) && this.description.Length > DescriptionMaxLength)
            {
                this.isDescriptionValid = false;
            }
            else
            {
                this.isDescriptionValid = true;
            }

            this.isCurrentQuantityValid = this.currentQuantity >= 0.00M;

            this.isCurrentUnitPriceValid = this.currentUnitPrice >= 0.00M;

            this.isUnitValid = !string.IsNullOrWhiteSpace(this.unit);

            return this.isNameValid || this.isDescriptionValid || this.isCurrentQuantityValid || this.isCurrentUnitPriceValid || this.isUnitValid;
        }
    }
}
