using Microsoft.EntityFrameworkCore;
using UnitOfWork.Domain.Entities;

namespace UnitOfWork.Infrastructure;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}
