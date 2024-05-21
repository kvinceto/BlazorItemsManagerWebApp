namespace BlazorItemsManegerWebAppDevExpress.Web.ViewModels
{
    using static Common.ApplicationConstants.ItemConstants;
    public class ItemAddViewModel
    {
        //Fields
        private string name = string.Empty;
        private string description = string.Empty;
        private decimal price = 0.00M;

        //Flags
        private bool isNameValid;
        private bool isDescriptionValid;
        private bool isPriceValid;

        public ItemAddViewModel()
        { }

        //Properties
        public string Name { get => name; set => name = value; }

        public string Description { get => description; set => description = value; }

        public decimal Price { get => price; set => price = value; }

        //Methods
        public bool CheckValues()
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > NameMaxLength)
            {
                isNameValid = false;
            }
            else
            {
                isNameValid = true;
            }

            if (string.IsNullOrWhiteSpace(description) && description.Length > DescriptionMaxLength)
            {
                isDescriptionValid = false;
            }
            else
            {
                isDescriptionValid = true;
            }

            isPriceValid = price >= 0.00M;

            return isNameValid || isDescriptionValid || isPriceValid;
        }
    }
}
