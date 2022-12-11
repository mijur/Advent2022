using System.Globalization;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var line = File.ReadAllText("input.txt");
        var monkeys = line.Split("Monkey").Skip(1).ToArray();
        Dictionary<int, Monkey> monkeyDictionary = new();
        for (int i = 0; i < monkeys.Length; i++)
        {
            var monkey = new Monkey(monkeys[i]);
            monkeyDictionary.Add(monkey.Id, monkey); 
        }
        foreach(var monkey in monkeyDictionary)
        {
            monkey.Value.Initialize();
        }
        for (int i = 1; i <= 10000; i++)
        {
            //Console.WriteLine($"-----------Start round{i}-----------------");
            for (int j = 0; j < monkeyDictionary.Count; j++)
            {
                var monkey = monkeyDictionary[j];
                while (monkey.Items.Count != 0)
                {
                    var item = monkey.Inspect();
                    monkey.RemoveFirst();
                    var targetMonkey = monkey.GetTarget(item);
                    monkeyDictionary[targetMonkey].AddItem(item);
                    //Console.WriteLine($"monkey{j} throws item{item} to monkey{targetMonkey}");
                }
            }
                //Console.WriteLine($"-----------After round{i}-----------------");
                //for (int j = 0; j < monkeyDictionary.Count; j++)
                //{
                //    Console.WriteLine($"monkey{j} count:{monkeyDictionary[j].Items.Count}");
                //    Console.WriteLine($"monkey{j} inspected:{monkeyDictionary[j].inspectionCount}");
                //    monkeyDictionary[j].Items.ForEach(x => Console.Write($"{x}, "));
                //    Console.WriteLine();
                //}
        }
        var twoMostActive = monkeyDictionary.Values.Select(x => x.inspectionCount).OrderByDescending(x => x).Take(2);
        var answer = twoMostActive.First() * twoMostActive.Last();
        Console.WriteLine(answer);
    }

    class Monkey
    {
        static Regex numberRegex = new Regex("[0-9]+");
        char _operator;
        string[] operationElements;
        public int divisibleBy;
        int trueThrow;
        int falseThrow;
        int b;
        public long inspectionCount = 0;
        static int common=1;
        public Monkey(string monkey)
        {
            var attr = monkey.Split("\r\n");
            Id = int.Parse(attr[0].TrimEnd(':'));
            var matches = numberRegex.Matches(attr[1]);
            Items = new();
            operationElements = attr[2].Split('=')[1].Split(' ').TakeLast(3).ToArray();
            divisibleBy = int.Parse(numberRegex.Match(attr[3]).Value);
            foreach (Match m in matches)
            {
                Items.Add(long.Parse(m.Value));

            }
            common *= divisibleBy;
            trueThrow = int.Parse(numberRegex.Match(attr[4]).Value);
            falseThrow = int.Parse(numberRegex.Match(attr[5]).Value);
            _operator = operationElements[1][0];
            b = operationElements[2] == "old" ? -1 : int.Parse(operationElements[2]);
        }
        public void Initialize()
        {
            for (int i=0; i<Items.Count;i++)
            {
                Items[i] %= common;
            }
        }


        public long Inspect()
        {
            inspectionCount++;
            return Inspect(Items[0]);
        }
        private long Inspect(long item)
        {
            long result = (b == -1 ? item : b);
            switch (_operator)
            {
                case '+':
                    result += item;
                    break;
                case '*':
                    result *= item;
                    break;
            }
            return result;

        }
        public void RemoveFirst()
        {
            Items.RemoveAt(0);
        }
        public void AddItem(long item)
        {
            Items.Add(item%common);
        }
        public int GetTarget(long item)
        {
            bool result =(item % divisibleBy) == 0;
            return result ? trueThrow : falseThrow;
        }
        public int Id;
        public List<long> Items;
    }
}