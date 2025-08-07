using CashFlow.Application.UseCases.Expenses.Update;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Expenses;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace UseCases.Tests.Expenses.Update;

public class UpdateExpenseUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);
        var request = RequestExpenseJsonBuilder.Build();

        var useCase = CreateUseCase(loggedUser, expense);

        var act = async () => await useCase.Execute(expense.Id, request);

        await act.Should().NotThrowAsync();

        expense.Title.Should().Be(request.Title);
        expense.Description.Should().Be(request.Description);
        expense.Date.Should().Be(request.Date);
        expense.Amount.Should().Be(request.Amount);
        expense.PaymentType.Should().Be((CashFlow.Domain.Enums.PaymentType)request.PaymentType);
    }
    [Fact]
    public async Task Error_Title_Empty()
    {
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);

        var request = RequestExpenseJsonBuilder.Build();
        request.Title = string.Empty;

        var useCase = CreateUseCase(loggedUser, expense);

        var act = async () => await useCase.Execute(expense.Id, request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public async Task Error_Expense_Not_Found()
    {
        var loggedUser = UserBuilder.Build();

        var request = RequestExpenseJsonBuilder.Build();

        var useCase = CreateUseCase(loggedUser);

        var act = async () => await useCase.Execute(id: 1000, request);

        var result = await act.Should().ThrowAsync<NotFoundException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EXPENSE_NOT_FOUND));
    }
    private UpdateExpenseUseCase CreateUseCase(User user, Expense? expense = null)
    {
        var loggedUser = LoggedUserBuilder.Build(user);
        var unitOfWork = UnitOfWorkBuilder.Build();
        var mapper = MapperBuilder.Build();
        var repository = new ExpenseUpdateOnlyRepositoryBuilder().GetById(user, expense).Build();

        return new UpdateExpenseUseCase(mapper, unitOfWork, loggedUser, repository);
    }
}
