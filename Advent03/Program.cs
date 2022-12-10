internal class Program
{
    const int zeroLower = ((int)'a') - 1;
    const int zeroUpper = ((int)'A') - 2;
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Part1:");
        Part1();
        Console.WriteLine("Part2:");
        Part2();
    }
    private static void Part2()
    {
        var rucksacks = File.ReadAllLines("Rucksacks.txt");
        HashSet<char> first = new HashSet<char>();
        HashSet<char> common = new HashSet<char>();
        int priorities = 0;
        for (int j=1; j<=rucksacks.Length; j++)
        {
            var rucksack = rucksacks[j - 1];
            foreach (var item in rucksack)
            {
                Console.Write(item);
                if (j % 3 == 1)
                {
                    first.Add(item);
                }
                else if (j % 3 == 2)
                {
                    if (first.TryGetValue(item,out _))
                        common.Add(item);
                }
                else if(j % 3 == 0) { 
                    if (common.TryGetValue(item,out _))
                    {   
                        priorities += CalculatePriority(item);
                        break;
                    }
                }
            }
            Console.WriteLine();
            if (j % 3 == 0)
            {
                first.Clear();
                common.Clear();
            }
        }
        Console.WriteLine(priorities);
    }
    private static void Part1()
    {
        var rucksacks = File.ReadAllLines("Rucksacks.txt");
        HashSet<char> firstContainer = new HashSet<char>();
        HashSet<int> commons = new HashSet<int>();
        int priorities = 0;
        foreach (var rucksack in rucksacks)
        {
            for (int i = 0; i < rucksack.Length; i++)
            {
                if (i <= (rucksack.Length / 2) - 1)
                    firstContainer.Add(rucksack[i]);
                else if (firstContainer.TryGetValue(rucksack[i], out _))
                    commons.Add(CalculatePriority(rucksack[i]));
            }
            priorities += commons.Sum();
            firstContainer.Clear();
            commons.Clear();
        }
        Console.WriteLine(priorities);
    }
    private static int CalculatePriority(int item)
    {
        return item > zeroLower ? item - zeroLower : item - zeroUpper + 25;
    }
}