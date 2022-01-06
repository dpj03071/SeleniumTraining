Feature: RadioButtonFeature
Feature handlling Radio Button related test cases

@RadioButtonDemo
Scenario Outline: Verify Radio button Functionality
	Given Open Demo QA
	And Navigate to '<CardName>'
	And Open Demo Web Element '<WebElement>'
	When Select Radio Button Value as '<RBValueSelected>'
	Then Verify Radio Button Value Displayed As '<RBValueDisplayed>'
	Examples: 
	| CardName | WebElement   | RBValueSelected | RBValueDisplayed |
	| Elements | Radio Button | Yes             | Yes              |
	| Elements | Radio Button | Impressive      | Impressive       |
