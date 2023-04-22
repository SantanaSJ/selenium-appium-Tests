using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Pages
{
    public class AddURLPage : BasePage
    {
        public AddURLPage(WebDriver driver) : base(driver)
        {
        }
        public override string BaseUrl => "https://shorturl.santanasj.repl.co/add-url";

        public IWebElement linkAddUrl => this.driver.FindElement(By.LinkText("Add URL"));
        public IWebElement inputAddUrl => this.driver.FindElement(By.Id("url"));
        public IWebElement buttonCreate => this.driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement tableLastRow => this.driver.FindElements(By.CssSelector("table > tbody > tr")).Last();
        public IWebElement tableLastRowFirstCell => tableLastRow.FindElements(By.CssSelector("td")).First();
        public IWebElement labelErrorMessage => this.driver.FindElement(By.XPath("//div[@class='err']"));

        public string urlToAdd()
        {
            return "https://url" + DateTime.Now.Ticks + ".com";
        }
        public string getTextTableLastRowFirstCell()
        {
            return this.tableLastRowFirstCell.Text;
        }
        public string getTextLabelErrorMessage()
        {
            return this.labelErrorMessage.Text;
        }
    }
}
