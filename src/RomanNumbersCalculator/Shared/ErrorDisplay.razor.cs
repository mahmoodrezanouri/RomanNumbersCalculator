using Microsoft.AspNetCore.Components;

namespace RomanNumbersCalculator.Shared
{
    public partial class ErrorDisplay
    {

        [Parameter]
        public string? ErrorMessage { get; set; }

    }
}