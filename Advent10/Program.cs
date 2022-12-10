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
            var split = input[i].Split(' ');
            var instruction =Enum.Parse<Instructions>(split[0]);
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
                    Console.WriteLine(frame);
                    c.CopyTo(frame, 0);
                }
                if (instruction == Instructions.addx && j == (int)Instructions.addx)
                {
                    x += int.Parse(split[1]);
                }
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