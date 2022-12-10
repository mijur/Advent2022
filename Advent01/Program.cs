using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Reading Inventory");
        var lines = File.ReadAllLines("ElvesInventory.txt");
        int max=0;
        int currentElf = 0;
        List<int> elves = new();
        foreach(var line in lines)
        {
            if(line != "")
            {
                currentElf += int.Parse(line);
            }
            else
            {
                    elves.Add(currentElf);
                if (currentElf >= max)
                {
                    max = currentElf;
                }
                currentElf = 0;
            }
        }

        elves = elves.OrderByDescending(x=>x).ToList();
        var topThree = elves.Take(3).ToList();
        Console.WriteLine(topThree.Sum());
    }
}