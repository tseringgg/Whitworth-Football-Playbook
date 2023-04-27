using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace jsonTest
{
    [Serializable]
    class concept
    {
        public string? name { get; set; }
        public string? xRoute { get; set; }
        public string? yRoute { get; set; }
        public string? hRoute { get; set; }
        public string? zRoute { get; set; }
        public string? tRoute { get; set; }

        public concept(){}

        public concept(string name, string? xRoute, string? yRoute, string? hRoute, string? zRoute, string? tRoute)
        {
            this.name = name;
            this.xRoute = xRoute;
            this.yRoute = yRoute;
            this.hRoute = hRoute;
            this.zRoute = zRoute;
            this.tRoute = tRoute;
        }

    }

    [Serializable]
    class DataTable<Type>{
        public DataTable(){}
        public DataTable(string name, List<Type> list){
            this.name = name;
            table = list;
        }

        public void add(Type toAdd){
            table.Add(toAdd);
        }

        public void delete(int i){
            table.RemoveAt(i);
        }

        public List<Type> table{get;set;}
        public string name{get;set;}
    };

    class jsonTest
    {
        static void Main()
        {
            concept firstConcept = new concept("Gator", "Slant", null, "Fade", null, "Hook");
            concept otherConcept = new concept("Hoosier", null, null, "Choice", "Out", null);
            List<concept> concepts = new List<concept>();
            concepts.Add(firstConcept);
            concepts.Add(otherConcept);
            DataTable<concept> conceptTable = new DataTable<concept>("Concepts", concepts);
            

            string json = JsonConvert.SerializeObject(conceptTable, Formatting.Indented);
            string directory = Directory.GetCurrentDirectory();
            Console.WriteLine(directory);
            File.WriteAllText(@"../../../file.json", json);

            string json2 = File.ReadAllText(@"../../../file.json");
            DataTable<concept> secondConcept = JsonConvert.DeserializeObject<DataTable<concept>>(json2);
            Console.WriteLine(secondConcept.table[0].name);
        }
    }
}