Feature: AddCategoryValidation
	
Scenario: When I Add a NewValid Category
	Given I Navigate to The Login page
	And I Login With UserId "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddCategory page
	And I Add a Category with Name "Democat4" on the AddCategory page
	Then The Message "Category Added" Should be seen on the AddCategory page

Scenario: When I Add a NewInValid Category
	Given I Navigate to The Login page
	And I Login With UserId "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddCategory page
	And I Add a Category with Name " " on the AddCategory page
	Then The Message "* Category name can not be empty!" Should be seen on the AddCategory page

Scenario: When I Add a Duplicate Category
	Given I Navigate to The Login page
	And I Login With UserId "opswami189@gmail.com" and Password "op123" on the Login Page
	And I Navigate to The AddCategory page
	And I Add a Category with Name "Cashback" on the AddCategory page
	Then The Message "* Category already exists!" Should be seen on the AddCategory page