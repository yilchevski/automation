using OpenQA.Selenium;


namespace AutoTask_Yordan_Ilchevski.Pages
{
    public class HomePage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        //Accept Cookies Button
        IWebElement cookieAcceptButton => driver.FindElement(By.XPath("//a[@id='hs-eu-confirmation-button']"));

        //Insights menu
        IWebElement insightsMenuButton => driver.FindElement(By.XPath("//ul[@id='menu-main-menu']/descendant::span[contains(text(), \"Insights\")]"));



        //Accept Policies
        public void AcceptPolicies()
        {
            cookieAcceptButton?.Click();
        }

        public  InsightsPage GoToInsightsPage()
        { 
            insightsMenuButton?.Click();
            return new InsightsPage(driver);
        }

    }
}
