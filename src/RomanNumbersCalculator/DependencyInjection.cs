using FluentValidation;
using RomanNumbersCalculator.Models;
using RomanNumbersCalculator.Services;
using RomanNumbersCalculator.Validations;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICalculatorService, RomanCalculatorService>();
        services.AddSingleton<IRomanNumeralValidationService, RomanNumeralValidationService>();
        services.AddScoped<IValidator<CalculatorModel>, CalculatorValidator>();

        return services;
    }
}
