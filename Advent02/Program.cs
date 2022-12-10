internal class Program
{
    static Dictionary<Oponent, Me> winTable = new Dictionary<Oponent, Me>
    {
        {Oponent.A ,Me.Y},
        {Oponent.B ,Me.Z},
        {Oponent.C ,Me.X}
    };
    static Dictionary<Oponent, Me> loseTable = new Dictionary<Oponent, Me>
    {
        {Oponent.A ,Me.Z},
        {Oponent.B ,Me.X},
        {Oponent.C ,Me.Y}
    };
    /// <summary>
    /// A,X-rock        1p
    /// B,Y-Paper       2p
    /// C,Z-Scissors    3p
    /// 0p-lost
    /// 3p-draw
    /// 6p-win
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var rounds = File.ReadAllLines("Strategy.txt");
        int points = 0;
        foreach (var round in rounds)
        {
            var oponnent = (Oponent)Enum.Parse(typeof(Oponent), round.First().ToString());
            var me = (Me)Enum.Parse(typeof(Me), round.Last().ToString());

            switch (me)
            {
                case Me.X:
                        me = loseTable[oponnent];
                    break;
                case Me.Y:
                    me = (Me)(int)oponnent;
                    break;
                case Me.Z:
                    me = winTable[oponnent];
                    break;
            }

            points += (int)me;
            if ((int)oponnent == (int)me)
            {
                //draw
                points += 3;
            }
            else if (me == winTable[oponnent])
            {
                //won
                points += 6;
            }
        }
        Console.WriteLine(points);
    }

    public enum Oponent
    {
        A = 1,
        B,
        C
    }
    public enum Me
    {
        X = 1,
        Y,
        Z
    }
    public enum Result
    {
        X = 0,
        Y = 3,
        Z = 6
    }
}