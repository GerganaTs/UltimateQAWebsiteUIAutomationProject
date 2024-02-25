using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UltimateQAWebsiteUIAutomationProject.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public static string ExpectedTitleHomePage = "Automation Practice - Ultimate QA";
    }
}
