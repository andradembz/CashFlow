using CashFlow.Domain.Services.LoggedUser;
using Moq;

namespace CommonTestUtilities.Repositories;

public class LoggedUserBuilder
{
    public static ILoggedUser Build(CashFlow.Domain.Entities.User user)
    {
        var mock = new Mock<ILoggedUser>();

        mock.Setup(loggedUser => loggedUser.Get()).ReturnsAsync(user);

        return mock.Object;
    }
}
