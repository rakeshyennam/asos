using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace asos
{
    [Binding]
    public class UseTheWebisteToChangeThePriceDisplayInNewZealandDollarsWhenIAmInAustralianStoreSteps
    {
        IWebDriver driver;
        [Given(@"I am on australian site")]
        public void GivenIAmOnAsosAustralianSite()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.asos.com");
            driver.Manage().Window.Maximize();

            var ausSite = driver.FindElement(By.LinkText("Australia"));
            ausSite.Click();
        }

        [When(@"I select the display price option as New Zeeland dollar")]
        public void WhenISelectTheDisplayPriceOptionAsNewZeelandDollar()
        {
            driver.FindElement(By.ClassName("menu-arrow")).Click();
            new SelectElement(driver.FindElement(By.Id("currencyList"))).SelectByValue("10064");  
        }
        
        [Then(@"I should see all the items display price in NewZealand dollars")]
        public void ThenIShouldSeeAllTheItemsDispalyPriceInNewZealandDollarsInAustralianStore()
        {
            var selectedCurrency = driver.FindElement(By.ClassName("selected-currency"));
            Assert.AreEqual(selectedCurrency.Text, "$ NZD");

            driver.Close();
        }
    }
}
