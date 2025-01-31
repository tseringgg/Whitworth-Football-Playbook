﻿using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public class Play // holds IDiagramGroups so that their positions line up
    {
        public List<IDiagramGroup> Groups;
        public double X, Y;
        public double Scale { get; set; }
        public Play(List<IDiagramGroup> groups)
        {
            this.X = 0;
            this.Y = 0;
            Scale = 1;
            this.Groups = groups;
        }
        public void Draw(Page page) // set the groups to the same position and scale
        {
            foreach (IDiagramGroup group in Groups)
            {
                group.Scale = Scale;
                group.X = X;
                group.Y = Y;
                group.Draw(page);
            }
        }
    }
}
