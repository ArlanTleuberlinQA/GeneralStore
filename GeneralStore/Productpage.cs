using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;


namespace ProductPage

{

    [TestFixture]

    public class ProductPageTest

    {

        private AndroidDriver driver;
        private WebDriverWait? wait;


        [SetUp]

        public void SetUp()

       {

            var capabilities = new AppiumOptions();

            capabilities.PlatformName = "Android";
            capabilities.DeviceName = "device";
            capabilities.AutomationName = "UIAutomator2";
            capabilities.AddAdditionalAppiumOption("appPackage", "com.androidsample.generalstore");
            capabilities.AddAdditionalAppiumOption("appActivity", ".SplashActivity");
 
            driver = new AndroidDriver(

                new Uri("http://localhost:4723/wd/hub"),

                capabilities,

                TimeSpan.FromSeconds(180)

            );}
        [Test]
        public void LogInToProductPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var letsShopButton = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop")));
            var nameField = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/nameField")));

            Assert.That(nameField.Displayed, Is.True, "Name field is not displayed.");
            Assert.That(nameField.Enabled, Is.True, "Name field is not enabled.");

            Assert.That(letsShopButton.Displayed, Is.True, "Let's Shop button is not displayed.");
            Assert.That(letsShopButton.Enabled, Is.True, "Let's Shop button is not enabled.");
            Assert.That(letsShopButton.GetAttribute("clickable"), Is.EqualTo("true"), "Let's Shop button is not clickable.");
            Assert.That(letsShopButton.Text, Is.EqualTo("Let's  Shop"), "Let's Shop button text is not correct.");
            nameField.SendKeys("Test User");
            letsShopButton.Click();

            var productsPageTitle = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/toolbar_title")));
            Assert.That(productsPageTitle.Text, Is.EqualTo("Products"), "Products page title is not correct after clicking Let's Shop button.");
            var recyclerView = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/rvProductList")));

           var parent = driver.FindElement(By.XPath("//android.support.v7.widget.RecyclerView[@resource-id='com.androidsample.generalstore:id/rvProductList']/.."));
            Assert.That(parent, Is.Not.Null, "У RecyclerView нет родительского элемента");


            var items = recyclerView.FindElements(By.XPath(".//*"));
            Assert.That(items.Count, Is.GreaterThan(0), "RecyclerView does not contain any items.");
            Console.WriteLine("Items found in RecyclerView: " + items.Count);


            var productItems = recyclerView.FindElements(By.ClassName("android.widget.RelativeLayout"));
            Console.WriteLine("Product items found in RecyclerView: " + productItems.Count);
            Assert.That(productItems.Count, Is.GreaterThan(0), "Product items are not displayed in the RecyclerView.");
            
        }
        [Test]
        public void ClickOnEmptyBucket()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var letsShopButton = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop")));
            var nameField = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/nameField")));

            nameField.SendKeys("Test User");
            letsShopButton.Click();

            var bucketButton = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/appbar_btn_cart")));
            Assert.That(bucketButton.Displayed, Is.True, "Bucket button is not displayed.");
            Assert.That(bucketButton.Enabled, Is.True, "Bucket button is not enabled.");
            Assert.That(bucketButton.GetAttribute("clickable"), Is.EqualTo("true"), "Bucket button is not clickable.");

            bucketButton.Click();
            bool toastAppeared = wait.Until(d => d.PageSource.Contains("Please add some product at first"));
            Assert.That(toastAppeared, Is.True, "Toast message not found in page source.");
        }    


             [TearDown]
        public void TearDown()
        {
                driver?.Quit();
                driver?.Dispose();
        }

    }

}