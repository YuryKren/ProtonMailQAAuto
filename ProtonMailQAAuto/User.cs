namespace ProtonMailQAAuto
{
    public class User
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _loginName;
        public string LoginMame
        {
            get { return _loginName; }
            set { _loginName = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public User(string name, string login)
        {
            UserName = name;
            LoginMame = login;
            Password = "1qaz!QAZ";
        }

    }
}
