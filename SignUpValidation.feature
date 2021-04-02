Feature: SignUpValidation
	
Scenario: When I SignUp with Invalid User Name
	Given I Navigated to the SignUp page
	When I SignUp with FirstName "d" and EmailId "demo@demo" and Password "demo123"
	Then the error "First name must be 2-10 characters long." should be seen on the SignUp Page
Scenario: When I SignUp with Invalid User Password
	Given I Navigated to the SignUp page
	When I SignUp with FirstName "demo" and EmailId "demo@dmo" and Password "demo"
	Then the error "Password must be 5-10 characters long with at least one numeric character." should be seen on the SignUp Page
Scenario: When I SignUp with Valid User Details
	Given I Navigated to the SignUp page
	When I SignUp with FirstName "demo" and EmailId "demo@demo" and Password "demo123"
	Then the Feedback "Your account has been created!" should be seen on the SignUp Page

