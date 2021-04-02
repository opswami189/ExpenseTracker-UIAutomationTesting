using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class AddBeneficiaryValidationSteps
    {
        private readonly IWebDriver webDriver;
        public AddBeneficiaryValidationSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
        [Given(@"I navigate to the Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            webDriver.Url = $"https://localhost:44350/Login.aspx";
        }

        [Given(@"I enter the Userid ""(.*)"" and Password ""(.*)"" on Login page")]
        public void GivenIEnterTheUseridAndPasswordOnLoginPage(string username, string password)
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
        
        [Given(@"I navigate to the AddBeneficiary page")]
        public void GivenINavigateToTheAddBeneficiaryPage()
        {
            webDriver.Url = $"https://localhost:44350/AddBeneficiary.aspx";
        }

        [Given(@"I Add a Beneficiary with name ""(.*)"" and mobile ""(.*)"" on the AddBeneficiary page")]
        public void GivenIAddABeneficiaryWithNameAndMobileOnTheAddBeneficiaryPage(string beneficiary, string mobile)
        {
            var beneficiaryBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtName"));
            var mobileBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtMobileNo"));
            var addBtn = webDriver.FindElement(By.Id("MainContentPlaceHolder1_BtnAdd"));

            beneficiaryBox.SendKeys(beneficiary);
            Thread.Sleep(1000);

            mobileBox.SendKeys(mobile);
            Thread.Sleep(1000);

            addBtn.Click();
            Thread.Sleep(1000);
        }
        
        [Then(@"the message '(.*)' Should be seen on the AddBeneficiary Page")]
        public void ThenTheMessageShouldBeSeenOnTheAddBeneficiaryPage(string expectedMsg)
        {
            var actualMsg = webDriver.FindElement(By.Id("MainContentPlaceHolder1_LblMessage")).Text;
            Assert.Equal(expectedMsg, actualMsg);
        }
    }
}
