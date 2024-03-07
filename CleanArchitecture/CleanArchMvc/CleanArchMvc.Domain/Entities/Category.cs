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
        Id = id;
        DomainExceptionValidation.ValidateName(name);
    }

    public void Update(string name)
    {
        DomainExceptionValidation.ValidateName(name);           
    }
    
    public ICollection<Product> Products { get; set; }
}