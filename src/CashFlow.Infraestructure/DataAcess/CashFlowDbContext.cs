using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure.DataAcess;

public class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

}
