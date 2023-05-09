using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace WinFormsWithAspose
{
    public class FourLeftPlayDrawer : IPlayDrawer
    {
        private readonly Page page;
        private readonly List<Play> plays;

        public FourLeftPlayDrawer(Page page, List<Play> plays)
        {
            if(plays.Count > 4)
            {
                throw new ArgumentException("Arg must be a list with a count of 4 or less. Arg count was: " + plays.Count);
            }
            this.page = page;
            this.plays = plays;
        }
        public void Draw()
        {
            double height = this.page.PageSheet.PageProps.PageHeight.Value;
            double width = this.page.PageSheet.PageProps.PageWidth.Value;
            double margin = 0.5;
            double x = 0, y = 0;
            double heightOffset = -1;
            x = width / 3 - margin;
            for (int i = 0; i < 4; i++)
            {
                y = height - (height / 4 * (i + 1) + heightOffset);
                if (plays.Count > i)
                {
                    plays[i].X = x;
                    plays[i].Y = y;
                    plays[i].Scale = 0.5;
                    plays[i].Draw(page);
                }
            }
            //.DrawRouteGroup(play.GetRouteGroup())
        }
    }
}
