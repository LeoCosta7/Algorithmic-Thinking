using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    
    
    public int CategoryId { get; set; }                     
    public Category Category { get; set; }                  


    public Product(string name, string description, decimal price, int stock, string image)
    {
        bool isValid = CheckParameter(name, description, price, stock, image);          
        
        if (isValid)                                                                    
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
    
    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        bool isValid = CheckParameter(name, description, price, stock, image);         
        
        if (isValid)                                                                   
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }
    }
    
    private bool CheckParameter(string name, string description, decimal price, int stock, string image)
    {
        bool isValid = true;
        List<string> errors = new List<string>();
            
        errors.AddRange(DomainExceptionValidation.ValidateName(name));    
        errors.AddRange(DomainExceptionValidation.ValidateDescription(description));
        errors.AddRange(DomainExceptionValidation.ValidatePrice(price));
        errors.AddRange(DomainExceptionValidation.ValidateStock(stock));
        errors.AddRange(DomainExceptionValidation.ValidateImage(image));

        if (errors.Any())
            isValid = false;

        return isValid;
    }
}