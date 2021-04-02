using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class SignUpValidationSteps
    {
        private readonly IWebDriver webDriver;
        public SignUpValidationSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
        [Given(@"I Navigated to the SignUp page")]
        public void GivenINavigatedToTheSignUpPage()
        {
            webDriver.Url = $"https://localhost:44350/SignUp.aspx";
        }

        [When(@"I SignUp with FirstName ""(.*)"" and EmailId ""(.*)"" and Password ""(.*)""")]
        public void WhenISignUpWithFirstNameAndEmailIdAndPassword(string firstName, string emailId, string password)
        {
            var firstNameBox = webDriver.FindElement(By.Id("TxtFirstName"));
            var emailBox = webDriver.FindElement(By.Id("TxtEmail"));
            var passwordBox = webDriver.FindElement(By.Id("TxtPassword"));
            var signUpBtn = webDriver.FindElement(By.Id("BtnSignUp"));

            //Perform Required action with the element
            firstNameBox.SendKeys(firstName);
            Thread.Sleep(1000);

            emailBox.SendKeys(emailId);
            Thread.Sleep(1000);

            passwordBox.SendKeys(password);
            Thread.Sleep(1000);

            signUpBtn.Click();
            Thread.Sleep(1000);
        }


        [Then(@"the error ""(.*)"" should be seen on the SignUp Page")]
        public void ThenTheErrorShouldBeSeenOnTheSignUpPage(string expectedError)
        {
            var actualError = webDriver.FindElement(By.Id("ValSummarySignUp")).Text;
            Assert.Equal(expectedError, actualError);
        }

        [Then(@"the Feedback ""(.*)"" should be seen on the SignUp Page")]
        public void ThenTheFeedbackShouldBeSeenOnTheSignUpPage(string expectedFeedback)
        {
            var actualFeedback = webDriver.FindElement(By.Id("LblFeedback")).Text;
            Assert.Equal(expectedFeedback, actualFeedback);
        }
    }
}
