namespace RomanNumbersCalculator.Services
{
    public interface IRomanNumeralValidationService
    {
        bool IsValidRomanNumeral(string input);
        bool IsRomanNumeralValidLength(string input);
        bool IsRomanNumeralValidCharacters(string input);
        bool IsRomanNumeralValidPattern(string input);
        bool IsRomanNumeralValidCombination(string input);
    }
}
