using CashFlow.Application.UseCases.User.Profile;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Tests.Users.Profile;

public class GetUserProfileUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggerUser = UserBuilder.Build();

        var useCase = CreateUseCase(loggerUser);

        var result = await useCase.Execute();

        result.Should().NotBeNull();
        result.Email.Should().Be(loggerUser.Email);
        result.Name.Should().Be(loggerUser.Name);
    }   

    private GetUserProfileUseCase CreateUseCase(User user)
    {
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetUserProfileUseCase(loggedUser, mapper);
    }
}
