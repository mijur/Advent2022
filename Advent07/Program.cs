using Advent07;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;

internal class Program
{
    /*
     * 5324038
     * 5578196
     * 4278843
     */
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string[] terminal = File.ReadAllLines("terminal.txt");
        FileClass root=default;
        foreach(var line in terminal)
        {
            var commandLine = line.Split(' ');
            if (line.StartsWith("$"))
            {
                var command = commandLine[1];

                switch (command)
                {
                    case "cd":
                        var attribute = commandLine[2];
                        if (attribute == "..")
                        {
                            if (root != null)
                            {
                                root = root.Parent;
                            }
                        }
                        else if(attribute == "/")
                        {
                            root = new FileClass(attribute);
                        }
                        else
                        {
                            root = root.Files.First(x => x.Name == attribute);
                        }
                        break;
                    case "ls":
                        {
                        }
                        break;
                }
                continue;
            }
            else
            {
                if (!line.StartsWith("dir"))
                    root.Files.Add(new FileClass(commandLine[1],int.Parse(commandLine[0]),root));
                else
                {
                    root.Files.Add(new FileClass(commandLine[1],parent:root));
                }
            }

        }
        root = ResetTree(root);
        var flattened = Flatten(root);

        var totalSpace = 70000000;
        int spaceLeft = totalSpace - root.Size;
        int requiredSpace = 30000000 - spaceLeft;
        int totalLatgeFileSize = 0;
        int min = totalSpace;
        foreach (var file in flattened)
        {
            int size = file.Size;
            if (file.IsDir && size>=requiredSpace)
            {
                Console.WriteLine(file.Name);
                if (min > size)
                    min = size;
                totalLatgeFileSize += size;
            }
            
        }
        Console.WriteLine($"Answer: {totalLatgeFileSize}");
        Console.WriteLine($"Answer2: {min}");

    }


    public static IEnumerable<FileClass> Flatten(FileClass dir)
    {
        return new[] { dir }.Concat(dir.Files.SelectMany(Flatten));
    }
    public static FileClass ResetTree(FileClass root)
    {
        while (true)
        {
            root = root.Parent;
            if (root.Parent == null)
            {
                break;
            }
        }
        return root;
    }
}