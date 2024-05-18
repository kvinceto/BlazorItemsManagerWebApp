namespace BlazorItemsManagerWebApp.Web.ViewModels
{
    using static Common.ApplicationConstants.ItemConstants;

    public class ItemEditViewModel
    {
        //Fields
        private int id;
        private string name = string.Empty;
        private string? description = null;
        private string unit = string.Empty;
        private decimal currentQuantity = 0.00M;
        private decimal currentUnitPrice = 0.00M;
        private string userId = "";
        private string createdAt = string.Empty;
        private string lastModifiedAt = string.Empty;

        //Flags
        private bool isIdValid;
        private bool isNameValid;
        private bool isDescriptionValid;
        private bool isUnitValid;
        private bool isCurrentQuantityValid;
        private bool isCurrentUnitPriceValid;
        private bool isUserIdValid;
        private bool isCreatedAtValid;
        private bool isLastModifiedAtValid;


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

        public string CreatedAt { get => this.createdAt; set => this.createdAt = value; }

        public string LastModifiedAt { get => this.lastModifiedAt; set => this.lastModifiedAt = value; }

        public bool IsDeleted { get; set; }

        public string Unit { get => this.unit; set => this.unit = value; }

        //Methods
        public bool CheckValues()
        {
            isIdValid = this.id > 0 ? true : false;

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

            this.isUserIdValid = !string.IsNullOrWhiteSpace(this.userId);

            this.isCreatedAtValid = !string.IsNullOrWhiteSpace(this.createdAt);

            this.isLastModifiedAtValid = !string.IsNullOrWhiteSpace(this.createdAt);

            this.isUnitValid = !string.IsNullOrWhiteSpace(this.unit);

            return this.isIdValid || this.isNameValid || this.isDescriptionValid || this.isCurrentQuantityValid || this.isCurrentUnitPriceValid || this.isUserIdValid || this.isCreatedAtValid || this.isLastModifiedAtValid || this.isUnitValid;
        }
    }
}
