using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using static BlazorItemsManagerWebApp.Web.Common.ApplicationConstants.UserContants;

namespace BlazorItemsManagerWebApp.Web.ViewModels
{
    public class UserViewModel
    {
        //Fields
        private string id = "no id";
        private string email = string.Empty;
        private string password = string.Empty;
        private string role = "no role";

        //Flags
        private bool idError = false;
        private bool emailError = false;
        private bool passwordError = false;
        private bool roleError = false;

        public UserViewModel()
        {
        }

        //Properties
        public string Id
        {
            get => this.id;
            set => this.id = value;
        }

        [Required(ErrorMessage = "Invalid email")]
        public string Email
        {
            get => this.email;
            set => this.email = value;
        }

        public string Role
        {
            get => this.role;
            set => this.role = value;
        }

        [Required(ErrorMessage = "Invalid password")]
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        //Methods
        public bool CheckValues()
        {
            this.idError = string.IsNullOrWhiteSpace(this.id);


            Regex regex = new Regex(EmailRegex);
            bool match = regex.IsMatch(this.email);
            if (match && this.email.Length <= EmailMaxLength)
            {
                this.emailError = false;
            }
            else
            {
                this.emailError = true;
            }

            if (this.role.Length > RoleMaxLength || string.IsNullOrWhiteSpace(this.role))
            {
                this.roleError = true;
            }
            else
            {
                this.roleError = false;
            }


            if (this.password.Length < PasswordMinLength || this.password.Length > PasswordMaxLength)
            {
                this.passwordError = true;
            }
            else
            {
                this.passwordError = false;
            }

            return this.idError || this.emailError || this.roleError || this.passwordError;
        }
    }
}
