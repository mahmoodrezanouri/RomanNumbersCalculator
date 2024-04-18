using FluentValidation;
using RomanNumbersCalculator.Models;
using RomanNumbersCalculator.Services;


namespace RomanNumbersCalculator.Validations
{
    public class CalculatorValidator : AbstractValidator<CalculatorModel>
    {

        private readonly IRomanNumeralValidationService _romanNumeralValidationService;

        public CalculatorValidator(IRomanNumeralValidationService romanNumeralValidationService)
        {
            _romanNumeralValidationService = romanNumeralValidationService;

            RuleFor(x => x.RomanNumeral1)
                .Must(x => _romanNumeralValidationService.IsValidRomanNumeral(x))
                .WithMessage("RomanNumeral1 Is Not Valid Roman Numeral!");

            RuleFor(x => x.RomanNumeral2)
                .Must(x => _romanNumeralValidationService.IsValidRomanNumeral(x))
                .WithMessage("RomanNumeral2 Is Not Valid Roman Numeral!");


            RuleFor(x => x.RomanNumeral1)
                .Must(x => _romanNumeralValidationService.IsRomanNumeralValidCharacters(x))
                .WithMessage("RomanNumeral1 Is Not Contain Valid Characters!");


            RuleFor(x => x.RomanNumeral2)
                .Must(x => _romanNumeralValidationService.IsValidRomanNumeral(x))
                .WithMessage("RomanNumeral2 Is Not Contain Valid Characters!");

        }

    }
}
