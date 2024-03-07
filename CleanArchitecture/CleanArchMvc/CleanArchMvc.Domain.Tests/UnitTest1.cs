using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;
//Posteriormente, realizar outros casos. 
public class UnitTest1
{
    [Fact(DisplayName = "Create Category With valid Parameters")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState() 
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact()]
    public void CreateCategory_WithInvalidId_ResultObjectInvalidState() 
    {
        Action action = () => new Category(-2,"Category Name");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid id value.");
    }
}
