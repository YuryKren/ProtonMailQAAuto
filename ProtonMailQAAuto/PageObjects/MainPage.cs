using OpenQA.Selenium;

namespace ProtonMailQAAuto.PageObjects
{
    public class MainPage : BaseClass
    {
        protected IWebDriver _driver;
        const string URL_PART = "proton";
        const string NAME_PAGE = "Main page";
        const string MAIN_PAGE = "https://proton.me/";
        const string SIGN_IN_ELEMENT = "//span[contains(text(),'Sign in')]";

        public MainPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            if (driver.Url != MAIN_PAGE) 
            {
                GoToUrl(MAIN_PAGE);
            }
            CheckPageLoading(URL_PART, NAME_PAGE);
        }

        public LoginPage GoToLoginPage()
        {
            WaitAndClickOnElementByXPath(SIGN_IN_ELEMENT);
            return new LoginPage(_driver);
        }

    }
}
