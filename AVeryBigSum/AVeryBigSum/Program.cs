using System.Threading.Channels;

class Solution
{
    public static void Main(String[] args)
    {
        int value = new Random().Next(2, 4);

        List<string> input = DataManipulator.GenerateInput(null, null, value);
        
        Console.WriteLine(DataManipulator.AVeryBigSum(input));
    }
}

class DataManipulator
{

    public static long AVeryBigSum(List<string> ar)
    {
        double lastCharacter = ar.Select(x => char.GetNumericValue(x[x.Length - 1])).ToList().Sum(); 
        double firstCharacter = ar.Select(x => char.GetNumericValue(x[0])).ToList().Sum();
        
        /*return Convert.ToInt64(GenerateInput(firstCharacter: firstCharacter, lastCharacter:lastCharacter.ToString()).First());*/
    }

    public static void SumCharacters(char element, ref string character)
    {
        double a =+ char.GetNumericValue(element);
        character = a.ToString();

    }
    
    public static List<string> GenerateInput(string firstCharacter, string lastCharacter, int value = 1)
    {
         List<string> input = new List<string>();

         for (int i = 1; i <= value; i++)
         {
             string result = !string.IsNullOrEmpty(firstCharacter) 
                 ? firstCharacter.PadLeft(8, '0')
                 : i.ToString().PadLeft(8, '0');

             result += !string.IsNullOrEmpty(lastCharacter)
                 ? lastCharacter 
                 : i;
             
             input.Add(result);
         }

         return input;
    }
}