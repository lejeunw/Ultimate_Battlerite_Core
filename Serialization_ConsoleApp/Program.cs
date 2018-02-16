using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DataStructures;

namespace Serialization_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string xmlAssets = "xml_assets/";
            // GenerateXmlTemplateDemo(xmlAssets+"template-demo.xml");
            var db = new List<string>
            {
                xmlAssets+"Jade.xml",
                xmlAssets+"Alysia.xml"
            };
            var champions = ImportChampions(db);

            // print every champion in your imported 'database'
//            foreach (var champ in champions)
//            {
//                Console.WriteLine(champ.ToString());
//            }

            // use LINQ
            var count = (from c in champions where c.Type == "Ranged" select c.Rites).Count();
            Console.WriteLine($"count: {count}");
            
            
            void GenerateXmlTemplateDemo(string path)
            {
                // generate basic dummy champion with i rites
                var champ = new Champion("champ_name", "champ_type", "champ_desc", new List<Rite>());
                for (var i = 1; i < 5; i++)
                    champ.Rites.Add(new Rite($"rite_name_{i}", $"rite_type_{i}", $"rite_desc_{i}"));

                // use ToString() function of the object
                Console.WriteLine(champ.ToString());
            
                // serialize and write to file
                var xs = new XmlSerializer(typeof(Champion));
                using (var wr = new StreamWriter($"{path}"))
                {
                    xs.Serialize(wr, champ);
                    Console.WriteLine($"Serialized {champ.Name} to {path}");
                    wr.Close();
                }
            }

            List<Champion> ImportChampions(List<string> files)
            {
                // create new list of champions to store
                var champs = new List<Champion>();
                
                // cycle through your list of file paths
                foreach (var file in files)
                {
                    // check if they exist, if not, continue to next file
                    if (!File.Exists(file))
                    {
                        Console.WriteLine($"{file} does not exist.");
                        continue;
                    }
                    // create a read stream of the specified file
                    using (var rd = new StreamReader($"{file}"))
                    {
                        // create a new XmlSerializer of type Champion
                        var xs = new XmlSerializer(typeof(Champion));
                        // since xs is cast into champion we are supposed to know how it is architectured
                        // we can hence deserialize the XML data correctly from our read stream
                        var champ = (Champion) xs.Deserialize(rd);
                        // add your champion the your list of all the imported champions
                        champs.Add(champ);
                        rd.Close();
                    }
                }
                return champs;
            }
        }
    }
}