﻿namespace BlazorItemsManagerWebApp.Web.ViewModels
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
        {}

        //Properties
        public string Name { get => name; set => name = value; }

        public string Description { get => this.description; set => this.description = value; }

        public decimal Price { get => this.price; set => this.price = value; }

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

            if (string.IsNullOrWhiteSpace(this.description) && this.description.Length > DescriptionMaxLength)
            {
                this.isDescriptionValid = false;
            }
            else
            {
                this.isDescriptionValid = true;
            }

            this.isPriceValid = this.price >= 0.00M;

            return this.isNameValid || this.isDescriptionValid || this.isPriceValid;
        }
    }
}
