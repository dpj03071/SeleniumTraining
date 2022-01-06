Feature: TextboxFeature
Feature handlling Textbox related test cases

@TextboxDemo
Scenario Outline: Verify Textbox Functionality
	Given Open Demo QA
	And Navigate to '<CardName>'
	And Open Demo Web Element '<WebElement>'
	When Fill up Textbox Form as '<FullName>', '<Email>', '<CurrentAddress>', '<PermanantAddress>'
	Then Verify Textbox Form values are '<FullName>', '<Email>', '<CurrentAddress>', '<PermanantAddress>'
	Examples: 
	| CardName | WebElement | FullName   | Email               | CurrentAddress | PermanantAddress |
	| Elements | Text Box   | Don Bosco  | Don_Bosco@epam.com  | Pune           | Mumbai           |
	| Elements | Text Box   | Deen Jones | Deen_Jones@epam.com | Pune           | Pune             |