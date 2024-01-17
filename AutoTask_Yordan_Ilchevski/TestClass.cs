using AutoTask_Yordan_Ilchevski.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoTask_Yordan_Ilchevski.Helper;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;



namespace AutoTask_Yordan_Ilchevski
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class TestClass<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;

        //Base URL
        private readonly string  baseUrl = "http://blankfactor.com";
        //Subscription Email
        private readonly string email = "test@abv.bg";

        [SetUp]
        public void Setup()
        {
            //Create driver and open browser
            this.driver = new TWebDriver();
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void Test()
        {
            HomePage homePage = new(driver);
            homePage.AcceptPolicies();
            InsightsPage insightsPage = homePage.GoToInsightsPage();   
            BlogPage blogPage = insightsPage.GoToBlogPage();
            Helpers.FindArticleByTitle(driver, "Why fintech in Latin America is booming");
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("https://blankfactor.com/insights/blog/fintech-in-latin-america/"));
                Assert.That(driver.PageSource, Does.Contain("Latin America has been a fertile ground for fintech investment"));
            });
            blogPage.SubscibeToNewsLetter(email);
            Helpers.BrowserNavigateBack(driver);
            Assert.That(driver.Url, Is.EqualTo("https://blankfactor.com/insights/blog/"));
            blogPage.PrintAllHeadingsAndLinks();
        }
    }
}