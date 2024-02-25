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

        public void TestHomePageLinksExistingAndCursorPointer(string currentLink)
        {
            bool resultLink = homePage.IsLinkPresentOnThePage(currentLink);

            Assert.That(resultLink, Is.EqualTo(true));

            IWebElement el = driver.FindElement(By.LinkText(currentLink));
            // Get the CSS value of the cursor property
            string cursorStyle = el.GetCssValue("cursor");

            // Assert: Check the cursor style
            Assert.That(cursorStyle, Is.EqualTo("pointer")); // Adjust the expected cursor style as needed
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
            // Arrange
            IWebElement link = driver.FindElement(By.LinkText(currentLink));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Act
            string initialColor = link.GetCssValue("color");

            // Check if the color is not black
            if (!initialColor.Equals("rgba(46, 163, 242, 1)"))
            {
                // Wait for the color to change
                wait.Until(driver => !link.GetCssValue("color").Equals(initialColor));
            }

            // Assert
            string finalColor = link.GetCssValue("color");
            Assert.That(finalColor, Is.EqualTo("rgba(46, 163, 242, 1)")); // Assert that the color is not black
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
            homePage.WaitForLinkToBeLoaded(currentLink);
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
            homePage.WaitForLinkToBeLoaded(currentLink);
            IWebElement link = driver.FindElement(By.LinkText(currentLink));

            // simulating focus efect
            link.SendKeys(Keys.Tab);

            string linkColorOnHover = link.GetCssValue("color");
            // Assert
            Assert.That(linkColorOnHover.ToString(), Is.EqualTo("rgba(46, 163, 242, 1)"));
        }
    }
}
