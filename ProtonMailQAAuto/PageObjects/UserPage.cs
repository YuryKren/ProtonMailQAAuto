using OpenQA.Selenium;

namespace ProtonMailQAAuto.PageObjects
{
    public class UserPage : BaseClass
    {
        protected IWebDriver _driver;
        const string URL_PART = "inbox";
        const string NAME_PAGE = "User page";
        const string SETTINGS_MENU_XPATH = "//button[@data-testid='heading:userdropdown']";
        const string LOGOUT_BUTTON_XPATH = "//button[contains(text(),'Sign out')]";

        public UserPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            CheckPageLoading(URL_PART, NAME_PAGE);
            DelayForLoadingPage("//button");
        }

        public MainPage LogoutOfUserMailBox()
        {
            WaitAndClickOnElementByXPath(SETTINGS_MENU_XPATH);
            Console.WriteLine("User settings menu opened");
            WaitAndClickOnElementByXPath(LOGOUT_BUTTON_XPATH);
            return new MainPage(_driver);
        }

    }
}
