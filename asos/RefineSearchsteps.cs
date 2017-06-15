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
    public class UseWebsiteToRefineSearchToDisplayItemsForMenSteps
    {
        IWebDriver driver;
        [Given(@"I am on asos search results page")]
        public void GivenIAmOnAsosSite()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.asos.com");
            driver.Manage().Window.Maximize();

            var searchBox = driver.FindElement(By.Id("txtSearch"));
            searchBox.Click();
            searchBox.SendKeys("purple t shirts");

            var searchButton = driver.FindElement(By.ClassName("go"));
            searchButton.Click();
        }
        [When(@"I refined search to display only items for (.*)")]
        public void WhenIRefinedSearchToDisplayOnlyItemsFor(string gender)
        {
            if(gender.Equals("Men"))
            {
                var menCheckBox = driver.FindElement(By.CssSelector("#productlist-results > aside > div:nth-child(4) > div > div > ul > li:nth-child(1) > a > span.facet-checkbox"));
                menCheckBox.Click();
            }
            else if(gender.Equals("Women"))
            {
                var womenCheckBox = driver.FindElement(By.CssSelector("#productlist-results > aside > div:nth-child(4) > div > div > ul > li:nth-child(2) > a > span.facetvalue-name"));
                womenCheckBox.Click();
            }
        }
        
        [Then(@"I can find only items for refined search")]
        public void ThenICanFindOnlyItemsForMen()
        {
            System.Threading.Thread.Sleep(2000);
            var viewAllLink = driver.FindElement(By.ClassName("change-view-all"));
            Assert.IsTrue(viewAllLink.Displayed);
            Assert.AreEqual("View all", viewAllLink.Text);

            var count = driver.FindElement(By.ClassName("total-results"));
            Assert.IsTrue(count.Displayed);
            Console.WriteLine("Count value is " + count.Text);

            var clear = driver.FindElement(By.ClassName("clear-filter"));
            Assert.IsTrue(clear.Displayed);

            driver.Close();
        }
    }
}
