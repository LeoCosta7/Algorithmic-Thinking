using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    ApplicationDbContext _productContext;
    
    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _productContext.Products.FindAsync();
    }

    public async Task<Product> GetCategoryByProductId(int id)
    {
        return await _productContext.Products.Include(c => c.Category)      //Usando a propriedade de navegação
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> Create(Product product)
    {
        _productContext.Add(product);
        _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _productContext.Update(product);
        _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Remove(Product product)
    {
        _productContext.Remove(product);
        _productContext.SaveChangesAsync();
        return product;
    }
}