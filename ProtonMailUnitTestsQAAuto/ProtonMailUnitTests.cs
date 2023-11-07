using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProtonMailQAAuto;

namespace ProtonMailUnitTestsQAAuto
{
    [TestClass]
    public class ProtonMailUnitTests

    {
        IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]

        public void CheckingLoadSite()
        {
            MainPage mainPage = new(_driver);
            mainPage.GoToLoginPage();
            Assert.IsTrue(mainPage.AreUrlContainsKeyword("login"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            Thread.Sleep(5000);
            _driver.Dispose();
        }

    }
}