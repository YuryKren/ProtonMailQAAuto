using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ProtonMailQAAuto.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        WebDriverWait _waiter;
        public BasePage(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Manage().Window.Maximize();
            _waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }

        public void GoToUrl(string url)
        {
            _driver.Url = url;
        }

        public void WaitAndClickOnElementByXPath(string xPath)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            webElement.Click();
        }

        public void ClickOnElementByXPath(string xPath)
        {
            IWebElement webElement = _driver.FindElement(By.XPath(xPath));
            webElement.Click();
        }

        public void FindElementByXPathAndInputValue(string xPath, string value)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            webElement.SendKeys(value);
        }

        public void ClearElementByXPathAndInputValue(string xPath, string value)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            webElement.Clear();
            webElement.SendKeys(value + "  Sent with ISsoft");
        }

        public void FindElementByIDAndInputValue(string id, string value)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            webElement.SendKeys(value);
        }

        public IWebElement GetElementByXPath(string xPath)
        {
            return _driver.FindElement(By.XPath(xPath));
        }

        public void CheckPageLoading(string keyword, string namePage)
        {
            _waiter.Until(ExpectedConditions.UrlContains(keyword));
            string pageUrl = _driver.Url;
            if (pageUrl.Contains(keyword))
            {
                Console.WriteLine($"{namePage} loaded");
            }
            else { throw new Exception($"{namePage} didn't load"); }
        }

        public bool CheckElementPresence(string xPath)
        {
            var foundElements = _driver.FindElements(By.XPath(xPath));
            if (foundElements.Count() != 0)
            {
                Console.WriteLine("You have new emails!");
                return true;
            }
            else
            {
                Console.WriteLine("There aren't new emails");
                return false;
            }
        }

        public string ChangeFrameAndGetElement(string iFrame, string xPath)
        {
            Thread.Sleep(1000);
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(iFrame)));
            var webElement = _driver.FindElement(By.XPath(xPath));
            string textEmail = webElement.Text;
            _driver.SwitchTo().DefaultContent();
            return textEmail;
        }

        public void DelayForLoadingPage(string xPath)
        {
            _waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

    }
}
