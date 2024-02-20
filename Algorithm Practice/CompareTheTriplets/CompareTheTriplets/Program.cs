class Solution
{
    public static void Main(string[] args)
    {
        List<int> a = DataManipulator.GenerateValues();

        List<int> b = DataManipulator.GenerateValues();
        
        List<int> result = DataManipulator.compareTriplets(a, b);

        Console.WriteLine($" {String.Join($" ", a)} \n {String.Join(" ", b)} ");
        Console.WriteLine(String.Join(" ", result));
    }
}

class DataManipulator
{
    public static List<int> compareTriplets(List<int> a, List<int> b)
    {
        List<int> score = new List<int>();
        
        List<int> comparison = a.Zip(b, (x, y) => x > y ? 1 : (x == y ? 0 : -1)).ToList();
        
        score.Add(comparison.Where(x => x == 1).Sum());
        score.Add(Math.Abs(comparison.Where(x => x == -1).Sum()));

        return score;
    }

    public static List<int> GenerateValues()
    {
        Random random = new Random();

        return Enumerable.Range(0, 3).Select(x => random.Next(1, 3)).ToList();
    }  
}
