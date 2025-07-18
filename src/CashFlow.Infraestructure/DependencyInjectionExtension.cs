using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infraestructure.DataAcess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infraestructure;

public static class DependencyInjectionExtension
{
    public static void AddInfraestructure(this IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }
}
