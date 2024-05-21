namespace BlazorItemsManegerWebAppDevExpress.Web.ViewModels
{
    using static Common.ApplicationConstants.ItemConstants;

    public class ItemEditViewModel
    {
        //Fields
        private int id;
        private string name = string.Empty;
        private string description = string.Empty;
        private decimal price = 0.00M;

        //Flags
        private bool isIdValid;
        private bool isNameValid;
        private bool isDescriptionValid;
        private bool isPriceValid;

        public ItemEditViewModel()
        {

        }

        //Properties
        public int Id { get => id; set => id = value; }

        public string Name { get => name; set => name = value; }

        public string Description { get => description; set => description = value; }

        public decimal Price { get => price; set => price = value; }

        //Methods
        public bool CheckValues()
        {
            isIdValid = id > 0 ? true : false;

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

            return isIdValid || isNameValid || isDescriptionValid || isPriceValid;
        }
    }
}
