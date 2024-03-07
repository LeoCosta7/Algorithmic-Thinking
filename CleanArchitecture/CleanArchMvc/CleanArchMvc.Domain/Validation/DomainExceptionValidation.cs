namespace CleanArchMvc.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)                                                                // Construtor da classe que recebe uma mensagem de erro e repassa para o construtor da classe base (Exception)
    { }

    private static List<string> When<T>(T obj, Dictionary<Func<T, bool>, string> validation)
    {
        List<string> errors = new List<string>();
        
        List<string> invalidConditional = validation
            .Where(x => x.Key(obj))                                                   
            .Select(x => x.Value).ToList();                                                      
        
        if (invalidConditional.Any())
        {
            string errorMessage = string.Join(Environment.NewLine, invalidConditional);
            
            errors.AddRange(invalidConditional);                                                                             
            
            throw new DomainExceptionValidation(errorMessage);
        }

        return errors;
    }
    
    public static List<string> ValidateName(string name) => When(name, nameValidations);

    public static List<string> ValidateDescription(string description) => When(description, descriptionValidations);
    
    public static List<string> ValidatePrice(decimal price) => When(price, priceValidations);

    public static List<string> ValidateStock(int stock) => When(stock, stockValidations);

    public static List<string> ValidateImage(string image) => When(image, imageValidations);

    public static List<string> ValidateId(int id) => When(id, idValidations);
    
    
    private static Dictionary<Func<string, bool>, string> nameValidations = new Dictionary<Func<string, bool>, string>
    {
        {value => string.IsNullOrEmpty(value), $"name is required."},
        {value => value.Length <3, $"Size must be greater than three."}
    };
    
    private static Dictionary<Func<string,bool>, string> descriptionValidations = new Dictionary<Func<string, bool>, string>()
    {
        {value => string.IsNullOrEmpty(value), $"Description is required."},
        {value => value.Length < 5, $"Syze smaller than 5."}
    };
    
    private static Dictionary<Func<decimal,bool>, string> priceValidations = new Dictionary<Func<decimal, bool>, string>()
    {
        {value => value < 0, $"Invalid price value."},
    };
    
    private static Dictionary<Func<int,bool>, string> stockValidations = new Dictionary<Func<int, bool>, string>()
    {
        {value => value < 0, $"Invalid stock value."},
    };
    
    private static Dictionary<Func<string,bool>, string> imageValidations = new Dictionary<Func<string, bool>, string>()
    {
        {value => value.Length > 250, $"Invalid image size. Maximum 250 characters."},
    };

    private static Dictionary<Func<int, bool>, string> idValidations = new Dictionary<Func<int, bool>, string>
    {
        {value => value < 0, $"Invalid id value."}
    };
}