using System.Drawing;
using System.Windows.Forms;

public static class FormDragHelper
{
    private static bool dragging = false;
    private static Point dragCursorPoint;
    private static Point dragFormPoint;

    public static void MakeDraggable(Form form, Control handle)
    {
        handle.MouseDown += (sender, e) =>
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = form.Location;
        };

        handle.MouseMove += (sender, e) =>
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                form.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        };

        handle.MouseUp += (sender, e) =>
        {
            dragging = false;
        };
    }
}
