using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Tests
{
    public class BaseTest
    {
        protected WebDriver driver;
        private ChromeOptions options;

        [SetUp]
        public void SetUp()
        {
            this.options = new ChromeOptions();
            this.options.AddArgument("--headless");
            this.driver = new ChromeDriver(this.options);
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }
    }
}
