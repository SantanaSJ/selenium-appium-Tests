using OpenQA.Selenium;
using SeleniumTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class ShortURLTests : BaseTest
    {
        private ShortURLPage page;
        private const string originalURLText = "Original URL";

        [SetUp]
        public void SetUp()
        {
            this.page = new ShortURLPage(this.driver);
            this.page.OpenPage();
        }

        [Test]
        public void Test_Table_Top_Left_Cell()
        {
            this.page.ShortUrlLink.Click();

            Assert.That(this.page.GetTableHeaderText, Is.EqualTo(originalURLText));
        }
        [Test]
        public void Test_Counter_Increase()
        {
            int oldCounterNumber = this.page.getOldCounterNumber();
            this.page.linkToClick.Click();
            this.driver.SwitchTo().Window(this.driver.WindowHandles[0]);

            this.driver.Navigate().Refresh();
            int newCounterNumber = this.page.getNewCounterNumber();

            Assert.That(newCounterNumber, Is.EqualTo(oldCounterNumber + 1));
        }

    }
}
