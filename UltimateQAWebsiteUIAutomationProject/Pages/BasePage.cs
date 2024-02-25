using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UltimateQAWebsiteUIAutomationProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Get Page Title
        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void HoverElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public void FocusElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(Keys.Tab);
        }

        public bool IsLinkPresentOnThePage(string linkText)
        {
            try
            {
                // Attempt to find the link element
                IWebElement linkElement = driver.FindElement(By.LinkText(linkText));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
