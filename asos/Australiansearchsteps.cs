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
    public class Australiansearchsteps
    {
        IWebDriver driver;
        [Given(@"I am on asos australian site")]
        public void GivenIAmOnAsosAustralianSite()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.asos.com");
            driver.Manage().Window.Maximize();

            var ausSite = driver.FindElement(By.LinkText("Australia"));
            ausSite.Click();
        }
        [When(@"I search for yellow t shirts in the Australian store")]
        public void WhenISearchForYellowTShirtsInTheAustralianStore()
        {
            var searchBox = driver.FindElement(By.Id("txtSearch"));
            searchBox.Click();
            searchBox.SendKeys("yellow t shirts");

            var searchButton = driver.FindElement(By.ClassName("go"));
            searchButton.Click();
        }
        
        [Then(@"I should see some yellow t shirts")]
        public void ThenIShouldSeeSomeYellowTShirts()
        {
            var searchResults = driver.FindElement(By.ClassName("search-term"));
            Assert.IsTrue(searchResults.Displayed);
            Assert.AreEqual(searchResults.Text, "Yellow T Shirts");

            driver.Close();
        }
    }
}
