using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Payment_Application.Command;

namespace Payment_Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreatePaymentCommandHandler).Assembly));

        services.AddValidatorsFromAssemblyContaining<CreatePaymentCommand>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddAutoMapper(typeof(PaymentProfile).Assembly);
        return services;
    }
}
