using OpenQA.Selenium;

namespace ProtonMailQAAuto
{
    public class MainPage : BaseClass
    {
        protected IWebDriver _driver;
        const string MAIN_PAGE = "https://proton.me/";
        const string SIGN_IN_ELEMENT = "//span[contains(text(),'Sign in')]";

        public MainPage(IWebDriver driver) : base(driver) 
        {
            _driver = driver;
            GoToUrl(MAIN_PAGE);
        }

        public LoginPage GoToLoginPage()
        {
            WaitAndClickOnElement(SIGN_IN_ELEMENT);
            return new LoginPage(_driver);
        }

    }
}
