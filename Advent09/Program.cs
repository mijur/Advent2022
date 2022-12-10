using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[][] Coordinate = new int[][]
        {
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 },
            new int[] { 0, 0 }
        };

        var input = File.ReadAllLines("input.txt");
        HashSet<string> map = new HashSet<string>();
        int visitedAtLeastOnce = 0;
        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i];
            var split = line.Split(' ');
            var stepCount = int.Parse(split[1]);
            for (int j = 0; j < stepCount; j++)
            {
                switch (split[0])
                {
                    case "R":
                        Coordinate[0][0]++;
                        break;
                    case "L":
                        Coordinate[0][0]--;
                        break;
                    case "U":
                        Coordinate[0][1]++;
                        break;
                    case "D":
                        Coordinate[0][1]--;
                        break;
                }
                for (int k = 1; k < 10; k++)
                {
                    CalculateTail(Coordinate[k], Coordinate[k-1]);
                }

                if (map.Add($"{Coordinate.Last()[0]}/{Coordinate.Last()[1]}"))
                {
                    visitedAtLeastOnce++;
                }
            }

            Draw(Coordinate,line);
        }
        var count = map.Count();
        Console.WriteLine(count);
    }
    private static void CalculateTail(int[] tCoordinate, int[] hCoordinate)
    {
        int xDifference = hCoordinate[0] - tCoordinate[0];
        int yDifference = hCoordinate[1] - tCoordinate[1];
        int absXDifference = Math.Abs(xDifference);
        int absYDifference = Math.Abs(yDifference);
        //Are adjacent
        if ((absXDifference == 1 && absYDifference == 0)
            || (absXDifference == 0 && absYDifference == 1)
            || (absXDifference == 1 && absYDifference == 1))
        {
        }
        //Move Side
        else if (absXDifference > 1 && absYDifference==0 )
        {
            tCoordinate[0] += DecreaseByOne(xDifference, absXDifference);
        }
        //Move UpDown
        else if(absXDifference==0 && absYDifference>1 )
        {
            tCoordinate[1] += DecreaseByOne(yDifference, absYDifference);
        }
        else if( absYDifference>0 && absXDifference>0)
        {
            if(absYDifference>absXDifference)
            {
                tCoordinate[0] += xDifference;
                tCoordinate[1] += DecreaseByOne(yDifference, absYDifference);
            }
            else if(absYDifference== absXDifference)
            {
                tCoordinate[0] += DecreaseByOne(xDifference, absXDifference);
                tCoordinate[1] += DecreaseByOne(yDifference, absYDifference);
            }
            else
            {
                tCoordinate[0] += DecreaseByOne(xDifference, absXDifference);
                tCoordinate[1] +=yDifference;
            }

        }


    }
    private static void Draw(int[][] coordinates, string title)
    {
        var xStart = coordinates.Min(x => x[0]);
        var yStart = coordinates.Min(x => x[1]);
        var xEnd = coordinates.Max(x => x[0]);
        var ySize = coordinates.Max(x => x[1]);
        Console.WriteLine(title);
        for(int i=ySize; i >= yStart; i--)
        {
            for(int j = xStart; j <= xEnd; j++)
            {
                int link = -1;
                for(int k=0; k<coordinates.Length; k++)
                {
                    if(coordinates[k][0] == j && coordinates[k][1] == i)
                    {
                        link = k;
                        break;
                    }
                }
                if (link>=0 )
                {
                    Console.Write(link);
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();

        }
    }
    private static int DecreaseByOne(int num,int absNum)
    {
        return (absNum-1) * (num/absNum) ;
    }
}