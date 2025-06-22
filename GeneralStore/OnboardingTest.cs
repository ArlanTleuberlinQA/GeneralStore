using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Appium;

using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.DevTools.V135.Browser;
using System;
 
namespace GeneralStore

{

    [TestFixture]

    public class OnboardingTest

    {

        private AndroidDriver driver;
 
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

            );

        }

        [Test]

        public void Test_Onboarding()

        {

            var splashElement = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));

            Assert.That(splashElement, Is.Not.Null);

            Console.WriteLine("Splashscreen element found.");

        }
        [Test]
        public void VisibilityTest()

        {

            var splashElement = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));

            Assert.That(splashElement.Displayed, Is.True, "Splashscreen is not displayed.");

            Console.WriteLine("Splashscreen is visible.");

        }
        [Test]
        public void EnabledTest()

        {

            var splashElement = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));

            Assert.That(splashElement.Enabled, Is.True, "Splashscreen is not enabled.");

            Console.WriteLine("Splashscreen is enabled.");

        }
        [Test]
        public void NotClickableTest()

        {

            var splashElement = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));

            Assert.That(splashElement.GetAttribute("clickable"), Is.EqualTo("false"), "Splashscreen is clickable.");

            Console.WriteLine("Splashscreen is not clickable.");

        }
        [Test]
        public void NoTextTest()

        {

            var splashElement = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));

            Assert.That(splashElement.Text, Is.Empty, "Splashscreen has text.");

            Console.WriteLine("Splashscreen has no text.");

        }
        [Test]
        public void BarBackgroundPresentTest()

        {

            var bgElement = driver.FindElement(By.Id("android:id/navigationBarBackground"));

            Assert.That(bgElement, Is.Not.Null, "Splashscreen background color is not present.");

            Console.WriteLine("Splashscreen bar background is present.");

        }
        [Test]
        public void IsBarBackgroundDisplayedTest()

        {

            var bgElement = driver.FindElement(By.Id("android:id/navigationBarBackground"));

            Assert.That(bgElement.Displayed, Is.True, "Splashscreen background color is not displayed.");

            Console.WriteLine("Splashscreen bar background is displayed.");

        }
        [Test]
        public void IsBarBackgroundEnabledTest()

        {

            var bgElement = driver.FindElement(By.Id("android:id/navigationBarBackground"));

            Assert.That(bgElement.Enabled, Is.True, "Splashscreen background color is not enabled.");

            Console.WriteLine("Splashscreen bar background is enabled.");

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

 