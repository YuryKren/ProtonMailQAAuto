using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProtonMailQAAuto.PageObjects;

namespace ProtonMailQAAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            BasePage protonMailBaseClass = new MainPage(driver);

            Console.WriteLine(protonMailBaseClass);

            driver.Close();
        }
    }
}