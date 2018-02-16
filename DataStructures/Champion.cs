using System;
using System.Collections.Generic;

namespace DataStructures
{
    [Serializable]
    public struct Champion
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public List<Rite> Rites { get; set; }

        public Champion(string name, string type, string description, List<Rite> rites)
        {
            Name = name;
            Type = type;
            Description = description;
            Rites = rites;
        }

        public override string ToString()
        {
            var str = "! -- [Champion] -- !\n";
            str += $"Name: {Name}\n";
            str += $"Type: {Type}\n";
            str += $"Desc: {Description}\n";
            foreach (var r in Rites)
            {
                str += r.ToString();
            }
            return str;
        }
    }
}