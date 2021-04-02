Feature: LoginValidation


Scenario: When I Login with empty UserId and nonEmpty Password
	Given I Navigate to the Login page
	When I Login with UserId "" and Password "demo123" and checkBox "false" on the Login Page
	Then the error 'UserId Required!' Should be seen on the Login Page

Scenario: When I Login with nonEmpty UserId and empty Password
	Given I Navigate to the Login page
	When I Login with UserId "demo@demo" and Password "" and checkBox "false" on the Login Page
	Then the error 'Password Required!' Should be seen on the Login Page

Scenario: When I Login with invalid UserId and Password
	Given I Navigate to the Login page
	When I Login with UserId "demo2@demo" and Password "demo12" and checkBox "false" on the Login Page
	Then the error message 'Invalid User' Should be seen on the Login Page

Scenario: When I Login with correct UserId and Password
	Given I Navigate to the Login page
	When I Login with UserId "demo@demo" and Password "demo123" and checkBox "false" on the Login Page
	Then the User Name 'Welcome demo !' should be seen on the AddExpense Page

Scenario: When I Login with RememberMe checkbox
	Given I Navigate to the Login page
	When I Login with UserId "demo@demo" and Password "demo123" and checkBox "true" on the Login Page
	Then the User Name 'Welcome demo !' should be seen on the AddExpense Page
	
Scenario: Confirming the RememberMe functionality
	Given I Navigate to the AddExpense page
	Then the User Name 'Welcome demo !' should be seen on the AddExpense Page