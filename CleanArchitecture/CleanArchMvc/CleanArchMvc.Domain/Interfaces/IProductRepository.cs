using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();   

    Task<Product> GetById(int id);

    Task<Product> Create(Product category);
    
    Task<Product> Update(Product category);
    
    Task<Product> Remove(Product category);
}