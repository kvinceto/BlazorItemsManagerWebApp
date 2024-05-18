namespace BlazorItemsManagerWebApp.Web.ViewModels
{
    using static Common.ApplicationConstants.ItemConstants;

    public class ItemInfoViewModel
    {
        //Fields
        private int id;
        private string name = string.Empty;
        private string description = string.Empty;
        private decimal price = 0.00M;
        private string createdAd = string.Empty;

        //Flags
        private bool isIdValid;
        private bool isNameValid;
        private bool isDescriptionValid;
        private bool isPriceValid;

        public ItemInfoViewModel()
        {

        }

        //Properties
        public int Id { get => id; set => id = value; }

        public string Name { get => name; set => name = value; }

        public string Description { get => this.description; set => this.description = value; }

        public decimal Price { get => this.price; set => this.price = value; }

        public string CreatedAd { get => this.createdAd; set => this.createdAd = value; }

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

            if (string.IsNullOrWhiteSpace(this.description) && this.description.Length > DescriptionMaxLength)
            {
                this.isDescriptionValid = false;
            }
            else
            {
                this.isDescriptionValid = true;
            }

            this.isPriceValid = this.price >= 0.00M;

            return this.isIdValid || this.isNameValid || this.isDescriptionValid || this.isPriceValid;
        }
    }
}
