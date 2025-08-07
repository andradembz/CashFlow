using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommonTestUtilities.Repositories.Expenses;

public class ExpenseWriteOnlyRepositoryBuilder
{
    public static IExpenseWriteOnlyRepository Build()
    {
        var mock = new Mock<IExpenseWriteOnlyRepository>();

        return mock.Object;
    }
}
