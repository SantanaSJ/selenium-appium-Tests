using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests
{
    public class AppiumMobileTests
    {
       private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string appLocation = @"C:\Users\User\Desktop\com.android.example.github.apk";
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";

        [SetUp]
        public void SetUp()
        {
            this.options = new AppiumOptions() {  PlatformName = "Android"};
            this.options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Verify_Barancef_Name()
        {
            AndroidElement inputSearchField = this.driver.FindElement(By.Id("com.android.example.github:id/input"));
            inputSearchField.Click();
            inputSearchField.SendKeys("Selenium");

            this.driver.PressKeyCode(AndroidKeyCode.Enter);

            AndroidElement textSelenium = this.driver.FindElement(By.XPath("//android.view.ViewGroup/android.widget.TextView[2]"));
            Assert.That(textSelenium.Text, Is.EqualTo("SeleniumHQ/selenium"));

            textSelenium.Click();
            AndroidElement listTextBarancev = this.driver.FindElement(By.XPath("//android.widget.FrameLayout[2]/android.view.ViewGroup/android.widget.TextView"));
            Assert.That(listTextBarancev.Text, Is.EqualTo("barancev"));

            listTextBarancev.Click();

            AndroidElement textFieldBarancev = this.driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"user name\"]"));
            Assert.That(textFieldBarancev.Text, Is.EqualTo("Alexei Barantsev"));
        }
    }
}