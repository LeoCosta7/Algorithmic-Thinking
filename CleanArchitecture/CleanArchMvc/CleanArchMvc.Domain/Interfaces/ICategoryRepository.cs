using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();      //Operação assincrona (Task).

    Task<Category> GetById(int id);

    Task<Category> Create(Category category);
    
    Task<Category> Update(Category category);
    
    Task<Category> Remove(Category category);
}