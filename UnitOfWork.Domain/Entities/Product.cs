
namespace UnitOfWork.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public int ProductStock { get; set; }
}
