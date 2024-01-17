using OpenQA.Selenium;

namespace AutoTask_Yordan_Ilchevski.Pages
{
    
    public class InsightsPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        //Blog button
        IWebElement goToBlogBtn => driver.FindElement(By.XPath("//a[contains(text(), \"Blog\")]"));

        public BlogPage GoToBlogPage()
        {
            goToBlogBtn.Click();
            return new BlogPage(driver);
        }

      
    }
}
