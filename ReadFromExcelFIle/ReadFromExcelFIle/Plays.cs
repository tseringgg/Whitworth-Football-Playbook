using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromExcelFIle
{
    [Serializable]
    public class Play<Type>
    {
        public List<concept> DataTable { get; set; }
        //public String Full_Play { get; set; }
        public Play() { }
        public Play(string name, List<Type> list)
        {
            this.name = name;
            table = list;
        }

        public List<Type> table { get; set; }

        public string name { get; set; }
    }

    [Serializable]
    public class concept
    {
        public string? name { get; set; }
        public string? xRoute { get; set; }
        public string? yRoute { get; set; }
        public string? hRoute { get; set; }
        public string? zRoute { get; set; }
        public string? tRoute { get; set; }

        public concept() { }

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


}
