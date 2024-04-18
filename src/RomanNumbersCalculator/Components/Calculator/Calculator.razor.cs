using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using RomanNumbersCalculator.Models;
using RomanNumbersCalculator.Services;


namespace RomanNumbersCalculator.Components.Calculator
{
    public partial class Calculator
    {
        [Inject]
        private ICalculatorService CalculatorService { get; set; }
        private CalculatorModel calculatorModel = new();
        private string result = "";
        private FluentValidationValidator? _fluentValidationValidator;

        private async void CalculateSum()
        {
            if (await _fluentValidationValidator!.ValidateAsync())
            {
                try
                {
                    result = CalculatorService.Add(calculatorModel.RomanNumeral1.ToUpper(), calculatorModel.RomanNumeral2.ToUpper());
                }
                catch (Exception ex) 
                {
                    result = "INVALID";
                }
            }
        }

    }
}