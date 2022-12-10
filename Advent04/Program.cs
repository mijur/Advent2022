internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //Write("something");
        var pairs = File.ReadAllLines("SectionAssignments.txt");
        var count = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            var pair = pairs[i].Split(",");
            var first = ParseElf(pair[0]);
            var second = ParseElf(pair[1]);
            Range a;
            if(RangeContains(first,second) || RangeContains(second,first) || PartiallyCover(first, second))
            {
                count++;
            }

        }
        Console.WriteLine(count);

    }
    static bool PartiallyCover(int[] range1, int[] range2)
    {
        return RangeContains(range1, range2[0]) || RangeContains(range1, range2[1])
            || RangeContains(range2, range1[0])|| RangeContains(range2,range1[1]);
    }
    static bool RangeContains(int[] containingRange, int[] range)
    {
        return RangeContains(containingRange, range[0]) && RangeContains(containingRange, range[1]);
    }

    static bool RangeContains(int[] range, int? check)
    {
        return range[0] <= check && range[1] >= check;
    }
    static int[] ParseElf(string input)
    {
        var split = input.Split("-");
        return new int[] { int.Parse(split[0]), int.Parse(split[1]) };
    }

}