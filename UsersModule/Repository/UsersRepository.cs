using AutoMapper;
using MTFTest.UsersModule.Abstractions;
using MTFTest.UsersModule.Models;
using MTFTest.UsersModule.Views;
using System.Security.Authentication;

namespace MTFTest.UsersModule.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMapper _mapper;

        //TODO: если и дальше работать с users в памяти, то лучше бы юзать Dictionary<(id),user>
        //но т.к. предполагается, что это сущность в БД, то в данном случае это была бы преждевременная оптимизация.
        private List<User> Users = new();

        public async Task<int> Register(string userName, string password)
        {
            //TODO fluent validation and string is null or empty rule.
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (Users.Any(u => u.Credentials.UserName == userName))
            {
                throw new InvalidCredentialException();
            }

            //TODO: убрать присвоение id при переходе на EFCore.
            //решил не использовать упрощенные конструкторы new(new(username,password) - имхо ТУТ вредит читаемости.
            var registeredUser = new User(new Credentials(userName, password))
            {
                Id = Users.Any() ? Users.Max(u => u.Id) + 1 : 1
            };
            Users.Add(registeredUser);
            return registeredUser.Id;
        }

        public async Task UpdateUserInformation(UserView userView, int userId)
        {
            var user = await GetUserById(userId);
            user.UpdateInfo(userView);
        }

        public async Task<bool> Identify(CredentialsView credentials)
        {
            Thread.Sleep(2000);

            //переопределил equals (и ==) у credentials.
            //решил не переопределять equals и у credentialsView, а использовать автомаппер.
            return Users.Any(u => u.Credentials == _mapper.Map<Credentials>(credentials));
        }

        public async Task<User> GetUserById(int id)
        {
            return Users.Single(u => u.Id == id);
        }

        public UsersRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
