using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;

namespace SeleniumTests.Tests
{
    public class AddURLTest : BaseTest
    {
        private AddURLPage page;
        private const string invalidURL = "alabala";
        private const string nonExistingURLErrorMessage = "Cannot navigate to given short URL";
        private const string URLNotDisplayedErrorMessage = "Error message is not displayed";
        private const string invalidURLErrorMessage = "Invalid URL!";
        private const string nonExistingURL = "http://shorturl.nakov.repl.co/go/invalid536524";


        [SetUp]
        public void SetUp()
        {
            this.page = new AddURLPage(this.driver);
            this.page.OpenPage();
        }

        [Test]
        public void Test_Add_Valid_Url()
        {
            this.page.linkAddUrl.Click();

            string URLToAdd = this.page.urlToAdd();
            this.page.inputAddUrl.SendKeys(URLToAdd);

            this.page.buttonCreate.Click();

            Assert.That(this.driver.PageSource.Contains(URLToAdd));
            Assert.That(this.page.getTextTableLastRowFirstCell, Is.EqualTo(URLToAdd));
        }

        [Test]
        public void Test_Add_Invalid_Url()
        {
            this.page.inputAddUrl.SendKeys(invalidURL);
            this.page.buttonCreate.Click();

            Assert.That(this.page.getTextLabelErrorMessage, Is.EqualTo(invalidURLErrorMessage));
        }

        [Test]
        public void Test_Visit_Not_Existing_Url()
        {
            this.driver.Url = nonExistingURL;

            Assert.That(this.page.getTextLabelErrorMessage, Is.EqualTo(nonExistingURLErrorMessage));
            Assert.That(this.page.labelErrorMessage.Displayed, URLNotDisplayedErrorMessage);
        }
    }
}