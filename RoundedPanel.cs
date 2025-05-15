using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class RoundedPanel : Panel
{
    public int BorderRadius { get; set; } = 10;

    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
        path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
        path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
        path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
        path.CloseFigure();

        this.Region = new Region(path);

        base.OnPaint(e);
    }
}
