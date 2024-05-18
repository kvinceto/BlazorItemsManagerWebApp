namespace BlazorItemsManagerWebApp.Web.Data.Repositories
{
    using Dapper;
    using Microsoft.Data.SqlClient;

    using Data.Models;
    using Data.Repositories.Contracts;
    using ViewModels;

    public class UserRepository : IUserRepository
    {
        private readonly IDapperContext context;

        public UserRepository(IDapperContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method returns a user info from the database
        /// </summary>
        /// <param name="email">User Email</param>
        /// <returns>UserViewModel or Null</returns>
        public async Task<UserViewModel?> GetUserByEmailAsync(string email)
        {
            using (var conection = this.context.CreateConnection())
            {
                conection.Open();

                var sql = "SELECT * FROM Users WHERE Email = @Email";

                var user = await conection.QuerySingleOrDefaultAsync<User>(sql, new { Email = email });

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return new UserViewModel()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Role = user.Role,
                        Password = user.Password
                    };
                }
            }
        }

        /// <summary>
        /// This method creates a user in the database 
        /// </summary>
        /// <param name="user">User data</param>
        /// <returns>Int: number of rows afected in the database</returns>
        public async Task<int> RegisterUserAsync(UserViewModel user)
        {
            User dbUser = new User()
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            using (var conection = this.context.CreateConnection())
            {
                conection.Open();

                var sql = "INSERT INTO Users (Id, Email, Role, Password) VALUES (@Id, @Email, @Role, @Password)";

                return await conection.ExecuteAsync(sql, dbUser);
            }
        }
    }
}