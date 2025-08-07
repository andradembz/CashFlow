using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Expenses;
using FluentAssertions;

namespace UseCases.Tests.Expenses.GetAll;

public class GetAllExpenseUseCaseTest
{
    [Fact]
    public async Task Sucess()
    {
        var loggedUser = UserBuilder.Build();
        var expenses = ExpenseBuilder.Collection(loggedUser);

        var useCase = CreateUseCase(loggedUser, expenses);

        var result = await useCase.Execute();

        result.Should().NotBeNull();
        result.Expenses.Should().NotBeNullOrEmpty().And.AllSatisfy(expense =>
        {
            expense.Id.Should().BeGreaterThan(0);
            expense.Title.Should().NotBeNullOrEmpty();
            expense.Amount.Should().BeGreaterThan(0);
        });
    }

    private GetAllExpensesUseCase CreateUseCase(User user, List<Expense> expenses)
    {
        var repository = new ExpenseReadOnlyRepositoryBuilder().GetAll(user, expenses).Build();
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetAllExpensesUseCase(repository, mapper, loggedUser);
    }
}
