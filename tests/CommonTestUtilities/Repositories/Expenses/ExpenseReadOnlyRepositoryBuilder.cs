using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommonTestUtilities.Repositories.Expenses;

public class ExpenseReadOnlyRepositoryBuilder
{
    private readonly Mock<IExpensesReadOnlyRepository> _repository;
    public ExpenseReadOnlyRepositoryBuilder()
    {
        _repository = new Mock <IExpensesReadOnlyRepository>();
    }

    public ExpenseReadOnlyRepositoryBuilder GetAll(CashFlow.Domain.Entities.User user, List<Expense> expenses)
    {
        _repository.Setup(repository => repository.GetAll(user)).ReturnsAsync(expenses);

        return this;
    }

    public ExpenseReadOnlyRepositoryBuilder GetById(CashFlow.Domain.Entities.User user, Expense? expense)
    {
        if(expense is not null) 
            _repository.Setup(repository => repository.GetById(user, expense.Id)).ReturnsAsync(expense);

        return this;
    }

    public IExpensesReadOnlyRepository Build() => _repository.Object;
}
