using RomanNumbersCalculator.Services;
using RomanNumbersCalculator.Services.Exceptions;

namespace RomanCalculator.UnitTests
{
    
    [TestFixture]
    public class RomanCalculatorServiceTests
    {
        private RomanCalculatorService _calculator;

        [SetUp]
        public void Setup()
        {
            var validationService = new RomanNumeralValidationService();

            _calculator = new RomanCalculatorService(validationService);
        }

        [Test]
        public void Add_ValidInput_ReturnsCorrectResult_1()
        {
            // Arrange
            string input1 = "V";
            string input2 = "II";
            string expectedResult = "VII";

            // Act
            string result = _calculator.Add(input1, input2);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_ValidInput_ReturnsCorrectResult_2()
        {
            // Arrange
            string input1 = "LXXIV";
            string input2 = "DII";
            string expectedResult = "DLXXVI";

            // Act
            string result = _calculator.Add(input1, input2);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_ValidInput_ReturnsCorrectResult_3()
        {
            // Arrange
            string input1 = "MCLI";
            string input2 = "DXV";
            string expectedResult = "MDCLXVI";

            // Act
            string result = _calculator.Add(input1, input2);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_InvalidInput_ThrowsInvalidRomanNumeralException_1()
        {
            // Arrange
            string input1 = "IVX";
            string input2 = "I";

            // Act and Assert
            Assert.Throws<InvalidRomanNumeralException>(() => _calculator.Add(input1, input2));
        }
        [Test]
        public void Add_InvalidInput_ThrowsInvalidRomanNumeralException_2()
        {
            // Arrange
            string input1 = "LLX";
            string input2 = "LL";

            // Act and Assert
            Assert.Throws<InvalidRomanNumeralException>(() => _calculator.Add(input1, input2));
        }

    }

}