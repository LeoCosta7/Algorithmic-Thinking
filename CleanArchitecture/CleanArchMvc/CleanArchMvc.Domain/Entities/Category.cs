using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        DomainExceptionValidation.ValidateName(name);
    }

    public Category(int id, string name)
    {
        //ValidateDomain(id, value => value < 0);
        Id = id;
        DomainExceptionValidation.ValidateName(name);
    }

    public void Update(string name)
    {
        DomainExceptionValidation.ValidateName(name);           //Os outros métodos nã farão atualização, somente este
    }
    
    public ICollection<Product> Products { get; set; }
}