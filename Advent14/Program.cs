internal class Program
{
    private static string[] lines;

    private static void Main(string[] args)
    {
        var text = File.ReadAllText("input.txt");
        lines = text.Split("\r\n").ToArray();
        int maxX = 0;
        int maxY = 0;
        int minX = int.MaxValue;
        int minY = 0;
        List<List<PathPoint>> paths = new List<List<PathPoint>>();
        for (int i = 0; i < lines.Length; i++)
        {
            string? line = lines[i];
            var pathPoints = line.Split(" -> ");
            List<PathPoint> points = new();

            for (int j = 0; j < pathPoints.Length; j++)
            {
                var p = new PathPoint(pathPoints[j].Split(','));
                points.Add(p);
                if (maxX < p.X)
                {
                    maxX = p.X;
                }
                else if (minX > p.X)
                {
                    minX = p.X;
                }
                if (maxY < p.Y)
                {
                    maxY = p.Y;
                }

            }
            paths.Add(points);
        }
        char[][] map = CreateBlankMap(maxX * 2, maxY + 1);

        var source = new PathPoint(500, minY);
        map[source.Y][source.X] = '+';
        foreach (var points in paths)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                PathPoint? point = points[i];
                PathPoint? nextPoint = points[i + 1];
                map[point.Y - minY][point.X] = '#';
                while (!point.Equals(nextPoint))
                {
                    if (point.X > nextPoint.X)
                        point.X--;
                    if (point.X < nextPoint.X)
                        point.X++;
                    if (point.Y > nextPoint.Y)
                        point.Y--;
                    if (point.Y < nextPoint.Y)
                        point.Y++;
                    map[point.Y - minY][point.X] = '#';
                }
            }
        }
        //Draw(map);
        bool leftFree;
        bool rightFree;
        var sand = new Sand(source);
        int grains = 0;
        try
        {
            while (true)
            {
                sand.Y++;
                if (map[sand.Y][sand.X] == '.')
                    continue;

                leftFree = map[sand.Y][sand.X - 1] == '.';
                rightFree = map[sand.Y][sand.X + 1] == '.';
                if (leftFree)
                {
                    sand.X--;
                    continue;
                }
                else if (rightFree)
                {
                    sand.X++;
                    continue;
                }
                else
                {
                    sand.Y--;
                }
                map[sand.Y][sand.X] = 'o';
                grains++;
                //Draw(map);
                //Task.Delay(1).Wait();
                if(sand.Y == 0)
                {
                    break;
                }
                sand.Reset();
            }
        }
        catch (IndexOutOfRangeException)
        {

        }
        Draw(map);

        Console.WriteLine("grains of sand: " + grains);
    }
    static char[][] CreateBlankMap(int width, int height)
    {
        height += 2;
        char[][] map = new char[height][];
        for (int i = 0; i < height; i++)
        {
            map[i] = new char[width];
            for (int j = 0; j < width; j++)
            {
                map[i][j] = '.';
            }
        }

        map[height - 1] = Enumerable.Repeat('#', width).ToArray();
        return map;
    }
    public static void Draw(char[][] paths)
    {
        Console.Clear();

        for (int i = 0; i < paths.Length; i++)
        {
            char[]? path = paths[i].Skip(450).Take(80).ToArray();
            Console.WriteLine(path);
        }
    }
}
public class Sand : PathPoint
{
    public PathPoint InitPoint;
    public Sand(PathPoint init) : base(init.X, init.Y)
    {
        InitPoint = init;
    }
    public void Reset()
    {
        X = InitPoint.X;
        Y = InitPoint.Y;
    }
}
public class PathPoint : IEquatable<PathPoint>
{
    public PathPoint(int x, int y)
    {
        X = x;
        Y = y;
    }
    public PathPoint(string[] coordinate)
    {
        X = int.Parse(coordinate[0]);
        Y = int.Parse(coordinate[1]);
    }

    public int X { get; set; }
    public int Y { get; set; }

    public bool Equals(PathPoint? other)
    {
        return X == other.X && Y == other.Y;
    }
}