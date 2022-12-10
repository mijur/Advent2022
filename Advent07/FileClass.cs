using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent07
{
    public class FileClass
    {
        private int _size;
        public bool ContainsDir { get=>Files.Any(x=>x.Files.Count==0); }
        public bool IsDir { get=>Files.Count>0; }
        public int Size { get => Files.Count > 0 ? Files.Sum(x => x.Size) : _size; }
        //public int Size { get =>  _size; }
        public string Name;
        public List<FileClass> Files;
        public FileClass Parent;
        public FileClass(string name,int size=0,FileClass parent=null)
        {
            Files = new();
            Name = name;
            _size = size;
            if(parent != null)
                Parent = parent;
        }
    }
}
