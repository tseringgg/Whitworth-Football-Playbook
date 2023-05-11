using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWithAspose
{
    public class Formation
    {
        public string? name;
        public string? side;
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
        public Formation(string name, string side, double x_x, double x_y, double h_x, double h_y, double t_x, double t_y, double q_x, double q_y, double y_x, double y_y, double z_x, double z_y)
        {
            this.name = name;
            this.side = side;
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
}
