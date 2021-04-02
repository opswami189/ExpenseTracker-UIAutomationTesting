using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class SigninValidationSteps
    {
        private readonly IWebDriver webDriver;
        public SigninValidationSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I Navigate to the Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            webDriver.Url = $"https://localhost:44350/Login.aspx";
        }
        
        [When(@"I Login with UserId ""(.*)"" and Password ""(.*)"" and checkBox ""(.*)"" on the Login Page")]
        public void WhenILoginWithUserIdAndPasswordAndcheckBoxOnTheLoginPage(string username, string password, string check)
        {
            var userIdBox = webDriver.FindElement(By.Id("TxtUserId"));
            var passwordBox = webDriver.FindElement(By.Id("TxtPassword"));
            var checkBox= webDriver.FindElement(By.Id("ChkRememberMe"));
            var LoginBtn = webDriver.FindElement(By.Id("BtnLogin"));

            //Perform Required action with the element
            userIdBox.SendKeys(username);
            Thread.Sleep(1000);

            passwordBox.SendKeys(password);
            Thread.Sleep(1000);

            if (check == "true")
            {
                checkBox.Click();
            }
            Thread.Sleep(1000);


            LoginBtn.Click();
            Thread.Sleep(1000);
        }

        

        [Then(@"the User Name '(.*)' should be seen on the AddExpense Page")]
        public void ThenTheUserNameShouldBeSeenOnTheAddExpensePage(string expectedName)
        {
            var actualName = webDriver.FindElement(By.Id("LblUserName")).Text;
            Assert.Equal(expectedName, actualName);
            
        }
        
        [Then(@"the error message '(.*)' Should be seen on the Login Page")]
        public void ThenTheErrorMessageShouldBeSeenOnTheLoginPage(string expectedError)
        {
            var actualError = webDriver.FindElement(By.Id("LblError")).Text;
            Assert.Equal(expectedError, actualError);
            
        }
        [Then(@"the error '(.*)' Should be seen on the Login Page")]
        public void ThenTheErrorShouldBeSeenOnTheLoginPage(string expErr)
        {
            var actualError = webDriver.FindElement(By.Id("ValSummaryLogin")).Text;
            Assert.Equal(expErr, actualError);
        }

        [Given(@"I Navigate to the AddExpense page")]
        public void GivenINavigateToTheAddExpensePage()
        {
            webDriver.Url = $"https://localhost:44350/AddExpense.aspx";
        }


    }
}
