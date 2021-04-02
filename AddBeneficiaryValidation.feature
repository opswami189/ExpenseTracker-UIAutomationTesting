Feature: AddBeneficiaryValidation
	
Scenario: When I Add a NewValid Beneficiary
	Given I navigate to the Login page
	And I enter the Userid "opswami189@gmail.com" and Password "op123" on Login page
	And I navigate to the AddBeneficiary page
	And I Add a Beneficiary with name "DemoBen" and mobile "1234567899" on the AddBeneficiary page
	Then the message 'Beneficiary Added' Should be seen on the AddBeneficiary Page
Scenario: When I Add a NewInValid Beneficiary
	Given I navigate to the Login page
	And I enter the Userid "opswami189@gmail.com" and Password "op123" on Login page
	And I navigate to the AddBeneficiary page
	And I Add a Beneficiary with name " " and mobile "" on the AddBeneficiary page
	Then the message '* Name can not be empty!' Should be seen on the AddBeneficiary Page
Scenario: When I Add a Duplicate Beneficiary
	Given I navigate to the Login page
	And I enter the Userid "opswami189@gmail.com" and Password "op123" on Login page
	And I navigate to the AddBeneficiary page
	And I Add a Beneficiary with name "Demo1" and mobile "1234567899" on the AddBeneficiary page
	Then the message '* Beneficiary already exists!' Should be seen on the AddBeneficiary Page