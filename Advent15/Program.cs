using System.Drawing;
using System.Text.RegularExpressions;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var lines = File.ReadAllLines("input.txt");
        Regex numberRegex = new Regex("-{0,1}[0-9]+");
        Dictionary<Point, Point> pairs = new Dictionary<Point, Point>();
        foreach (var line in lines)
        {
            var matches = numberRegex.Matches(line).ToArray();
            var sensor = new Point(int.Parse(matches[0].Value), int.Parse(matches[1].Value));
            var beacon = new Point(int.Parse(matches[2].Value), int.Parse(matches[3].Value));

            pairs.Add(sensor, beacon);
        }
        

        Console.WriteLine($"answer1: {CountAtRow(pairs,2000000)}");
    }

    private static int CountAtRow(Dictionary<Point, Point> pairs,int roi)
    {
        HashSet<int> points = new HashSet<int>();
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.Key}:{pair.Value} Distance:{GetDistance(pair.Key, pair.Value)}");
            var range = GetDistance(pair.Key, pair.Value);

            for (int i = pair.Key.X - range; i <= pair.Key.X + range; i++)
            {
                if (GetDistance(new Point(i, roi), pair.Key) <= range)
                    points.Add(i);
            }
            if (pair.Value.Y == roi)
                points.Remove(pair.Value.X);
        }
        return points.Count;
    }
    private static int GetDistance(Point p1, Point p2)
    {
        return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
    }
}