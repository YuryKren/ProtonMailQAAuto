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
        MainPage _mainPage;
        string secondUserEmail = "second_person_test@proton.me;";

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
            _firstUser = new("Bonnie", "first_person_test");
            _secondUser = new("Clyde", "second_person_test");
        }

        [TestMethod]
        public void ProtonMailMainHomework()
        {
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
            _firstUser.CreateNewEmail(secondUserEmail);
            _mainPage= _firstUser.LogoutFromMailbox();
            _secondUser.GoIntoYourMailbox(_driver, _mainPage);
            while(_secondUser.CheckUnreadEmail() == false)
            {
                Thread.Sleep(3000);
                _secondUser.RefreshYourMailbox();
                Thread.Sleep(3000);
            }
            var checkEmail = _secondUser.GetInformationFromEmail();
            Assert.IsTrue(checkEmail[0].Contains(_firstUser.UserName) && checkEmail[1].Contains("Hello"));
            _secondUser.ReplyToLetter();
            _mainPage = _secondUser.LogoutFromMailbox();
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
            while (_firstUser.CheckUnreadEmail() == false)
            {
                Thread.Sleep(3000);
                _firstUser.RefreshYourMailbox();
                Thread.Sleep(3000);
            }
            checkEmail = _firstUser.GetInformationFromEmail();
            Assert.IsTrue(checkEmail[0].Contains(_firstUser.UserName) && checkEmail[1].Contains("OK"));
            _firstUser.LogoutFromMailbox();
        }

        [TestMethod]
        public void CheckLoginAndLogoutMailbox()
        {
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            Thread.Sleep(3000);
            _mainPage = _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void CheckSendEmail()
        {
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            _firstUser.CreateNewEmail(secondUserEmail);
            _mainPage = _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void CheckNewEmailNegative()
        {
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            Assert.IsFalse(_firstUser.CheckUnreadEmail());
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void CheckNewEmailPositive()
        {
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
            Assert.IsTrue(_driver.Url.Contains("inbox"));
            Assert.IsTrue(_firstUser.CheckUnreadEmail());
            _firstUser.LogoutFromMailbox();
            Assert.IsTrue(_driver.Url.Contains("proton"));
        }

        [TestMethod]
        public void GetInformationFromLetter()
        {
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
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
            _firstUser.GoIntoYourMailbox(_driver, _mainPage);
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