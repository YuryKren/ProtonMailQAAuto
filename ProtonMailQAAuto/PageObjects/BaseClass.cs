using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace ProtonMailQAAuto.PageObjects
{
    public abstract class BaseClass
    {
        IWebDriver _driver;
        WebDriverWait _waiter;
        const string BUTTON_TO_AGREE_WITH_CHANGES = "//button[text()='Continue']";
        Actions _actions;

        public BaseClass(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Manage().Window.Maximize();
            _waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            _actions = new Actions(_driver);
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

        public void ClickOnElementByClass(string className)
        {
            IWebElement webElement = _driver.FindElement(By.ClassName(className));
            webElement.Click();
        }

        public void FindElementByXPathAndInputValue(string xPath, string value)
        {
            IWebElement webElement = _waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            webElement.SendKeys(value);
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

        public void DelayForLoadingPage(string tagName)
        {
            _waiter.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName(tagName)));
        }


    }
}
