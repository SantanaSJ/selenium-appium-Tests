using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class BasePage
    {

        protected readonly WebDriver driver;
        public virtual string BaseUrl { get; }

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }
       
        public void OpenPage()
        {
            this.driver.Navigate().GoToUrl(this.BaseUrl);
        }   
    }
}
