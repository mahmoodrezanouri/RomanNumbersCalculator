using Microsoft.AspNetCore.Components;

namespace RomanNumbersCalculator.Components.Calculator
{
    public partial class ComputeButton
    {

        [Parameter]
        public EventCallback OnClick { get; set; }
    }
}