using System;

namespace DataStructures
{
    [Serializable]
    public struct Rite
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Rite(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public override string ToString()
        {
            var str = "\t< -- [Rite] -- >\n";
            str += $"\tName: {Name}\n";
            str += $"\tType: {Type}\n";
            str += $"\tDesc: {Description}\n";
            return str;
        }
    }
}