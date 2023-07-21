using Microsoft.AspNetCore.SignalR;
using MTFTest.UsersModule.Abstractions;
using MTFTest.UsersModule.Models;
using MTFTest.UsersModule.Views;

namespace MTFTest.UsersModule.Service
{
    //TODO: тесты, документация (о чем не было написано в ТЗ, и не делалось в целях экономии времени).
    public class UserService : Hub
    {
        private readonly IUsersRepository _usersRepository;

        public async Task Identify(string user, string password)
        {
            //TODO MediatR.
            var status = IdentifyStatus.InProgress;
            await Clients.Caller.SendAsync("IdentifyStatus", status);

            var identifyResult = await  _usersRepository.Identify(new CredentialsView(user, password));

            if (identifyResult)
            {
                status = IdentifyStatus.Success;
                await Clients.Caller.SendAsync("IdentifyStatus", status);
            }
            else
            {
                status = IdentifyStatus.Exception;
                await Clients.Caller.SendAsync("IdentifyStatus", status);
            }

            return;
        }

        public async Task Register(string user, string password)
        {
            //TODO MediatR.

            var result = await _usersRepository.Register(user, password);
            await Clients.Caller.SendAsync("Registered", result);
            return;
        }

        public async Task UpdateInfo(int userid, string fio, string inn, string pasport, string phone, string adress, JobTitle jobTitle)
        {
            //TODO принимать viewModel во входящий аргумент.
            var model = await _usersRepository.GetUserById(userid);
            model.UpdateInfo(new UserView(fio, inn, pasport, phone, adress, jobTitle));
            await Clients.Caller.SendAsync("Updated");
        }

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
    }
}
