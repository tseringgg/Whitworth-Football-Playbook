using Aspose.Diagram;
using System.Linq;

namespace WinFormsWithAspose
{
    public static class VisioPageExtensions
    {
        public static Page DrawCenterFormation(this Page page, double x, double y, double width, double height, double space)
        {
            page.DrawRectangle(x, y, width, height);
            page.DrawEllipse(x - space, y, width, height);
            page.DrawEllipse(x - 2 * space, y, width, height);
            page.DrawEllipse(x + space, y, width, height);
            page.DrawEllipse(x + 2 * space, y, width, height);
            return page;
        }
        private static Page DrawTextBubble(this Page page, ITextBubble tb)
        {
            page.DrawEllipse(tb.X, tb.Y, tb.Width, tb.Height);
            page.AddText(tb.X, tb.Y, 0.1, 0, tb.Label, "Calibri", "Black", 0.2);
            return page;
        }
        public static Page DrawTextBubbles(this Page page, ITextBubbleGroup tbg)
        {
            tbg.TextBubbles.ForEach(tb =>
            {
                tb.X += tbg.GetX();
                tb.Y += tbg.GetY();
                page.DrawTextBubble(tb);
            });
            return page;
        }
    }
}
