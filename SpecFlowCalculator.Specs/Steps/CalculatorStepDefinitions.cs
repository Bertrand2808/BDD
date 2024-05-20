using Xunit;

namespace SpecFlowCalculator.Specs.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
    private readonly ScenarioContext _scenarioContext;
    private readonly Calculator _calculator = new Calculator();
    private int _result;
    private List<int> _numbers;

    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        _calculator.FirstNumber = number;
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        _calculator.SecondNumber = number;
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _result = _calculator.Add();
    }
    
    [When("the two numbers are subtracted")]
    public void WhenTheTwoNumbersAreSubtracted()
    {
        _result = _calculator.Subtract();
    }
    
    [When("the two numbers are multiplied")]
    public void WhenTheTwoNumbersAreMultiplied()
    {
        _result = _calculator.Multiply();
    }
    
    [When("the two numbers are divided")]
    public void WhenTheTwoNumbersAreDivided()
    {
        try
        {
            _result = _calculator.Divide();
        }
        catch (DivideByZeroException)
        {
            _scenarioContext["Exception"] = "DivideByZeroException";
        }
    }
    
    [Given("the numbers are (.*)")]
    public void GivenTheNumbersAre(string numbers)
    {
        _numbers = numbers.Split(',')
                          .Select(n => int.TryParse(n, out var number) ? number : (int?)null)
                          .Where(n => n.HasValue)
                          .Select(n => n.Value)
                          .ToList();
    }

    [When("the numbers are added")]
    public void WhenTheNumbersAreAdded()
    {
        _result = _calculator.Add(_numbers);
    }

    [When("the numbers are subtracted")]
    public void WhenTheNumbersAreSubtracted()
    {
        _result = _calculator.Subtract(_numbers);
    }

    [When("the numbers are multiplied")]
    public void WhenTheNumbersAreMultiplied()
    {
        _result = _calculator.Multiply(_numbers);
    }

    [When("the numbers are divided")]
    public void WhenTheNumbersAreDivided()
    {
        try
        {
            _result = _calculator.Divide(_numbers);
        }
        catch (DivideByZeroException)
        {
            _scenarioContext["Exception"] = "DivideByZeroException";
        }
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        Assert.Equal(result, _result);
    }
    
    [Then("a DivideByZeroException should be thrown")]
    public void ThenADivideByZeroExceptionShouldBeThrown()
    {
        Assert.Equal("DivideByZeroException", _scenarioContext["Exception"]);
    }
}