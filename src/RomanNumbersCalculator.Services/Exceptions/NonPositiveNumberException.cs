namespace RomanNumbersCalculator.Services.Exceptions
{
    public class NonPositiveNumberException : ArgumentException
    {
        public NonPositiveNumberException() : base("Input value must be positive.") { }

        public NonPositiveNumberException(string message)
            : base(message) { }

        public NonPositiveNumberException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
