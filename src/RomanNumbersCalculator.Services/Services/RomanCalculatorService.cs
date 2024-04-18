using RomanNumbersCalculator.Services.Exceptions;
using System.Text;

namespace RomanNumbersCalculator.Services;
public class RomanCalculatorService : ICalculatorService
{
    private readonly IRomanNumeralValidationService _romanNumeralValidationService;
    public RomanCalculatorService(IRomanNumeralValidationService romanNumeralValidationService)
    {
        _romanNumeralValidationService = romanNumeralValidationService;
    }
    private readonly Dictionary<char, int> romanValues = new Dictionary<char, int>
    {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
        {'C', 100}, {'D', 500}, {'M', 1000}
    };

    public string Add(string input1, string input2)
    {
        if (!_romanNumeralValidationService.IsValidRomanNumeral(input1) ||
         !_romanNumeralValidationService.IsValidRomanNumeral(input2))
        {
            throw new InvalidRomanNumeralException();
        }

        int value1 = ToInteger(input1);
        int value2 = ToInteger(input2);

        int sum = value1 + value2;
        return ToRoman(sum);

    }

    private int ToInteger(string roman)
    {
        int result = 0;
        int previousValue = 0;

        for (int i = roman.Length - 1; i >= 0; i--)
        {
            if (!romanValues.ContainsKey(roman[i]))
                throw new InvalidRomanNumeralException();

            int value = romanValues[roman[i]];

            if (value < previousValue)
            {
                if (previousValue / value != 10 && previousValue / value != 5)
                    throw new InvalidRomanNumeralException();
                result -= value;
            }
            else
            {
                result += value;
            }

            previousValue = value;
        }

        return result;
    }

    private string ToRoman(int number)
    {
        if (number <= 0)
            throw new NonPositiveNumberException();

        var roman = new StringBuilder();
        var numerals = romanValues.OrderByDescending(n => n.Value);

        foreach (var pair in numerals)
        {
            while (number >= pair.Value)
            {
                roman.Append(pair.Key);
                number -= pair.Value;
            }
        }

        return roman.ToString()
                    .Replace("IIII", "IV")
                    .Replace("VIV", "IX")
                    .Replace("XXXX", "XL")
                    .Replace("LXL", "XC")
                    .Replace("CCCC", "CD")
                    .Replace("DCD", "CM");
    }
}

