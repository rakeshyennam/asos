using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using NUnit.Framework;

namespace asos
{
    [Binding]
    public class UseTheWebsiteToFindShirtsSteps
    {
        IWebDriver driver;
        [Given(@"I am on asos site")]
        public void GivenIAmOnAsosSite()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.asos.com");
            driver.Manage().Window.Maximize();
        }

        [When(@"I search for purple t shirts")]
        public void WhenISearchForPurpleTShirts()
        {
            var searchBox = driver.FindElement(By.Id("txtSearch"));
            searchBox.Click();
            searchBox.SendKeys("purple t shirts");

            var searchButton = driver.FindElement(By.ClassName("go"));
            searchButton.Click();

        }

         [Then(@"I should see some purple t shirts")]
        public void ThenIShouldSeeSomePurpleTShirts()
        {
            var searchResults = driver.FindElement(By.ClassName("search-term"));
            Assert.IsTrue(searchResults.Displayed);
            Assert.AreEqual(searchResults.Text, "Purple T Shirts");

            driver.Close();
        }

    }
}
