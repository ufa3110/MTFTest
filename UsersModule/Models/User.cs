using MTFTest.UsersModule.Views;

namespace MTFTest.UsersModule.Models
{
    public class User
    {
        public int Id { get; init; }

        public string FIO { get; private set; } = null!;

        public string INN { get; private set; } = null!;

        public string Pasport { get; private set; } = null!;

        public string Phone { get; private set; } = null!;

        public string Adress { get; private set; } = null!;

        public JobTitle JobTitle { get; private set; } = default!;

        public Credentials Credentials { get; private set; } = null!;

        public void UpdateInfo(UserView userView)
        {
            this.FIO = userView.FIO;
            this.INN = userView.INN;
            this.Pasport = userView.Pasport;
            this.Phone = userView.Phone;
            this.Adress = userView.Adress;
            this.JobTitle = userView.JobTitle;
        }

        public User(Credentials credentials)
        {
            Credentials = credentials;
        }
    }
}
