using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProtonMailQAAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            BaseClass protonMailBaseClass = new MainPage(driver);

            Console.WriteLine(protonMailBaseClass.AreUrlContainsKeyword("Proton"));

            driver.Close();
        }
    }
}