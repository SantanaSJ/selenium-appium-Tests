using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktopTests
{
    public class AppiumDesktopTests
    {
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;
        private const string appLocation = @"C:\Users\User\Desktop\ShortURL-DesktopClient-v1.0.net6\ShortURL-DesktopClient.exe";
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appServer = "https://shorturl.nakov.repl.co/api";

        [SetUp]
        public void SetUp()
        {
            this.options = new AppiumOptions();
            this.options.AddAdditionalCapability("app", appLocation);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Add_New_URL()
        {

            string urlToAdd = "https://url" + DateTime.Now.Ticks + ".com";
            WindowsElement inputAppUrl = this.driver.FindElementByAccessibilityId("textBoxApiUrl");
            inputAppUrl.Clear();
            inputAppUrl.SendKeys(appServer);

            WindowsElement buttonConnect = this.driver.FindElementByAccessibilityId("buttonConnect");
            buttonConnect.Click();

            Thread.Sleep(2000);

            this.driver.FindElementByAccessibilityId("buttonAdd").Click();

            this.driver.FindElementByAccessibilityId("textBoxURL").SendKeys(urlToAdd);

            this.driver.FindElementByAccessibilityId("buttonCreate").Click();


            WindowsElement resultField = this.driver.FindElementByName(urlToAdd);
            Assert.IsNotEmpty(resultField.Text);
            Assert.That(resultField.Text, Is.EqualTo(urlToAdd));

            WindowsElement windowsElement = this.driver.FindElementByAccessibilityId("FormURLBoard");
            string text = windowsElement.Text;

            Console.WriteLine(text);
        }


    }
}