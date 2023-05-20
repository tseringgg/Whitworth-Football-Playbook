using Aspose.Diagram;
using WinFormsApp1;

namespace WinFormsWithAspose
{
    public class FourLeftPlayDrawer : IPlayDrawer
    {
        private readonly Page page;
        private readonly List<Play> plays;

        public FourLeftPlayDrawer(Page page, List<Play> plays)
        {
            // should only draw 4 plays at once
            if(plays.Count > 4)
            {
                throw new ArgumentException("Arg must be a list with a count of 4 or less. Arg count was: " + plays.Count);
            }
            this.page = page;
            this.plays = plays;
        }
        public void Draw()
        {
            // get the dimensions of the page
            double height = this.page.PageSheet.PageProps.PageHeight.Value;
            double width = this.page.PageSheet.PageProps.PageWidth.Value;
            double margin = 0.5; // how close the plays are to the edge of page
            double x, y;
            double heightOffset = -1;

            x = width / 3 - margin; // the x coordinate where the column of plays will be printed
            for (int i = 0; i < 4; i++)
            {
                // the y coordinate for a particular play
                y = height - (height / 4 * (i + 1) + heightOffset);
                if (plays.Count > i)
                {
                    plays[i].X = x;
                    plays[i].Y = y;
                    plays[i].Scale = 0.5; // relative scale of the play image
                    plays[i].Draw(page);
                }
            }
            //.DrawRouteGroup(play.GetRouteGroup())
        }
    }
}
