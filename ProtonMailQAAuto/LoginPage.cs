using OpenQA.Selenium;

namespace ProtonMailQAAuto
{
    public class LoginPage : BaseClass
    {
        const string MAIN_PAGE = "https://proton.me/";
        const string SIGN_IN_ELEMENT = "//span[contains(text(),'Sign in')]";

        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            GoToUrl(MAIN_PAGE);
        }

        public void GoToLoginPage()
        {
            WaitAndClickOnElement(SIGN_IN_ELEMENT);
        }
    }
}
