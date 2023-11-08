using OpenQA.Selenium;
using ProtonMailQAAuto.PageObjects;

namespace ProtonMailQAAuto
{
    public class User
    {
        UserPage _page;
        private string _subject;
        private string _firstMessage;
        private string _secondMessage;
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
            FillInTheFieldsOfEMAL(name);
        }

        private void FillInTheFieldsOfEMAL(string name)
        {
            _subject = $"Letter from {name}";
            _firstMessage = $"Hello my dear friend! It's me, {name}";
            _secondMessage = $"OK, and this is me, {name}";
        }

        public void CreateNewEmail(string emailOfRecipient)
        {
            _page.ClickNewMessageButton();
            _page.EnterRecipientAddress(emailOfRecipient);
            _page.EnterSubject(_subject);
            _page.WriteLetter(_firstMessage);
            _page.ClickToSend();
            Thread.Sleep(3000);
        }

        public void ReplyToLetter()
        {
            _page.ClickToReply();
            _page.WriteLetter(_secondMessage);
            _page.ClickToSend();
            Thread.Sleep(3000);
        }

        public void GoIntoYourMailbox(IWebDriver driver, MainPage mainPage)
        {
            //MainPage mainPage = new(driver);
            _page = mainPage.GoToLoginPage().LoginToMailBox(this);
        }

        public bool CheckUnreadEmail()
        {
            _page.ClickUnreadLetter();

            return _page.CheckNewEmail();
        }

        public List<string> GetInformationFromEmail()
        {
            _page.OpenListEmails();
            List<string> result = new List<string>();
            string title = _page.GetTitle();
            result.Add(title);
            Console.WriteLine($"The title: {title}");
            result.Add(_page.GetEmail());
            return result;
        }

        public void RefreshYourMailbox() 
        { 
            _page.RefreshMailbox();
        }

        public MainPage LogoutFromMailbox() 
        {
            return _page.LogoutOfUserMailBox();
        }

    }
}
