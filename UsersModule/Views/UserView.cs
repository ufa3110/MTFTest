using MTFTest.UsersModule.Models;

namespace MTFTest.UsersModule.Views
{
    public class UserView
    {
        public string FIO { get; private set; } = null!;

        public string INN { get; private set; } = null!;

        public string Pasport { get; private set; } = null!;

        public string Phone { get; private set; } = null!;

        public string Adress { get; private set; } = null!;

        public JobTitle JobTitle { get; private set; } = default!;

        public UserView(string fIO, string iNN, string pasport, string phone, string adress, JobTitle jobTitle)
        {
            //TODO: FluentValidation
            FIO = fIO;
            INN = iNN;
            Pasport = pasport;
            Phone = phone;
            Adress = adress;
            JobTitle = jobTitle;
        }
    }
}
