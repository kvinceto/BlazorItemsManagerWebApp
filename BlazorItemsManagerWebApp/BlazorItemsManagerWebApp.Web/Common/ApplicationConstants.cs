namespace BlazorItemsManagerWebApp.Web.Common
{
    public static class ApplicationConstants
    {
        public static class GlobalContants
        {
            private static ICollection<string> unitValues =
                new SortedSet<string>
                {
                    "g",
                    "kg",
                    "lb",
                    "oz",
                    "mm",
                    "cm",
                    "m",
                    "in",
                    "ft",
                    "yd",
                    "ml",
                    "l",
                    "one piece"
                };


            public const string RoleNameClient = "Client";
            public const string RoleNameAdmin = "Admin";
            public const string ConnectionString = @"Server=DESKTOP-O0P5VDC\\SQLEXPRESS;Database=BlazorAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
            public const string DateTimeDefaultFormat = "yyyy-MM-dd HH:mm:ss";

            public static ICollection<string> UnitValues { get { return unitValues; } }
        }

        public static class UserContants
        {
            public const string EmailRegex = @"^[\w-]+@[\w]+\.[\w]+$";
            public const int EmailMaxLength = 100;
            public const int RoleMaxLength = 50;
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 50;
        }

        public static class ItemConstants
        {
            public const int NameMaxLength = 100;
            public const int DescriptionMaxLength = 255;
        }
    }
}
