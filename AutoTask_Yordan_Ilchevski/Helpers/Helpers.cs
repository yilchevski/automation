using OpenQA.Selenium;



namespace AutoTask_Yordan_Ilchevski.Helper
{
    public class Helpers
    {
        public static void ScrollUntilElementTextIsVisible(IWebDriver driver, string text)
        {
            int y_axis = 1;
            while (true)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("window.scrollBy(0," + y_axis + ")", "");
                y_axis += 5;
                try
                {
                    driver.FindElement(By.LinkText(text));
                    break;
                }
                catch (NoSuchElementException)
                {

                }
            }

        }

        public static void ScrollElementIntoViewAndClick(IWebDriver driver, IWebElement element)
        {
            int y_axis = 250;
            while (true)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("window.scrollBy(0," + y_axis + ")", "");
                y_axis += 50;
                try
                {
                    element.Click();
                    break;
                }
                catch (NoSuchElementException)
                {

                }
            }
        }

        public static void FindArticleByTitle(IWebDriver driver, string title)
        {
            ScrollUntilElementTextIsVisible(driver, title);
            IWebElement article = driver.FindElement(By.LinkText(title));
            article.Click();
        }

        public static void BrowserNavigateBack(IWebDriver driver)
        { 
            driver.Navigate().Back();
        }

    }
}
