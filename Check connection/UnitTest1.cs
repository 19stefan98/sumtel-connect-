using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Check_connection
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        //[OneTimeSetUp] // вызывается перед началом запуска всех тестов
        //public void OneTimeSetUp()
        //{

        //}

        //[OneTimeTearDown] //вызывается после завершения всех тестов
        //public void OneTimeTearDown()
        //{ 

        //}

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Connection()
        {
            var actual = "Ваш дом подключен";

            Connection avto = new Connection(driver);
            avto.Action();

            Assert.AreNotEqual(avto.Result, actual);
        }
    }
}
