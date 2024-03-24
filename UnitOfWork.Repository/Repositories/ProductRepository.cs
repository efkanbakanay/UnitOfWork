using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.Entities;
using UnitOfWork.Domain.Interfaces;
namespace UnitOfWork.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppContext dbContext) : base(dbContext)
    {

    }
}
