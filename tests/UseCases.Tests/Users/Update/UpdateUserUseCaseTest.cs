using CashFlow.Application.UseCases.User.Update;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.User;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace UseCases.Tests.Users.Update;

public class UpdateUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggedUser = UserBuilder.Build();
        var request = RequestUpdateUserJsonBuilder.Build();

        var useCase = CreateUseCase(loggedUser);

        var act = async () => await useCase.Execute(request);

        await act.Should().NotThrowAsync();

        loggedUser.Name.Should().Be(request.Name);
        loggedUser.Email.Should().Be(request.Email);
    }
    [Fact]
    public async Task Error_Name_Empty()
    {
        var loggedUser = UserBuilder.Build();
        var request = RequestUpdateUserJsonBuilder.Build();
        request.Name = string.Empty;

        var useCase = CreateUseCase(loggedUser);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.NAME_EMPTY));
    }

    [Fact]
    public async Task Error_Email_Already_Registered()
    {
        var loggedUser = UserBuilder.Build();
        var request = RequestUpdateUserJsonBuilder.Build();

        var useCase = CreateUseCase(loggedUser, request.Email);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
    }

    private UpdateUserUseCase CreateUseCase(User user, string? email = null)
    {
        var loggedUser = LoggedUserBuilder.Build(user);
        var repository = UserUpdateOnlyRepositoryBuilder.Build(user);
        var unitOfWork = UnitOfWorkBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder();

        if (!string.IsNullOrWhiteSpace(email))
        {
            readRepository.ExistActiveUserWithEmail(email);
        }

        return new UpdateUserUseCase(loggedUser, repository, readRepository.Build(), unitOfWork);
    }
}

