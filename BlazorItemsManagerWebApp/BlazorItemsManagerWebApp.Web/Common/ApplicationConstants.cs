namespace BlazorItemsManagerWebApp.Web.Common
{
    public static class ApplicationConstants
    {
        public static class GlobalContants
        {
            public const string RoleNameClient = "Client";
            public const string RoleNameAdmin = "Admin";
            public const string ConnectionString = @"Server=DESKTOP-O0P5VDC\\SQLEXPRESS;Database=BlazorAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";

        }

        public static class UserContants
        {
            public const string EmailRegex = @"^[\w-]+@[\w]+\.[\w]+$";
            public const int EmailMaxLength = 100;
            public const int RoleMaxLength = 50;
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 50;
        }
    }
}
