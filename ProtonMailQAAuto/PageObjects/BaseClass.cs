using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ProtonMailQAAuto.PageObjects
{
    public abstract class BaseClass
    {
        protected IWebDriver _driver;
        protected WebDriverWait _waiter;
        const string BUTTON_TO_AGREE_WITH_CHANGES = "//button[text()='Continue']";

        public BaseClass(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Manage().Window.Maximize();
            _waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }

        public void GoToUrl(string url)
        {
            _driver.Url = url;
        }

        public void WaitAndClickOnElementByXPath(string xPath)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
            webElement.Click();
        }

        public void ClickOnElementByXPath(string xPath)
        {
            IWebElement webElement = _driver.FindElement(By.XPath(xPath));
            webElement.Click();
        }

        public void ClickOnElementByClass(string className)
        {
            IWebElement webElement = _driver.FindElement(By.ClassName(className));
            webElement.Click();
        }

        public void FindElementByXPathAndInputValue(string xPath, string value)
        {
            IWebElement webElement = _driver.FindElement(By.XPath(xPath));
            webElement.SendKeys(value);
        }

        public void FindElementByIDAndInputValue(string id, string value)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementExists(By.Id(id)));
            webElement.SendKeys(value);
        }

        public ReadOnlyCollection<IWebElement> GetElementsByXPath(string xPath)
        {
            return _waiter.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
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

        public void ClickAgreeWithOnConditions()
        {
            var foundElements = _driver.FindElements(By.XPath(BUTTON_TO_AGREE_WITH_CHANGES));
            if (foundElements.Count() != 0)
            {
                foundElements[0].Click();
            }
            else
            {
                Console.WriteLine("There isn't Button \"Agree with the conditions\" ");
            }
        }

        public int CheckCountOfSearchResults(IWebElement countOfResultsString)
        {
            string[] findingNumber = countOfResultsString.Text.Split(' ');
            int n = 0;
            foreach (string part in findingNumber)
            {
                bool success = int.TryParse(part, out n);
                if (success)
                {
                    n = int.Parse(part);
                    break;
                }
            }
            return n;
        }

        public List<string> ConvertCollectionFromWebElementToString(ReadOnlyCollection<IWebElement> collection)
        {
            List<string> textResult = new(collection.Select(x => x.Text));
            return textResult;
        }

        public void DelayForLoadingPage(string xPath)
        {
            _waiter.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
        }
    }
}
