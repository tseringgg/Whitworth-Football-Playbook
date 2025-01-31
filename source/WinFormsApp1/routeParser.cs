﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Diagram;
using Newtonsoft.Json;
using PointF = System.Drawing.PointF;

namespace WinFormsWithAspose
{
    internal class RouteParser // for retrieving the route data from the json
    {
        public float x;
        public float y;
        public string routeName;
        
        public Page page;
        public RouteParser(string routeName)
        {
            this.routeName = routeName;
        }

        public RouteData Parse()
        {
            //deserialize route table
            List<RouteData> routeTable = JsonConvert.DeserializeObject<DataTable<RouteData>>(File.ReadAllText(@"../../../routes.json")).table;
            var dataObject = routeTable.Find(x => x.name == routeName);

            //returns routedata object that has same name as route name
            return dataObject;

        }
    }
}
