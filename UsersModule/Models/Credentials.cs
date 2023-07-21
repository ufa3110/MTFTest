namespace MTFTest.UsersModule.Models
{
    public class Credentials
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public override int GetHashCode()
        {
            return UserName.GetHashCode() ^ Password.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return this.GetHashCode() == obj?.GetHashCode();
        }

        public static bool operator ==(Credentials? src, object? target)
        {
            if (target == null)
            {
                if (src == null)
                    return true;
                else
                    return false;
            }
            return src!.Equals(target);
        }
        public static bool operator !=(Credentials? src, object? target)
        {
            if (target == null)
            {
                if (src == null)
                    return false;
                else
                    return true;
            }

            return !src!.Equals(target);
        }

        public Credentials(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
