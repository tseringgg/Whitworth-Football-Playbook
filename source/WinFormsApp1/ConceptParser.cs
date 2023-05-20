using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinFormsWithAspose
{
    public class ConceptParser
    {
        //concept name and player that is tagged
        public string name;
        public string? taggedPlayer;
        public ConceptParser(string name , string taggedPlayer )
        {
            this.name = name;
            this.taggedPlayer = taggedPlayer;
            
        }

        public List<String> assignPlayer()
        {
            //deserialize concept json file
            List<string> assignedRoutes = new List<string>();
            List<ConceptData> conceptTable = JsonConvert.DeserializeObject<DataTable<ConceptData>>(File.ReadAllText(@"../../../concepts.json")).table;
            //find concept from table that is same as conceptParser name
            var x = conceptTable.Find(y => y.name.ToUpper() == name.ToUpper());

            //here are all of the various edge cases and rules that whitworth's offense has
            //for the most part, 2x2 concepts make the H and X, and Y and Z grouped together
            //that is different for some concepts and 3x1 formations so those rules are hard coded into
            //these if statements
            if (x.routes.Count == 2 && taggedPlayer == "H" && name == "SHALLOW")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Y");
            }
            else if (x.routes.Count == 2 && name == "DASH")
            {
                assignedRoutes.Add("X");
                assignedRoutes.Add("Y");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "Z" && name == "PYLON")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "H" && name == "TIGER")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Z");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "Z" && name == "TRAIL")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "H" && name == "TIGER")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Z");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "Z" && name == "HEAT")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "Y")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Z");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "X")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
            }
            else if (x.routes.Count == 2 && taggedPlayer == "Z")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Y");
            }
            
            else if (x.routes.Count == 2 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }

            //three man concepts
            else if (x.routes.Count == 3 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Y");
                assignedRoutes.Add("Z");
            }
            else if (x.routes.Count == 3 && taggedPlayer == "Y")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
                assignedRoutes.Add("Z");
            }

            //these are the four man concepts
            else if (x.routes.Count == 4 && taggedPlayer == "Z")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
                assignedRoutes.Add("X");
                assignedRoutes.Add("Y");
            }
            else if (x.routes.Count == 4 && taggedPlayer == "Y")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
                assignedRoutes.Add("X");
                assignedRoutes.Add("Z");
            }
            else if (x.routes.Count == 4 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
                assignedRoutes.Add("Y");
                assignedRoutes.Add("Z");
            }
            else if (x.routes.Count == 4 && taggedPlayer == "X")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
                assignedRoutes.Add("Y");
                assignedRoutes.Add("Z");
            }
            //this is if a one man route concept is called
            else if (x.routes.Count == 1)
            {
                assignedRoutes.Add(taggedPlayer);
            }
            return assignedRoutes;
        }

        public List<string> assignRoutes()
        {
            //deserialize concepts json file
            List<string> routes = new List<string>();
            List<ConceptData> conceptTable = JsonConvert.DeserializeObject<DataTable<ConceptData>>(File.ReadAllText(@"../../../concepts.json")).table;

            //breaks down concepts into actual route combinations
            foreach (ConceptData concept in conceptTable)
            {
                if (this.name.ToUpper() == concept.name.ToUpper())
                {
                    foreach(string route in concept.routes)
                    {
                        routes.Add(route);
                    }
                }
            }
            return routes;
        }

    }
}
