using Microsoft.AspNetCore.Components;

namespace RomanNumbersCalculator.Components.Calculator
{
    public partial class RomanNumeralResult
    {

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        private async Task ValueChangedHandler(ChangeEventArgs e)
        {
            Value = e.Value.ToString();
            await ValueChanged.InvokeAsync(Value);
        }
    }
}