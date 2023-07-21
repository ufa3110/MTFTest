namespace MTFTest.UsersModule.Views
{
    public class CredentialsView
    {
        public string UserName { get; private set; } = null!;

        public string Password { get; private set; } = null!;

        public CredentialsView(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
