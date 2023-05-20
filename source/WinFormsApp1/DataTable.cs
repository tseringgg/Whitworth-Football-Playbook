using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWithAspose
{
    [Serializable]
    public class DataTable<Type> // a container class used for holding parsed data
    {
        public DataTable() { }
        public DataTable(string name, List<Type> list)
        {
            this.name = name;
            table = list;
        }

        public void add(Type toAdd)
        {
            table.Add(toAdd);
        }

        public void delete(int i)
        {
            table.RemoveAt(i);
        }

        public List<Type> table { get; set; }
        public string name { get; set; }
    };
}
