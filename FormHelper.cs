using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RECMS
{
    internal static class FormHelper
    {
        public static void MaximizeAndCenter(Form form)
        {
            //Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            //// Set form size to 90% of screen
            //form.Width = (int)(workingArea.Width * 0.9);
            //form.Height = (int)(workingArea.Height * 0.9);

            //// Center the form
            //form.Left = workingArea.Left + (workingArea.Width - form.Width) / 2;
            //form.Top = workingArea.Top + (workingArea.Height - form.Height) / 2;

            //// Optional: force manual position
            //form.StartPosition = FormStartPosition.Manual;
        }
    }
    public static class UIHelpers
    {
        public static void RoundButton(Button button, int radius)
        {
            if (button.Width < radius * 2 || button.Height < radius * 2)
                radius = Math.Min(button.Width, button.Height) / 2;

            Rectangle bounds = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Top-left corner
            path.AddArc(arcRect, 180, 90);

            // Top-right corner
            arcRect.X = bounds.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // Bottom-right corner
            arcRect.Y = bounds.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // Bottom-left corner
            arcRect.X = bounds.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            button.Region = new Region(path);
        }

    }
}

