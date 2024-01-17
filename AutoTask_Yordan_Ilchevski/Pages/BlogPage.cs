using AutoTask_Yordan_Ilchevski.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Page;


namespace AutoTask_Yordan_Ilchevski.Pages
{
    public class BlogPage(IWebDriver driver)
    {

        private readonly IWebDriver driver = driver;

        

        public void SubscibeToNewsLetter(string email)
        {
            IWebElement emailSubscriptionInput = driver.FindElement(By.XPath("//input[@type='email']"));
            IWebElement submitSubscriptionBtn = driver.FindElement(By.Id("form-newsletter-blog-submit-btn"));
            Helpers.ScrollElementIntoViewAndClick(driver, emailSubscriptionInput);
            emailSubscriptionInput.SendKeys(email);
            submitSubscriptionBtn.Click();
            Console.WriteLine("Subscribed with email: "+ email);
        }

        public void PrintAllHeadingsAndLinks()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            try
            {
                long lastHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight");

                while (true)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    Thread.Sleep(2000);

                    long newHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight");
                    if (newHeight == lastHeight)
                    {
                        break;
                    }
                    lastHeight = newHeight;
                }
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("StackTrace: " + e.StackTrace);
            }


            List<IWebElement> headings = [.. driver.FindElements(By.XPath("//h2[@class='heading-4 post-title']/a"))];
            Console.WriteLine("Headings count is: " + headings.Count);

            

            foreach (var heading in headings)
            {
                Console.WriteLine("Heading text is: " + heading.Text);
                Console.WriteLine("Heading link is: " + heading.GetDomProperty("href"));
            }
        }

    }
}
