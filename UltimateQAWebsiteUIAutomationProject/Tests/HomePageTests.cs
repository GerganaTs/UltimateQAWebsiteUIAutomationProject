using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using UltimateQAWebsiteUIAutomationProject.Pages;

namespace UltimateQAWebsiteUIAutomationProject.Tests
{
    public class HomePageTests : BaseTests
    {
        private HomePage homePage;

        [SetUp]
        public void TestSetup()
        {
            // Instantiate the HomePage once before each test method
            homePage = new HomePage(driver);
        }

        [TearDown] 
        public void TestTearDown()
        {
            driver.Close();
        }

        [Test]
        public void PageTitleTest()
        {
            Assert.That(HomePage.ExpectedTitleHomePage, Does.Match(homePage.GetPageTitle()));
        }

        [Test]
        [TestCase("Big page with many elements")]
        [TestCase("Fake Landing Page")]
        [TestCase("Fill out forms")]
        [TestCase("Learn how to automate an application that evolves over time")]
        [TestCase("Login automation")]
        [TestCase("Interactions with simple elements")]

        public void TestHomePageLinks(string currentLink)
        {
            bool resultLink = homePage.IsLinkPresentOnThePage(currentLink);

            Assert.That(resultLink, Is.EqualTo(true));
        }

        [Test]
        [TestCase("Big page with many elements")]
        [TestCase("Fake Landing Page")]
        [TestCase("Fill out forms")]
        [TestCase("Learn how to automate an application that evolves over time")]
        [TestCase("Login automation")]
        [TestCase("Interactions with simple elements")]

        public void TestHomePageLinksColor(string currentLink)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.LinkText(currentLink)));
            IWebElement link = driver.FindElement(By.LinkText(currentLink));
            string linkColor = link.GetCssValue("color");

            Assert.That(linkColor.ToString(), Is.EqualTo("rgba(46, 163, 242, 1)"));
        }

        [Test]
        [TestCase("Big page with many elements")]
        [TestCase("Fake Landing Page")]
        [TestCase("Fill out forms")]
        [TestCase("Learn how to automate an application that evolves over time")]
        [TestCase("Login automation")]
        [TestCase("Interactions with simple elements")]

        public void TestHomePageLinksColorOnHover(string currentLink)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.LinkText(currentLink)));
            IWebElement link = driver.FindElement(By.LinkText(currentLink));

            // simulating hover efect
            Actions actions = new Actions(driver);
            actions.MoveToElement(link).Perform();

            string linkColorOnHover = link.GetCssValue("color");
            // Assert
            Assert.That(linkColorOnHover.ToString(), Is.EqualTo("rgba(0, 0, 0, 1)"));
        }

        [Test]
        [TestCase("Big page with many elements")]
        [TestCase("Fake Landing Page")]
        [TestCase("Fill out forms")]
        [TestCase("Learn how to automate an application that evolves over time")]
        [TestCase("Login automation")]
        [TestCase("Interactions with simple elements")]

        public void TestHomePageLinksColorOnFocus(string currentLink)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.LinkText(currentLink)));
            IWebElement link = driver.FindElement(By.LinkText(currentLink));

            // simulating focus efect
            link.SendKeys(Keys.Tab);

            string linkColorOnHover = link.GetCssValue("color");
            // Assert
            Assert.That(linkColorOnHover.ToString(), Is.EqualTo("rgba(46, 163, 242, 1)"));
        }
    }
}
