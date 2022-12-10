internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var input = File.ReadAllLines("input.txt");
        int cycleCount = 0;
        int x=1;
        int signalStrength = 0; 
        char[] c = Enumerable.Repeat('.', 40).ToArray();
        char[] frame = new char[40];
        c.CopyTo(frame, 0);
        for (int i = 0; i < input.Length; i++)
        {
            //Console.WriteLine($"intruction: {input[i]}");
            var split = input[i].Split(' ');
            var instruction =Enum.Parse<Instructions>(split[0]);
            //var preX = x;
            for (int j = 1; j <= (int)instruction; j++)
            {
                var carret = cycleCount % 40;
                cycleCount++;
                if (x == carret || x - 1 == carret || x + 1 == carret)
                {
                    frame[carret] = '#';
                }
                if (cycleCount%40==0)
                {
                    signalStrength += cycleCount * x;
                    //Console.WriteLine($"\t cycle[{cycleCount}]: X={x} ; Current Signal {cycleCount * x} ; Total Signal strangth = {signalStrength}");

                    Console.WriteLine(frame);
                    c.CopyTo(frame, 0);
                }
                else
                {
                    //Console.WriteLine($"cycle[{cycleCount}]: X={x} ");
                }
                if (instruction == Instructions.addx && j == (int)Instructions.addx)
                {
                    x += int.Parse(split[1]);
                }

                //Console.WriteLine(frame);

            }
        }
        Console.WriteLine(signalStrength);
    }

    enum Instructions
    {
        noop=1,
        addx
    }
}