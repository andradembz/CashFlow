
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.User.Delete;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    public DeleteUserUseCase(
        IUserWriteOnlyRepository writeRepository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser)
    {
        _repository = writeRepository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
    }

    public async Task Execute()
    {
        var loggedUser = await _loggedUser.Get();

        await _repository.Delete(loggedUser);

        await _unitOfWork.Commit();

    }
}
