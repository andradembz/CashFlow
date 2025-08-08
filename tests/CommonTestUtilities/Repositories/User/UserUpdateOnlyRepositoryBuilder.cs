using CashFlow.Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories.User;

public class UserUpdateOnlyRepositoryBuilder
{
    public static IUserUpdateOnlyRepository Build(CashFlow.Domain.Entities.User user)
    {
        var mock = new Mock<IUserUpdateOnlyRepository>();

        mock.Setup(repository => repository.GetById(user.Id)).ReturnsAsync(user);

        return mock.Object;
    }
}
