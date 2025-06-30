using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using GeneralStore.Configs;
using GeneralStore.Pages.ProductPage;
using GeneralStore.Pages;


namespace ProductPageTests

{

    [TestFixture]

    public class ProductPageTests

    {

         private AndroidDriver driver;
        private MainPage _registrationForm;
        private ProductPage _productPage;
        private WebDriverWait? wait;

        [SetUp]
        public void OneTimeSetUp()
        {
            var serverUrl = new Uri(
                Environment.GetEnvironmentVariable("APPIUM_SERVER_URL")
                ?? "http://localhost:4723/wd/hub");

            driver = new AndroidDriver(
                serverUrl,
                AppiumConfig.BuildAndroidOptions(),
                TimeSpan.FromSeconds(180));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _registrationForm = new MainPage(driver);
            _productPage = new ProductPage(driver);
        }
        [Test]
        public void LogInToProductPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _registrationForm.EnterName("Test User");
            _registrationForm.ClickLetsShopButton();

            Assert.Multiple(() =>
            {
                Assert.That(_registrationForm.ToolbarTitleDisplayed, Is.True, "Toolbar title is not displayed.");
                Assert.That(_registrationForm.ToolbarTitleEnabled, Is.True, "Toolbar title is not enabled.");
                Assert.That(_registrationForm.ToolbarTitleText, Is.EqualTo("Products"), "Toolbar title text is not correct.");

                Assert.That(_registrationForm.ToolbarTitleText, Is.EqualTo("Products"), "Products page title is not correct after clicking Let's Shop button.");

                Assert.That(_productPage.ParentIsNotNull, "У RecyclerView нет родительского элемента");


                Assert.That(_productPage.ProductElementsCount, Is.GreaterThan(0), "RecyclerView does not contain any items.");
                Console.WriteLine("Items found in RecyclerView: " + _productPage.ProductElementsCount);


                Console.WriteLine("Product items found in RecyclerView: " + _productPage.ProductItemsCount);
                Assert.That(_productPage.ProductItemsCount, Is.GreaterThan(0), "Product items are not displayed in the RecyclerView.");
            });
            
        }
        [Test]
        public void ClickOnEmptyBucket()
        {
            _registrationForm.EnterName("Test User");
            _registrationForm.ClickLetsShopButton();
            Assert.That(_productPage.IsBucketDisplayed, Is.True, "Bucket button is not displayed.");
            Assert.That(_productPage.IsBucketEnabled, Is.True, "Bucket button is not enabled.");
            _productPage.ClickOnEmptyBucket();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool toastAppeared = wait.Until(d => d.PageSource.Contains("Please add some product at first"));
            Assert.That(toastAppeared, Is.True, "Toast message not found in page source.");
        }    


        [TearDown]
        public void TearDown()
        {
            try
            {
                driver?.RemoveApp("com.androidsample.generalstore");
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine($"Не удалось удалить приложение: {e.Message}");
            }
            finally
            {
                driver?.Quit();
                driver?.Dispose();
            }

        }

    }

}