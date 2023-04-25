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

        public concept()
        {
            
        }

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
    class jsonTest
    {
        static void Main()
        {
            concept firstConcept = new concept("Gator", "Slant", null, "Fade", null, "Hook");


            string json = JsonConvert.SerializeObject(firstConcept);
            string directory = Directory.GetCurrentDirectory();
            Console.WriteLine(directory);
            //File.WriteAllText(@"../../../file.json", json);

            string json2 = File.ReadAllText("C:\\Users\\ajt44\\OneDrive\\Documents\\softwareEngineering\\seTests\\fullProj1\\whitworth-football\\jsonTests\\serializeTest\\serializeTest\\file.json");
            concept secondConcept = JsonConvert.DeserializeObject<concept>(json2);
            Console.WriteLine(secondConcept.name);
        }
    }
    
}