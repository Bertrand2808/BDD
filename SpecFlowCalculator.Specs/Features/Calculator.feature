Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	
Scenario: Subtract two numbers
	Given the first number is 120
	And the second number is 70
	When the two numbers are subtracted
	Then the result should be 50
	
Scenario: Multiply two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are multiplied
	Then the result should be 3500

Scenario: Divide two numbers
	Given the first number is 120
	And the second number is 60
	When the two numbers are divided
	Then the result should be 2
	
Scenario: Divide by zero
	Given the first number is 120
	And the second number is 0
	When the two numbers are divided
	Then a DivideByZeroException should be thrown

Scenario: Add multiple numbers
	Given the numbers are 10, 20, 30, 40, 50
	When the numbers are added
	Then the result should be 150

Scenario: Subtract multiple numbers
	Given the numbers are 10, 3, 2
	When the numbers are subtracted
	Then the result should be 5
	
Scenario: Multiply multiple numbers
	Given the numbers are 2, 3, 4, 5
	When the numbers are multiplied
	Then the result should be 120
	
Scenario: Divide multiple numbers
	Given the numbers are 120, 2, 3, 4
	When the numbers are divided
	Then the result should be 5

	