using Bunit;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RomanNumbersCalculator.Components.Calculator;
using RomanNumbersCalculator.Models;
using RomanNumbersCalculator.Services;
using RomanNumbersCalculator.Validations;


namespace RomanCalculator.IntegrationTests
{

    [TestFixture]
    public class CalculatorComponentTests
    {
        private Bunit.TestContext _testContext;

        [SetUp]
        public void SetUp()
        {
            _testContext = new Bunit.TestContext();
            _testContext.Services.AddSingleton<ICalculatorService, RomanCalculatorService>();
            _testContext.Services.AddSingleton<IRomanNumeralValidationService, RomanNumeralValidationService>();
            _testContext.Services.AddScoped<IValidator<CalculatorModel>, CalculatorValidator>();
        }

        [TearDown]
        public void TearDown() => _testContext.Dispose();

        [Test]
        public void CalculatorComponent_AddsTwoRomanNumerals_CorrectOutputDisplayed()
        {
            // Arrange
            var component = _testContext.RenderComponent<Calculator>();
            
            string input1 = "V";
            string input2 = "II";
            string expectedResult = "VII";

            // Act
            var inputElement1 = component.Find("input#numeral1");
            inputElement1.Input(input1);

            var inputElement2 = component.Find("input#numeral2");
            inputElement2.Input(input2);

            component.Render(); 

            component.Find("button").Click();

            // Assert
            var result = component.Find("input.result").Attributes["value"].Value;
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculatorComponent_InvalidInput_ShowsErrorMessage()
        {
            // Arrange
            var component = _testContext.RenderComponent<Calculator>();

            // Act
            component.Find("input#numeral1").Change("IIX");
            component.Find("button").Click();

            // Assert
            var error = component.Find(".validation-message").TextContent;
            Assert.That(error, Is.EqualTo("RomanNumeral1 Is Not Valid Roman Numeral!"));
        }
    }

}