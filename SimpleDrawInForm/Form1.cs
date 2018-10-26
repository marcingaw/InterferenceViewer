using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleDrawInForm
{
    public partial class Form1 : Form
    {
        private List<Tuple<float, float>> points = new List<Tuple<float, float>>();

        private double distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            RectangleF vcb = g.VisibleClipBounds;

            if (points.Count > 0)
            {
                Bitmap bm = new Bitmap((int)vcb.Width, (int)vcb.Height);

                for (int x = 0, xl = bm.Width; x < xl; ++x)
                {
                    for (int y = 0, yl = bm.Height; y < yl; ++y)
                    {
                        double wave = 0, waves = 0;

                        foreach (Tuple<float, float> p in points)
                        {
                            int px = (int)(p.Item1 * vcb.Width);
                            int py = (int)(p.Item2 * vcb.Height);
                            wave += Math.Sin(distance(x, y, px, py) / 10);
                            ++waves;
                        }

                        int c = (int)(127 + 127 * (wave / waves));
                        bm.SetPixel(x, y, Color.FromArgb(c, c, c));
                    }
                }

                g.DrawImage(bm, vcb);
            }

            foreach (Tuple<float, float> p in points)
            {
                g.DrawEllipse(Pens.Red, new Rectangle
                {
                    X = (int)(p.Item1 * vcb.Width) - 5,
                    Y = (int)(p.Item2 * vcb.Height) - 5,
                    Width = 10,
                    Height = 10
                });
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle cr = this.ClientRectangle;

            foreach (Tuple<float, float> p in points)
            {
                int x = (int)(p.Item1 * cr.Width);
                int y = (int)(p.Item2 * cr.Height);

                if (distance(e.X, e.Y, x, y) < 5)
                {
                    points.Remove(p);
                    this.Invalidate();
                    return;
                }
            }

            points.Add(new Tuple<float, float>(
                (float)e.X / cr.Width,
                (float)e.Y / cr.Height
            ));

            this.Invalidate();
        }
    }
}
