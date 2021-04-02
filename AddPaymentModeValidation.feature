Feature: AddPaymentModeValidation


Scenario: When I Add a NewValid PaymentMode
	Given I navigate to The Login page
	And I Login with UserId "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddPaymentMode page
	And I Add a PaymentMode with Name "Demo-UPI" on the AddPaymentMode page
	Then The Message "Payment mode Added" Should be seen on the AddPaymentMode page

Scenario: When I Add a NewInValid PaymentMode
	Given I navigate to The Login page
	And I Login with UserId "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddPaymentMode page
	And I Add a PaymentMode with Name " " on the AddPaymentMode page
	Then The Message "* Mode can not be empty!" Should be seen on the AddPaymentMode page

Scenario: When I Add a Duplicate PaymentMode
	Given I navigate to The Login page
	And I Login with UserId "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddPaymentMode page
	And I Add a PaymentMode with Name "UPI" on the AddPaymentMode page
	Then The Message "* Payment mode already exists!" Should be seen on the AddPaymentMode page