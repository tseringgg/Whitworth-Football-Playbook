using Aspose.Diagram;
using WinFormsWithAspose;

namespace WinFormsApp1
{
    public class EightPlayDrawer : IPlayDrawer
    {
        private readonly Page page;
        private readonly List<Play> plays;

        public EightPlayDrawer(Page page, List<Play> plays)
        {
            this.page = page;
            this.plays = plays;
        }
        // Draw the first 8 plays in a list in 8 distinct spots on a grid
        public void Draw()
        {
            double height = this.page.PageSheet.PageProps.PageHeight.Value;
            double width = this.page.PageSheet.PageProps.PageWidth.Value;
            double margin = 0.5;
            double x = 0, y = 0;
            for (int i = 0; i < 8; i++)
            {
                x = width / 3 * (i % 2 + 1) + margin*Math.Pow(-1,(i+1) % 2);
                y = height / 4 * (i / 2) + 1;
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