using OpenQA.Selenium;

namespace ProtonMailQAAuto.PageObjects
{
    public class LoginPage : BaseClass
    {
        protected IWebDriver _driver;
        const string URL_PART = "login";
        const string NAME_PAGE = "Login page";
        const string USER_NAME_FIELD_ID = "username";
        const string PASSWORD_FIELD_ID = "password";
        const string SIGN_IN_BUTTON_XPATH = "//button[contains(text(),'Sign in')]";

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            CheckPageLoading(URL_PART, NAME_PAGE);
        }

        public UserPage LoginToMailBox(User user)
        {
            InputUserName(user.LoginMame);
            InputUserPassword(user.Password);
            ClickOnElementByXPath(SIGN_IN_BUTTON_XPATH);
            return new UserPage(_driver);
        }

        private void InputUserName(string loginName)
        {
            FindElementByIDAndInputValue(USER_NAME_FIELD_ID, loginName);
        }

        private void InputUserPassword(string password)
        {
            FindElementByIDAndInputValue(PASSWORD_FIELD_ID, password);
        }

    }
}
