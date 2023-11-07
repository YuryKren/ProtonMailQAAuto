using OpenQA.Selenium;

namespace ProtonMailQAAuto.PageObjects
{
    public class UserPage : BaseClass
    {
        IWebDriver _driver;
        const string URL_PART = "inbox";
        const string NAME_PAGE = "User page";
        const string SETTINGS_MENU = "//button[@data-testid='heading:userdropdown']";
        const string LOGOUT_BUTTON = "//button[contains(text(),'Sign out')]";
        const string NEW_MESSAGE_BUTTON = "//button[contains(text(),'New message')]";
        const string RECIPIENT_ADDRESS_INPUT_FIELD = "//input[@placeholder='Email address']";
        const string SUBJECT_INPUT_FIELD = "//input[@placeholder='Subject']";
        const string OPTION_FOR_LETTER_FIELD_BUTTON = "//button[@data-testid='composer:more-options-button']";
        const string CHANGE_TYPE_LETTER_FIELD_BUTTON = "//button[@data-testid='editor-to-plaintext']";
        const string LETTER_INPUT_FIELD = "//textarea";
        const string SEND_BUTTON = "//button[@data-testid='composer:send-button']";


        public UserPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            CheckPageLoading(URL_PART, NAME_PAGE);
            DelayForLoadingPage("button");
        }

        public MainPage LogoutOfUserMailBox()
        {
            WaitAndClickOnElementByXPath(SETTINGS_MENU);
            Console.WriteLine("User settings menu opened");
            WaitAndClickOnElementByXPath(LOGOUT_BUTTON);
            return new MainPage(_driver);
        }

        internal void ClickNewMessageButton()
        {
            ClickOnElementByXPath(NEW_MESSAGE_BUTTON);
            Console.WriteLine("New Message");
        }

        internal void EnterRecipientAddress(string emailOfRecipient)
        {
            FindElementByXPathAndInputValue(RECIPIENT_ADDRESS_INPUT_FIELD, emailOfRecipient);
            Console.WriteLine("Enter Recipient Address");
        }

        internal void EnterSubject(string subject)
        {
            FindElementByXPathAndInputValue(SUBJECT_INPUT_FIELD, subject);
            Console.WriteLine("Enter Subject");
        }

        internal void WriteLetter(string mail)
        {
            ClickOnElementByXPath(OPTION_FOR_LETTER_FIELD_BUTTON);
            WaitAndClickOnElementByXPath(CHANGE_TYPE_LETTER_FIELD_BUTTON);
            FindElementByXPathAndInputValue(LETTER_INPUT_FIELD, mail);
        }

        internal void ClickToSend()
        {
            ClickOnElementByXPath(SEND_BUTTON);
            Console.WriteLine("Send mail");
        }


    }
}
