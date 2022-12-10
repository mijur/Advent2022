using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string[] input = File.ReadAllLines("input.txt");
        var forestWidth = input[0].Length;
        var visibleCount = 0;
        int maxViewingScore = 0;
        int currentViewingScore = 0;
        for(int i=1;i<forestWidth-1; i++)
        {
            bool[] visibility = new bool[4];
            for(int j = 1; j < input[i].Length-1; j++)
            {
                var currentTree = int.Parse(input[i][j].ToString());
                int individualScore = 0;
                //look left
                for(int k=j-1; k>=0; k--)
                {
                    var anotherTree = int.Parse(input[i][k].ToString());
                    visibility[0] = IsVisibleThrough(currentTree, anotherTree);
                    individualScore++;
                    if (!visibility[0] || (k==0 && visibility[0])) {
                            currentViewingScore = individualScore;
                            break;
                        }
                }
                individualScore = 0;
                //look right
                for (int k = j + 1; k < forestWidth; k++)
                {
                    var anotherTree = int.Parse(input[i][k].ToString());

                    visibility[2] = IsVisibleThrough(currentTree, anotherTree);
                    individualScore++;
                    if (!visibility[2] || (k == forestWidth-1 && visibility[0]))
                    {
                        currentViewingScore *= individualScore;
                        break;
                    }
                }
                individualScore = 0;
                //look up
                for (int k = i-1; k>=0; k--)
                {
                    var anotherTree = int.Parse(input[k][j].ToString());

                    visibility[1] = IsVisibleThrough(currentTree, anotherTree);
                    individualScore++;
                    if (!visibility[1] || (k == 0 && visibility[0]))
                    {
                        currentViewingScore *= individualScore;
                        break;
                    }
                }
                individualScore = 0;
                //look down
                for (int k = i+1; k<input.Length; k++)
                {
                    var anotherTree = int.Parse(input[k][j].ToString());

                    visibility[3] = IsVisibleThrough(currentTree, anotherTree);
                    individualScore++;
                    if (!visibility[3] || (k == input.Length-1 && visibility[0]))
                    {
                        currentViewingScore *= individualScore;
                        break;
                    }
                }
                if(currentViewingScore>maxViewingScore)
                    maxViewingScore = currentViewingScore;
                if (visibility[0] || visibility[1] || visibility[2] || visibility[3])
                {
                    visibleCount++;
                    continue;
                }
            }
        }
        visibleCount += (forestWidth * 2) + ((input.Length - 2) * 2);
        Console.WriteLine(visibleCount);
        Console.WriteLine(maxViewingScore);
    }
    public static bool IsVisibleThrough(int main,int another)
    {
        return main > another;
    }
}