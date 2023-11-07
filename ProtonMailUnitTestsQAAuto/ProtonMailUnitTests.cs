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
        string firstUserEmail = "first_person_test@proton.me";
        string secondUserEmail = "second_person_test@proton.me;";
        string subject = "Test letter";
        string mail = "Hello, my friend!";

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _firstUser = new(_driver, "First person", "first_person_test");
        }

        [TestMethod]
        public void CheckOpenLoginPage()
        {
            MainPage mainPage = new(_driver); 
            var loginPage = mainPage.GoToLoginPage();
            Assert.IsTrue(_driver.Url.Contains("login"));
        }

        [TestMethod]
        public void CheckLoginAndLogoutMailbox()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            Thread.Sleep(3000);
            var mainPage = _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]

        public void CheckSendEmail()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            _firstUser.CreateNewEmail(secondUserEmail, subject, mail);

        }


        [TestCleanup]
        public void Cleanup()
        {
            _firstUser.LogoutFromMailbox();
            _driver.Dispose();
        }

    }
}