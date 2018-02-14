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
            TimeSpan timeout = new TimeSpan(00, 00, 10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://itech:itech@saint-petersburg.sumtel.itech-test.ru/");

            var street = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"check-connection-block\"]/form/div/div[4]/div/div[1]/label/input")));
                street.SendKeys("Пловдивская");
            var home = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"check-connection-block\"]/form/div/div[4]/div/div[2]/label/input")));
                home.SendKeys("1/10");
                home.Submit();
            Result = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"body\"]/div[5]/div[5]"))).Text;
        }
    }
}