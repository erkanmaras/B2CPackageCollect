namespace B2CPackageCollect
{
   public class User
    {
        public User(string serverName, string databaseName, string userName, string password)
        {
           ServerName = serverName;
           DatabaseName = databaseName;
           UserName = userName;
           Password = password;
        }

        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
