
using CashFlow.Infraestructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Domain.Repositories.User;

internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public UserRepository(CashFlowDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(Entities.User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
 
    public async Task Delete(Entities.User user)
    {
        var userToRemove = await _dbContext.Users.FindAsync(user.Id);
        _dbContext.Remove(userToRemove!);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<Entities.User> GetById(long id)
    {
       return await _dbContext.Users.FirstAsync(user => user.Id.Equals(id));
    }

    public async Task<Entities.User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public void Update(Entities.User user)
    {
        _dbContext.Users.Update(user);
    }
}
