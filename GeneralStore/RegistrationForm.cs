using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;


namespace GeneralStore

{

    [TestFixture]

    public class RegistrationFormTest

    {

        private AndroidDriver driver;
        private WebDriverWait wait;


        [SetUp]

        public void SetUp()

       {

            var capabilities = new AppiumOptions();

            // capabilities.AddAdditionalAppiumOption("platformName", "Android");

            // capabilities.AddAdditionalAppiumOption("deviceName", "device");
            capabilities.PlatformName = "Android";
            capabilities.DeviceName = "device";
            capabilities.AutomationName = "UIAutomator2";

            capabilities.AddAdditionalAppiumOption("appPackage", "com.androidsample.generalstore");

            capabilities.AddAdditionalAppiumOption("appActivity", ".SplashActivity");

            // capabilities.AddAdditionalAppiumOption("automationName", "UIAutomator2");
 
            driver = new AndroidDriver(

                new Uri("http://localhost:4723/wd/hub"),

                capabilities,

                TimeSpan.FromSeconds(180)

            );}

        [Test]

        public void VerifySelectCountryText()

        {

            string expectedResultText = "Select the country where you want to shop";



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
var selectCountryText = wait.Until(drv => drv.FindElement(By.XPath("//android.widget.TextView[@text='Select the country where you want to shop']")));

            string actualResultText = selectCountryText.Text;

            if (actualResultText.Equals(expectedResultText))

            {

                TestContext.WriteLine("Text 'Select the country where you want to shop' is correct");

                TestContext.WriteLine("Element text: " + selectCountryText.Text);

            }

            else

            {

                TestContext.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not correct!!!");

                TestContext.WriteLine("Element text: " + selectCountryText.Text);

            }

            Assert.That(expectedResultText, Is.EqualTo(actualResultText),

                "Text does not match the expected 'Select the country where you want to shop'");

        }
        [Test]
    public void Country_Afghanistan_HasCorrectProperties()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
var country = wait.Until(drv => drv.FindElement(By.XPath("//android.widget.TextView[@resource-id='android:id/text1']")));
 
       
        VerifyCountryProperties(country);
    }

        public static void VerifyCountryProperties(IWebElement country)
        {
            string expectedCountryText = "Afghanistan";
            string actualCountryText = country.Text;


            Assert.That(expectedCountryText, Is.EqualTo(actualCountryText), "Country name is incorrect.");
            TestContext.WriteLine("Country text is correct.");


            Assert.That(country.Displayed, "Country is not displayed.");
            TestContext.WriteLine("Country is displayed.");


            Assert.That(country.Enabled, "Country is not enabled.");
            TestContext.WriteLine("Country is enabled.");


            string clickable = country.GetAttribute("clickable");
            Assert.That(clickable, Is.EqualTo("false"), "Country is clickable but should not be.");
            TestContext.WriteLine("Country is not clickable.");


            string focusable = country.GetAttribute("focusable");
            Assert.That(focusable, Is.EqualTo("false"), "Country is focusable but should not be.");
            TestContext.WriteLine("Country is not focusable.");


            string focused = country.GetAttribute("focused");
            Assert.That(focused, Is.EqualTo("false"), "Country is focused but should not be.");
            TestContext.WriteLine("Country is not focused.");


            string scrollable = country.GetAttribute("scrollable");
            Assert.That(scrollable, Is.EqualTo("false"), "Country is scrollable but should not be.");
            TestContext.WriteLine("Country is not scrollable.");


            string selected = country.GetAttribute("selected");
            Assert.That(selected, Is.EqualTo("false"), "Country is selected but should not be.");
            TestContext.WriteLine("Country is not selected.");


            string checkedAttr = country.GetAttribute("checked");
            Assert.That(checkedAttr, Is.EqualTo("false"), "Country is checked but should not be.");
            TestContext.WriteLine("Country is not checked.");
    }


       [Test]
        public void ChooseUrkaineTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var spinner = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/spinnerCountry")));
            spinner.Click();
            var urkaineElement = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().className(\"android.widget.ListView\")).scrollIntoView(new UiSelector().text(\"Ukraine\"))"));
            urkaineElement.Click();
            var selectedCountry = wait.Until(d => d.FindElement(By.Id("android:id/text1")));
            Assert.That("Ukraine", Is.EqualTo(selectedCountry.Text));
        }
        [Test]
        public void BackgoundImageTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var backgroundImage = wait.Until(d => d.FindElement(By.ClassName("android.widget.ImageView")));
            Assert.That(backgroundImage.Displayed, Is.True, "Background image is not displayed.");
            TestContext.WriteLine("Background image is displayed.");
        }
        [Test]
        public void ToolBarTitleTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var toolBarTitle = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/toolbar_title")));
            Assert.That(toolBarTitle.Text, Is.EqualTo("General Store"), "Toolbar title is not correct.");
            TestContext.WriteLine("Toolbar title is correct: " + toolBarTitle.Text);
        }
        [Test]
        public void NameFieldTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var nameField = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/nameField")));
            Assert.That(nameField.Displayed, Is.True, "Name field is not displayed.");
            Assert.That(nameField.Enabled, Is.True, "Name field is not enabled.");
            nameField.SendKeys("Test User");
            Assert.That(nameField.GetAttribute("text"), Is.EqualTo("Test User"), "Name field text is not set correctly.");
            TestContext.WriteLine("Name field text is set to: " + nameField.GetAttribute("text"));
            TestContext.WriteLine("Name field is displayed and enabled.");
        }
        [Test]
        public void RadioButtonsTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var radioButtonMale = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/radioMale")));
            Assert.That(radioButtonMale.Displayed, Is.True, "Radio button is not displayed.");
            Assert.That(radioButtonMale.Enabled, Is.True, "Radio button is not enabled.");
            Assert.That(radioButtonMale.GetAttribute("checked"), Is.EqualTo("true"), "Radio button is selected by default.");
            var radioButtonFemale = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/radioFemale")));
            Assert.That(radioButtonFemale.Displayed, Is.True, "Radio button is not displayed.");
            Assert.That(radioButtonFemale.Enabled, Is.True, "Radio button is not enabled.");
            Assert.That(radioButtonFemale.GetAttribute("checked"), Is.EqualTo("false"), "Radio button is not selected by default.");
            radioButtonFemale.Click();
            Assert.That(radioButtonFemale.GetAttribute("checked"), Is.EqualTo("true"), "Radio button is not selected after clicking.");
            Assert.That(radioButtonMale.GetAttribute("checked"), Is.EqualTo("false"), "Radio button is not selected after clicking the other one.");
            radioButtonMale.Click();
            Assert.That(radioButtonMale.GetAttribute("checked"), Is.EqualTo("true"), "Radio button is selected after clicking.");
            Assert.That(radioButtonFemale.GetAttribute("checked"), Is.EqualTo("false"), "Radio button is not selected after clicking the other one.");
            TestContext.WriteLine("Radio button is displayed, enabled, and selected.");
        }
        [Test]
        public void LetsShopButtonTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var letsShopButton = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop")));
            Assert.That(letsShopButton.Displayed, Is.True, "Let's Shop button is not displayed.");
            Assert.That(letsShopButton.Enabled, Is.True, "Let's Shop button is not enabled.");
            Assert.That(letsShopButton.GetAttribute("clickable"), Is.EqualTo("true"), "Let's Shop button is not clickable.");
            Assert.That(letsShopButton.Text, Is.EqualTo("Let's  Shop"), "Let's Shop button text is not correct.");
            TestContext.WriteLine("Let's Shop button is displayed, enabled, and clicked.");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver?.Quit();
                driver?.Dispose();
            }
        }

    }

}
