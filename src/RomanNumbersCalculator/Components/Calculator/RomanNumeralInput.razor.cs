using Microsoft.AspNetCore.Components;

namespace RomanNumbersCalculator.Components.Calculator
{
    public partial class RomanNumeralInput
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public EventCallback<string> ValueChangedCallback { get; set; }

        private async Task ValueChangedHandler(ChangeEventArgs e)
        {
            Value = e.Value.ToString();
            await ValueChanged.InvokeAsync(Value);
            await ValueChangedCallback.InvokeAsync(Value); 
        }
    }
}