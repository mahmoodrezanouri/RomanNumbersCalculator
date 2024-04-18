namespace RomanNumbersCalculator.Services.Exceptions
{
    public class InvalidRomanNumeralException : Exception
    {
        public InvalidRomanNumeralException() : base("Invalid Roman numeral input.") { }

        public InvalidRomanNumeralException(string message)
            : base(message) { }

        public InvalidRomanNumeralException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
