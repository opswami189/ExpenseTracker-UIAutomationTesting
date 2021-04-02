using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class TitleValidationSteps
    {
        private readonly IWebDriver _webDriver;

        public TitleValidationSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I have navigated to the ""(.*)"" page")]
        public void GivenIHaveNavigatedToThePage(string page)
        {
            _webDriver.Url = $"https://localhost:44350/{page}.aspx";
        }
        
        [Then(@"the title of the page should be ""(.*)""")]
        public void ThenTheTitleOfThePageShouldBe(string title)
        {
            Assert.Equal(title, _webDriver.Title);
        }
    }
}
