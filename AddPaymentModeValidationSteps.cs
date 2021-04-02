using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class AddPaymentModeValidationSteps
    {
        private readonly IWebDriver webDriver;
        public AddPaymentModeValidationSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
        [Given(@"I navigate to The Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            webDriver.Url = $"https://localhost:44350/Login.aspx";

        }

        [Given(@"I Login with UserId ""(.*)"" and Password ""(.*)"" on the Login Page")]
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
        
        [Given(@"I Navigate to The AddPaymentMode page")]
        public void GivenINavigateToTheAddPaymentModePage()
        {
            webDriver.Url = $"https://localhost:44350/AddPaymentMode.aspx";

        }

        [Given(@"I Add a PaymentMode with Name ""(.*)"" on the AddPaymentMode page")]
        public void GivenIAddAPaymentModeWithNameOnTheAddPaymentModePage(string mode)
        {
            var modeBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtMode"));
            var addBtn = webDriver.FindElement(By.Id("MainContentPlaceHolder1_BtnAdd"));

            modeBox.SendKeys(mode);
            Thread.Sleep(1000);

            addBtn.Click();
            Thread.Sleep(1000);
        }
        
        [Then(@"The Message ""(.*)"" Should be seen on the AddPaymentMode page")]
        public void ThenTheMessageShouldBeSeenOnTheAddPaymentModePage(string expectedMsg)
        {
            var actualMsg = webDriver.FindElement(By.Id("MainContentPlaceHolder1_LblMessage")).Text;
            Assert.Equal(expectedMsg, actualMsg);
        }
    }
}
