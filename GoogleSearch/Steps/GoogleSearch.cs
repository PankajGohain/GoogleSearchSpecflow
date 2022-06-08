using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace GoogleSearch.Steps
{
	[Binding]
	public sealed class GoogleSearch {

        string gURL = "https://www.google.com/";

        IWebDriver driver;

        [Given(@"I navigate to the google search page")]
        public void GivenINavigateToTheGoogleSearchPage()
        {
            driver = new ChromeDriver();
            driver.Url = gURL;
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Given(@"I enter specflow in the search field")]
        public void GivenIEnterSpecflowInTheSearchField()
        {
            IWebElement search = driver.FindElement(By.XPath("//input[@title='Search']"));
            search.SendKeys("specflow");
        }

        [When(@"I press enter key")]
        public void WhenIPressEnterKey()
        {
            driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(Keys.Enter);
        }

        [Then(@"I clicked the third result")]
        public void ThenIClickedTheThirdResult()
        {
            ReadOnlyCollection<IWebElement> allLinks =driver.FindElements(By.XPath("//*[@id='rso']//div//a"));
            Console.Write(allLinks.Count);
            System.Threading.Thread.Sleep(3000);
            allLinks.ElementAt(2).Click();
        }

        [Then(@"the result should be displayed for specflow")]
        public void ThenTheResultShouldBeDisplayedForSpecflow()
        {
            string text = driver.Title;
            Console.WriteLine(text);
        }

    }
}
