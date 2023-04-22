using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Pages
{
    public class ShortURLPage : BasePage
    {
        public ShortURLPage(WebDriver driver) : base(driver)
        {
        }
        public override string BaseUrl => "https://shorturl.santanasj.repl.co/urls";
        public IWebElement ShortUrlLink => this.driver.FindElement(By.LinkText("Short URLs"));
        public IWebElement tableHeaderLeftCell => this.driver.FindElement(By.CssSelector("th:nth-child(1"));
        public IWebElement tableFirstRow => this.driver.FindElements(By.CssSelector("table > tbody > tr")).First();
        public IWebElement oldCounter => tableFirstRow.FindElements(By.CssSelector("td")).Last();
        public IWebElement linkToClickCell => tableFirstRow.FindElements(By.CssSelector("td"))[1];
        public IWebElement linkToClick => linkToClickCell.FindElement(By.TagName("a"));
        public IWebElement newCounter => tableFirstRow.FindElements(By.CssSelector("td")).Last();

        public string GetTableHeaderText()
        {
            return this.tableHeaderLeftCell.Text;
        }
        public int getOldCounterNumber()
        {
            return int.Parse(oldCounter.Text);
        }
        public int getNewCounterNumber()
        {
            return int.Parse(newCounter.Text);
        }
    }
}
