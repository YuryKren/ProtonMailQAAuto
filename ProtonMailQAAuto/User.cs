using OpenQA.Selenium;
using ProtonMailQAAuto.PageObjects;

namespace ProtonMailQAAuto
{
    public class User
    {
        IWebDriver _driver;
        UserPage _page;
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
        public User(IWebDriver _driver, string name, string login)
        {
            UserName = name;
            LoginMame = login;
            Password = "1qaz!QAZ";
            this._driver = _driver;
        }

        public void CreateNewEmail(string emailOfRecipient, string subject, string mail)
        {
            _page.ClickNewMessageButton();
            _page.EnterRecipientAddress(emailOfRecipient);
            _page.EnterSubject(subject);
            _page.WriteLetter(mail);
            _page.ClickToSend();
        }

        public void GoIntoYourMailbox(IWebDriver driver)
        {
            MainPage mainPage = new(driver);
            _page = mainPage.GoToLoginPage().LoginToMailBox(this);
        }

        public MainPage LogoutFromMailbox() 
        {
            return _page.LogoutOfUserMailBox();
        }

    }
}
