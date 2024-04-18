namespace RomanNumbersCalculator.Services
{
    public class RomanNumeralValidationService : IRomanNumeralValidationService
    {
 
        public bool IsValidRomanNumeral(string input)
        {
            return IsRomanNumeralValidLength(input) &&
                   IsRomanNumeralValidCharacters(input) &&
                   IsRomanNumeralValidPattern(input) &&
                   IsRomanNumeralValidCombination(input) &&
                   IsRomanNumeralValidSubtractivePairs(input);
        }

        public bool IsRomanNumeralValidLength(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length <= 10;
        }

        public bool IsRomanNumeralValidCharacters(string input)
        {
            foreach (char c in input)
            {
                if (c != 'I' && c != 'V' && c != 'X' && c != 'L' && c != 'C' && c != 'D' && c != 'M')
                    return false;
            }
            return true;
        }

        public bool IsRomanNumeralValidPattern(string input)
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 1] && input[i] == input[i + 2])
                    return false;
            }
            return true;
        }

        public bool IsRomanNumeralValidCombination(string input)
        {

            string[] invalidCombinations = { "IIII", "VV", "XXXX", "LL", "CCCC", "DD" };

            foreach (string combination in invalidCombinations)
            {
                if (input.Contains(combination))
                    return false;
            }

            return true;
        }

        public bool IsRomanNumeralValidSubtractivePairs(string input)
        {
            string[] subtractivePairs = { "IV", "IX", "XL", "XC", "CD" , "CM" };

            if (subtractivePairs.Any(s => s.ToUpperInvariant() == input.ToUpperInvariant()))
                return true;

            foreach (string pair in subtractivePairs)
            {
                if (input.Contains(pair))
                {
                    int index = input.IndexOf(pair);
                    if (index == 0 || input[index - 1] != 'I' && input[index - 1] != 'X' && input[index - 1] != 'C')
                    {
                        return false;
                    }
                  
                }
            }


            return true;
        }

    }

}
