using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Dictionary<int,List<char>> hangar= new();
        var input = File.ReadAllLines("input.txt");
        Scaffold(input, hangar,out var commands);
        performCommands(commands, hangar);
        string result = "";
        var orderedHangar =hangar.OrderBy(x => x.Key);
        foreach(var stack in orderedHangar)
        {
            result+=stack.Value.FirstOrDefault();
        }
        Console.WriteLine(result);
    }

    private static void Scaffold(string[] input, Dictionary<int, List<char>> hangar, out string[] commands)
    {
        Regex crateRegex = new Regex("[A-Z]");
        bool commandsStarted = false;
        commands = new string[1];
        Dictionary<int, List<char>> temp = new();
        for (int i= 0;i < input.Length;i++)
        {
            if (String.IsNullOrEmpty(input[i]) || commandsStarted)
            {
                if (!commandsStarted)
                {
                    commandsStarted = true;

                    foreach (var dupa in temp)
                    {
                        hangar.Add(dupa.Key, new List<char>(dupa.Value.ToArray()));
                    }
                    commands = input.TakeLast(input.Length - i-1).ToArray();
                }

            }
            else if(commandsStarted==false)
            {
                var crates = crateRegex.Matches(input[i]);
                foreach (Match crate in crates)
                { 
                    if (temp.TryGetValue((crate.Index/4)+1, out var stack))
                    {
                        stack.Add(crate.Value.First());
                    }
                    else
                    {
                        temp.Add((crate.Index/4)+1, new List<char>(new[] { crate.Value.First() }));
                    }
                }
            }
        }

    }
    private static void performCommands(string[] commands, Dictionary<int,List<char>> hangar)
    {
        Regex commandRegex = new Regex("[0-9]+");
        for (int i = 0; i < commands.Length; i++)
        {
            var command = commandRegex.Matches(commands[i]);
            int count = int.Parse(command[0].Value);
            int from = int.Parse(command[1].Value);
            int to = int.Parse(command[2].Value);
            var command2 = commands[i].Split(' ');
            int count2 = int.Parse(command2[1]);
            int from2 = int.Parse(command2[3]);
            int to2 = int.Parse(command2[5]);

            if(count!=count2 || from!=from2 || to != to2)
            {
                throw new Exception("wtf");
            }
            var fromCountPre = hangar[from].Count;
            var toCountPre = hangar[to].Count;
            //for (int j = 0; j < count; j++)
            //{
            hangar[to].InsertRange(0,hangar[from].Take(count));
            hangar[from].RemoveRange(0, count);
                //hangar[to].Push(hangar[from].Pop());
            //}
            var fromCountPost = hangar[from].Count;
            var toCountPost = hangar[to].Count;
            if (fromCountPost + count != fromCountPre || toCountPost - count != toCountPre)
                throw new Exception("wtf"); 
        }
    }
    /*
     * rows := [9][64]int32{
       {'N', 'C', 'R', 'T', 'M', 'Z', 'P', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'D', 'N', 'T', 'S', 'B', 'Z', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'M', 'H', 'Q', 'R', 'F', 'C', 'T', 'G', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'G', 'R', 'Z', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'Z', 'N', 'R', 'H', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'F', 'H', 'S', 'W', 'P', 'Z', 'L', 'D', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'W', 'D', 'Z', 'R', 'C', 'G', 'M', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'S', 'J', 'F', 'L', 'H', 'W', 'Z', 'Q', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
       {'S', 'Q', 'P', 'W', 'N', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
    } 
    * rows := [9][64]int32{
       {'H', 'L', 'R', 'F', 'B', 'C', 'J', 'M', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'D', 'C', 'Z', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'W', 'G', 'N', 'C', 'F', 'J', 'H', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'B', 'S', 'T', 'M', 'D', 'J', 'P', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'J', 'R', 'D', 'C', 'N', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'Z', 'G', 'J', 'P', 'Q', 'D', 'L', 'W', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'H', 'R', 'F', 'T', 'Z', 'P', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'G', 'M', 'V', 'L', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'},
{'J', 'R', 'Q', 'F', 'P', 'G', 'B', 'C', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'}}
     */
    private static string[,] To2DArray(Dictionary<int, List<string>> hangar)
    {
        string[,] array = new string[9,64];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j <64; j++)
            {
                array[i, j] = "*";
            }
        }
        var orderedHangar = hangar.OrderBy(x => x.Key);
        for(int i=0; i< hangar.Count; i++)
        {
            for(int j = 0; j < hangar[i].Count; j++)
            {
                array[i, j] = hangar[i][j];
            }
        }
        for (int i = 0; i < 9; i++)
        {
            Console.Write("{");
            for (int j = 0; j < 64; j++)
            {
                Console.Write($"\'{array[i,j]}\', ");
            }
            Console.WriteLine("}");
            Console.WriteLine();
        }
        return array;
    }
    private static int CalculateKey(int from) { return from + (3 * (from - 1)); }

    /*
     *    private static void RunCommands(string[] commands, List<Stack<char>> hangar)
    {
        foreach(var command in commands)
        {
            var split = command.Split(' ');
            var amount = int.Parse(split[1]);
            var from = int.Parse(split[3])-1;
            var to = int.Parse(split[5])-1;
            for(int i =0; i < amount; i++)
            {
                hangar[to].Push(hangar[from].Pop());
            }
            
        }
    }
    private static string[,] To2DArray(Dictionary<int, List<string>> hangar)
    {
        string[,] array = new string[9, 64];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 64; j++)
            {
                array[i, j] = "*";
            }
        }
        var orderedHangar = hangar.OrderBy(x => x.Key);
        for (int i = 0; i < hangar.Count; i++)
        {
            for (int j = 0; j < hangar[i].Count; j++)
            {
                array[i, j] = hangar[i][j];
            }
        }
        for (int i = 0; i < 9; i++)
        {
            Console.Write("{");
            for (int j = 0; j < 64; j++)
            {
                Console.Write($"\'{array[i, j]}\', ");
            }
            Console.WriteLine("}");
            Console.WriteLine();
        }
        return array;
    }
    private static int CalculateKey(int from) { return from + (3 * (from - 1)); }

    static List<Stack<char>> PrepareInput()
    {
        List<Stack<char>> list = new()
        {
            new Stack<char>(new char[]{
                'H',
                'L',
            'R',
            'F',
            'B',
            'C',
            'J',
            'M'}.Reverse()),
            new Stack<char>(new char[] {
            'D',
            'C',
            'Z',
        }.Reverse()),
            new Stack<char>(new char[]{
            'W',
            'G',
            'N',
            'C',
             'F',
             'J',
             'H',
        }.Reverse()),
            new Stack<char>(new char[] {
            'B',
            'S',
            'T',
            'M',
            'D',
            'J',
            'P',
        }.Reverse()),
            new Stack<char>(new char[]{
            'J',
            'R',
            'D',
            'C',
            'N',
        }.Reverse()),
            new Stack<char>(new char[]{
                'Z',
            'G',
            'J',
            'P',
            'Q',
            'D',
            'L',
            'W',
        }.Reverse()),
            new Stack<char>(new char[]{
            'H',
            'R',
            'F',
            'T',
            'Z',
            'P',
        }.Reverse()),
            new Stack<char>(new char[]{
            'G',
            'M',
            'V',
            'L'
        }.Reverse()),
            new Stack<char>(new char[]{
                'J',
            'R',
        'Q',
        'F',
        'P',
        'G',
        'B',
        'C'
        }.Reverse())
        };
        return list;
    }
     */
}
