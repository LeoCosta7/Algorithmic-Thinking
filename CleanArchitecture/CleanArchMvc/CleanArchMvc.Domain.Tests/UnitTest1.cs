using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class UnitTest1
{
    [Fact(DisplayName = "Create Category With valid Parameters")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState() //Começo_Meio_Fim
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }
}
