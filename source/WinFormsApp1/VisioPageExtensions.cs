using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public static class VisioPageExtensions
    {
        public static void DrawCenterFormation(this Page page, double x, double y, double width, double height, double space)
        {
            page.DrawRectangle(x, y, width, height);
            page.DrawEllipse(x - space, y, width, height);
            page.DrawEllipse(x - 2 * space, y, width, height);
            page.DrawEllipse(x + space, y, width, height);
            page.DrawEllipse(x + 2 * space, y, width, height);
        }
        public static void DrawSkillPlayer(this Page page, string label, double x, double y, double width, double height)
        {
            page.DrawEllipse(x, y, width, height);
            page.AddText(x, y, 0.1, 0, label, "Calibri", "Black", 0.2);
            
        }
    }
}
