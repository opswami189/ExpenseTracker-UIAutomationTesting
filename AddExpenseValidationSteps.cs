using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace ExpenseTrackerAutomation
{
    [Binding]
    public class AddExpenseValidationSteps
    {
        private readonly IWebDriver webDriver;
        public AddExpenseValidationSteps(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
        [Given(@"I Navigate to Login page")]
        public void GivenINavigateToLoginPage()
        {
            webDriver.Url = $"https://localhost:44350/Login.aspx";
        }

        [Given(@"I Login With Userid ""(.*)"" and Password ""(.*)"" on the Login Page")]
        public void GivenILoginWithUseridAndPasswordOnTheLoginPage(string username, string password)
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
        
        [Given(@"I Navigate to The AddExpense page")]
        public void GivenINavigateToTheAddExpensePage()
        {
            webDriver.Url = $"https://localhost:44350/AddExpense.aspx";
        }

        [Given(@"I Add a Expense with Date ""(.*)"" and Amount ""(.*)"" and CategoryId ""(.*)"" and IsSelect ""(.*)"" and BeneficiaryId ""(.*)"" and PaymentModeId ""(.*)"" and Details ""(.*)"" on the AddExpense page")]
        public void GivenIAddAExpenseWithDateAndAmountAndCategoryIdAndIsSelectAndBeneficiaryIdAndPaymentModeIdAndDetailsOnTheAddExpensePage(string date, string amt, string catg, string check, string benef, string paymode, string details)
        {
            var dateBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtDate"));
            var amtBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtAmount"));
            var catgBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_DropDownCategory"));
            var checkBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_CheckBoxIsCredit"));
            var benefBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_DropDownBeneficiary"));
            var paymodeBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_DropDownMode"));
            var detailBox = webDriver.FindElement(By.Id("MainContentPlaceHolder1_TxtDetails"));
            var addBtn = webDriver.FindElement(By.Id("MainContentPlaceHolder1_BtnAdd"));

            dateBox.SendKeys(date);
            Thread.Sleep(1000);

            amtBox.SendKeys(amt);
            Thread.Sleep(1000);

            catgBox.SendKeys(catg);
            Thread.Sleep(1000);

            if(check=="true")
            {
                checkBox.Click();
            }

            benefBox.SendKeys(benef);
            Thread.Sleep(1000);

            paymodeBox.SendKeys(paymode);
            Thread.Sleep(1000);

            detailBox.SendKeys(details);
            Thread.Sleep(1000);

            addBtn.Click();
            Thread.Sleep(1000);
        }
        
        [Then(@"The Message ""(.*)"" Should be seen on the AddExpense page")]
        public void ThenTheMessageShouldBeSeenOnTheAddExpensePage(string expectedMsg)
        {
            var actualMsg = webDriver.FindElement(By.Id("MainContentPlaceHolder1_LblMessage")).Text;
            Assert.Equal(expectedMsg, actualMsg);
        }
    }
}
