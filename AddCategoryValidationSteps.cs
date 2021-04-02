using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class AddCategoryValidationSteps
    {
        private readonly IWebDriver webDriver;
        public AddCategoryValidationSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
        [Given(@"I Navigate to The Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            webDriver.Url = $"https://localhost:44350/Login.aspx";
        }
        
        [Given(@"I Login With UserId ""(.*)"" and Password ""(.*)"" on the Login Page")]
        public void GivenILoginWithUserIdAndPasswordOnTheLoginPage(string username, string password)
        {
            var userIdBox = webDriver.FindElement(By.Id("TxtUserId"));
            var passwordBox = webDriver.FindElement(By.Id("TxtPassword"));
            var LoginBtn = webDriver.FindElement(By.Id("BtnLogin"));

            //Perform Required action with the element
            userIdBox.SendKeys(username);
            Thread.Sleep(1000);

            passwordBox.SendKeys(password);
            Thread.Sleep(1000);

            LoginBtn.Click();
            Thread.Sleep(1000);
        }
        
        [Given(@"I Navigate to The AddCategory page")]
        public void GivenINavigateToTheAddCategoryPage()
        {
            webDriver.Url = $"https://localhost:44350/AddCategory.aspx";
        }

        [Given(@"I Add a Category with Name ""(.*)"" on the AddCategory page")]
        public void GivenIAddACategoryWithNameOnTheAddCategoryPage(string cat)
        {
            
            var categoryBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtCategoryType"));
            var addBtn = webDriver.FindElement(By.Id("MainContentPlaceHolder1_BtnAdd"));

            categoryBox.SendKeys(cat);
            Thread.Sleep(1000);

            addBtn.Click();
            Thread.Sleep(1000);
        }   
        
        [Then(@"The Message ""(.*)"" Should be seen on the AddCategory page")]
        public void ThenTheMessageShouldBeSeenOnTheAddCategoryPage(string expectedMsg)
        {
            var actualMsg = webDriver.FindElement(By.Id("MainContentPlaceHolder1_LblMessage")).Text;
            Assert.Equal(expectedMsg, actualMsg);
        }
    }
}
