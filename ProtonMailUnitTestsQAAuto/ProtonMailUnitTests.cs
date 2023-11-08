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
        User _secondUser;
        string firstUserEmail = "first_person_test@proton.me";
        string secondUserEmail = "second_person_test@proton.me;";

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _firstUser = new("Bonnie", "first_person_test");
            _secondUser = new("Clyde", "second_person_test");
        }

        [TestMethod]
        public void ProtonMailMainHomework()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            _firstUser.CreateNewEmail(secondUserEmail);
            _firstUser.LogoutFromMailbox();
            _secondUser.GoIntoYourMailbox(_driver);
            while(_secondUser.CheckUnreadEmail() == false)
            {
                Thread.Sleep(5000);
                _driver.Navigate().Refresh();
            }
            var checkEmail = _secondUser.GetInformationFromEmail();
            Assert.IsTrue(checkEmail[0].Contains(_firstUser.UserName) & checkEmail[1].Contains("Hello"));
            _secondUser.ReplyToLetter();
            _secondUser.LogoutFromMailbox();
            _firstUser.GoIntoYourMailbox(_driver);
            while (_firstUser.CheckUnreadEmail() == false)
            {
                Thread.Sleep(5000);
                _driver.Navigate().Refresh();
            }
            checkEmail = _firstUser.GetInformationFromEmail();
            Assert.IsTrue(checkEmail[0].Contains(_secondUser.UserName) & checkEmail[1].Contains("OK"));
            _firstUser.LogoutFromMailbox();
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
            _firstUser.CreateNewEmail(secondUserEmail);
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void CheckNewEmailNegative()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            Assert.IsFalse(_firstUser.CheckUnreadEmail());
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void CheckNewEmailPositive()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            Assert.IsTrue(_firstUser.CheckUnreadEmail());
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void GetIvormationFromLetter()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            List<string> list = _firstUser.GetInformationFromEmail();
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            Assert.IsTrue(list.Count == 2);
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void ReplyToLetter()
        {
            _firstUser.GoIntoYourMailbox(_driver);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            _firstUser.ReplyToLetter();
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }

    }
}