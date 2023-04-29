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

    class formation
    {
        public string? name;
        public double x_x;
        public double x_y;
        public double h_x;
        public double h_y;
        public double t_x;
        public double t_y;
        public double q_x;
        public double q_y;
        public double y_x;
        public double y_y;
        public double z_x;
        public double z_y;

        public formation() { }

        public formation(string name, double x_x, double x_y, double h_x, double h_y, double t_x, double t_y, double q_x, double q_y, double y_x, double y_y, double z_x, double z_y)
        {
            this.name = name;
            this.x_x = x_x;
            this.x_y = x_y; 
            this.h_x = h_x;
            this.h_y = h_y;
            this.t_x = t_x;
            this.t_y = t_y;
            this.q_x = q_x;
            this.q_y = q_y;
            this.y_x = y_x;
            this.y_y = y_y;
            this.z_x = z_x;
            this.z_y = z_y; 

        }
    }

    class fullPlay
    {
        public string name;
        public string playCall;
        public string formation;
        public string? motion;
        public string? protection;
        public string concept;
        public string tags;

        public fullPlay() { }

        public fullPlay(string name, string playCall, string formation, string motion, string protection, string concept, string tags)
        {
            this.name = name;
            this.playCall = playCall;
            this.formation = formation;
            this.motion = motion;
            this.protection = protection;
            this.concept = concept;
            this.tags = tags;
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