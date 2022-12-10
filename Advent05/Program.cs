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

            hangar[to].InsertRange(0,hangar[from].Take(count));
            hangar[from].RemoveRange(0, count);

            var fromCountPost = hangar[from].Count;
            var toCountPost = hangar[to].Count;
            if (fromCountPost + count != fromCountPre || toCountPost - count != toCountPre)
                throw new Exception("wtf"); 
        }
    }

}
