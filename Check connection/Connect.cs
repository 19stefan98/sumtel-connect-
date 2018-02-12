using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Check_connection
{
    public class Connection
    {
        public IWebDriver driver { get; set; }
        public string Result { get; set; }
        public Connection(IWebDriver driver)

        {
            this.driver = driver;
        }

        public void Action()
        {
            TimeSpan timeout = new TimeSpan(00, 00, 60);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://itech:itech@saint-petersburg.sumtel.itech-test.ru/");

            var street = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"check - connection - block\"]/form/div/div[3]/div/div[1]/label/input")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", street);
            street.SendKeys("Пловдивская");
            var home = driver.FindElement(By.Name("home_corpus"));
                home.SendKeys("5");
                home.Submit(); 
            Result = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("sa-icon sa-custom"))).Text;
        }
    }
}