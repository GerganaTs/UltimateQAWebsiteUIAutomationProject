using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UltimateqaWebsiteUIAutomation.Configuration;
using NUnit.Framework;

namespace UltimateQAWebsiteUIAutomationProject.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Navigate to the home page URL
            driver.Navigate().GoToUrl(AppConfig.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            // Quit the driver
            driver.Quit();
        }
    }
}
