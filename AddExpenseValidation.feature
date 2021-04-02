Feature: AddExpenseValidation
	
Scenario: When I Add a NewValid Expense
	Given I Navigate to Login page
	And I Login With Userid "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddExpense page
	And I Add a Expense with Date "22-03-2021" and Amount "100" and CategoryId "Cashback" and IsSelect "false" and BeneficiaryId "Mohit" and PaymentModeId "Bank" and Details "Demo Expense for testing" on the AddExpense page
	Then The Message "Payment Added" Should be seen on the AddExpense page

Scenario: When I Add a InValidDate Expense
	Given I Navigate to Login page
	And I Login With Userid "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddExpense page
	And I Add a Expense with Date " " and Amount "100" and CategoryId "Cashback" and IsSelect "true" and BeneficiaryId "Mohit" and PaymentModeId "Bank" and Details "Demo Expense for testing" on the AddExpense page
	Then The Message "Invalid Date, Amount, Category, Beneficiary or PaymentMode Item!" Should be seen on the AddExpense page

Scenario: When I Add a InValidAmount Expense
	Given I Navigate to Login page
	And I Login With Userid "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddExpense page
	And I Add a Expense with Date "22-03-2021" and Amount "0" and CategoryId "Cashback" and IsSelect "true" and BeneficiaryId "Mohit" and PaymentModeId "Bank" and Details "Demo Expense for testing" on the AddExpense page
	Then The Message "Invalid Amount!" Should be seen on the AddExpense page

Scenario: When I Add a InValidCategory Expense
	Given I Navigate to Login page
	And I Login With Userid "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddExpense page
	And I Add a Expense with Date "22-03-2021" and Amount "100" and CategoryId " " and IsSelect "true" and BeneficiaryId "Mohit" and PaymentModeId "Bank" and Details "Demo Expense for testing" on the AddExpense page
	Then The Message "Invalid Date, Amount, Category, Beneficiary or PaymentMode Item!" Should be seen on the AddExpense page

Scenario: When I Add a InValidPayMode Expense
	Given I Navigate to Login page
	And I Login With Userid "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddExpense page
	And I Add a Expense with Date "22-03-2021" and Amount "100" and CategoryId "Cashback" and IsSelect "true" and BeneficiaryId "Mohit" and PaymentModeId " " and Details "Demo Expense for testing" on the AddExpense page
	Then The Message "Invalid Date, Amount, Category, Beneficiary or PaymentMode Item!" Should be seen on the AddExpense page



