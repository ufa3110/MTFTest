using MTFTest.UsersModule.Models;
using MTFTest.UsersModule.Views;

namespace MTFTest.UsersModule.Abstractions
{
    public interface IUsersRepository
    {
        Task<bool> Identify(CredentialsView credentials);
        Task<User> GetUserById(int id);
        Task<int> Register(string userName, string password);
        Task UpdateUserInformation(UserView userView, int userId);
    }
}