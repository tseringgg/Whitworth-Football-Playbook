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
    internal class routeParser
    {
        public float x;
        public float y;
        public string routeName;
        public string routeDirectory;
        public Page page;
        public routeParser(string routeName, string routeDirectory, float x, float y, Page page)
        {
            this.x = x;
            this.y = y;
            this.routeName = routeName;
            this.routeDirectory = routeDirectory;
            this.page = page;
        }

        public RouteData initialize()
        {
// string routeData = File.ReadAllText(routeDirectory);
            List<RouteData> routeTable = JsonConvert.DeserializeObject<DataTable<RouteData>>(File.ReadAllText(@"../../../routes.json")).table;
            var dataObject = routeTable.Find(x => x.name == routeName);
            return dataObject;

        }
    }
}
