using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProtonMailQAAuto;
using ProtonMailQAAuto.PageObjects;

namespace ProtonMailUnitTestsQAAuto
{
    [TestClass]
    public class ProtonMailUnitTests

    {
        IWebDriver _driver;
        User _firstUser;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _firstUser = new("First person", "first_person_test");
        }

        [TestMethod]
        public void CheckOpenLoginPage()
        {
            MainPage mainPage = new(_driver); 
            var loginPage = mainPage.GoToLoginPage();
            var userPage = loginPage.LoginToMailBox(_firstUser);
            mainPage = userPage.LogoutOfUserMailBox();
            Thread.Sleep(1000);
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }


        [TestCleanup]
        public void Cleanup()
        {
            Thread.Sleep(5000);
            _driver.Dispose();
        }

    }
}