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
        public string name;
        public List<string> routes;
        public string? taggedPlayer;
        public ConceptParser(string name, List<string> routes , string taggedPlayer )
        {
            this.name = name;
            this.taggedPlayer = taggedPlayer;
            this.routes = routes;
        }

        public List<String> assignPlayer()
        {
            List<string> assignedRoutes = new List<string>();
            if (routes.Count == 2 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }
            else if (routes.Count == 2 && taggedPlayer == "Y" && name == "Flat")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }
            else if (routes.Count == 2 && name == "Dash")
            {
                assignedRoutes.Add("X");
                assignedRoutes.Add("Y");
            }
            else if (routes.Count == 2 && taggedPlayer == "Z" && name == "Pylon")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
            }
            else if (routes.Count == 2 && taggedPlayer == "H" && name == "Tiger")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Z");
            }
            else if (routes.Count == 2 && name == "Bunny")
            {
                assignedRoutes.Add("Z");
                assignedRoutes.Add("H");
            }
            else if (routes.Count == 2 && taggedPlayer == "Z" && name == "Trail")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }
            else if (routes.Count == 2 && taggedPlayer == "Z" && name == "Heat")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
            }
            else if (routes.Count == 2 && taggedPlayer == "Y")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Z");
            }
            else if (routes.Count == 2 && taggedPlayer == "X")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
            }
            else if (routes.Count == 2 && taggedPlayer == "Z")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Y");
            }
            else if (routes.Count == 3 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("Y");
                assignedRoutes.Add("Z");
            }
            else if (routes.Count == 3 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
                assignedRoutes.Add("Z");
            }
            else if (routes.Count == 4 && taggedPlayer == "Z")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("H");
                assignedRoutes.Add("X");
                assignedRoutes.Add("Y");
            }
            else if (routes.Count == 4 && taggedPlayer == "H")
            {
                assignedRoutes.Add(taggedPlayer);
                assignedRoutes.Add("X");
                assignedRoutes.Add("Y");
                assignedRoutes.Add("Z");
            }

            return assignedRoutes;
        }

        public List<string> assignRoutes(List<string> concepts)
        {
            List<string> routes = new List<string>();
            List<ConceptData> conceptTable = JsonConvert.DeserializeObject<DataTable<ConceptData>>(File.ReadAllText(@"../../../concepts.json")).table;

            foreach (ConceptData concept in conceptTable)
            {
                foreach(string s in concepts)
                {
                    if (s == concept.name)
                    {
                        foreach(string route in concept.routes)
                        {
                            routes.Add(route);
                        }
                    }
                }
            }

            return routes;


        }

    }
}
