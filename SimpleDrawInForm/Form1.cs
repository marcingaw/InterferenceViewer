using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimpleDrawInForm
{
    public partial class Form1 : Form
    {
        private List<Tuple<float, float>>
            pointsR = new List<Tuple<float, float>>(),
            pointsG = new List<Tuple<float, float>>(),
            pointsB = new List<Tuple<float, float>>(),
            points = null;  // The current list of points to operate on.

        private List<List<Tuple<float, float>>> allPoints = new List<List<Tuple<float, float>>>();

        private double distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public Form1()
        {
            allPoints.Add(pointsR);
            allPoints.Add(pointsG);
            allPoints.Add(pointsB);
            InitializeComponent();
        }

        private struct BitmapFragment
        {
            public BitmapFragment(Bitmap bm, int dx, int dy, int width, int height, double fadeRate, Graphics gr)
            {
                this.bm = bm;
                this.dx = dx;
                this.dy = dy;
                this.width = width;
                this.height = height;
                this.fadeRate = fadeRate;
                this.gr = gr;
            }

            public readonly Bitmap bm;          // The bitmap to draw on.
            public readonly int dx, dy;         // Coordinates of the upper left corner of 'bm' on the whole picture.
            public readonly int width, height;  // Size of the whole picture.
            public readonly double fadeRate;    // Wave fade rate for distance, 10% of 'waveFadeRate.Value'.

            public readonly Graphics gr;        // The context where to eventually draw to image in.
        }

        private void drawFragment(BitmapFragment bf)
        {
            for (int x = bf.dx, xl = bf.dx + bf.bm.Width; x < xl; ++x)
            {
                for (int y = bf.dy, yl = bf.dy + bf.bm.Height; y < yl; ++y)
                {
                    int r = 0, g = 0, b = 0;

                    foreach (List<Tuple<float, float>> pts in allPoints)
                    {
                        if (pts.Count > 0)
                        {
                            double wave = 0, waves = 0;

                            foreach (Tuple<float, float> p in pts)
                            {
                                int px = (int)(p.Item1 * bf.width);
                                int py = (int)(p.Item2 * bf.height);
                                double dist = distance(x, y, px, py);
                                wave += Math.Pow(bf.fadeRate, dist / 63) * Math.Cos(0.05 * dist);
                                ++waves;
                            }

                            if (pts == pointsR)
                            {
                                r = (int)(127 + 127 * (wave / waves));
                            }
                            else if (pts == pointsG)
                            {
                                g = (int)(127 + 127 * (wave / waves));
                            }
                            else
                            {
                                b = (int)(127 + 127 * (wave / waves));
                            }
                        }
                    }

                    bf.bm.SetPixel(x - bf.dx, y - bf.dy, Color.FromArgb(r, g, b));
                }
            }

            lock (bf.gr)
            {
                bf.gr.DrawImage(bf.bm, bf.dx, bf.dy);
            }
        }

        private void drawFragmentObj(Object bitmapFragment)
        {
            drawFragment((BitmapFragment)bitmapFragment);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const bool MULTITHREADED = true;

            Graphics gr = e.Graphics;
            RectangleF vcb = gr.VisibleClipBounds;

            if (MULTITHREADED)
            {
                const int DELTA = 100;

                int width = (int)vcb.Width;
                int height = (int)vcb.Height;
                List<Tuple<Thread, BitmapFragment>> threads = new List<Tuple<Thread, BitmapFragment>>();

                for (int x = 0; x < width; x += DELTA)
                {
                    for (int y = 0; y < height; y += DELTA)
                    {
                        Thread thread = new Thread(drawFragmentObj);
                        BitmapFragment bf = new BitmapFragment(
                            new Bitmap(DELTA, DELTA), x, y, width, height, 0.1 * waveFadeRate.Value, gr);
                        threads.Add(new Tuple<Thread,BitmapFragment>(thread, bf));
                        thread.Start(bf);
                    }
                }

                foreach (Tuple<Thread, BitmapFragment> thread in threads) thread.Item1.Join();
            }
            else
            {
                drawFragment(new BitmapFragment(
                    new Bitmap((int)vcb.Width, (int)vcb.Height),
                    0, 0, (int)vcb.Width, (int)vcb.Height,
                    0.1 * waveFadeRate.Value, gr));
            }

            foreach (List<Tuple<float, float>> pts in allPoints)
            {
                Pen pen = pts == pointsR ? Pens.DarkRed : pts == pointsG ? Pens.DarkGreen : Pens.DarkBlue;

                foreach (Tuple<float, float> p in pts)
                {
                    gr.DrawEllipse(pen, new Rectangle
                    {
                        X = (int)(p.Item1 * vcb.Width) - 5,
                        Y = (int)(p.Item2 * vcb.Height) - 5,
                        Width = 10,
                        Height = 10
                    });
                }
            }
        }

        private void makeBold(Button b)
        {
            b.Font = new Font(b.Font, b.Font.Style | FontStyle.Bold);
        }

        private void makeRegular(Button b)
        {
            b.Font = new Font(b.Font, b.Font.Style & ~FontStyle.Bold);
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            makeBold(buttonR);
            makeRegular(buttonG);
            makeRegular(buttonB);
            points = pointsR;
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            makeRegular(buttonR);
            makeBold(buttonG);
            makeRegular(buttonB);
            points = pointsG;
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            makeRegular(buttonR);
            makeRegular(buttonG);
            makeBold(buttonB);
            points = pointsB;
        }

        private void waveFadeRate_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            makeRegular(buttonR);
            makeRegular(buttonG);
            makeRegular(buttonB);
            points = null;
            pointsR.Clear();
            pointsG.Clear();
            pointsB.Clear();
            waveFadeRate.Value = 9;
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            waveFadeRate.Value = 9;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (points == null) return;

            Rectangle cr = this.ClientRectangle;

            foreach (Tuple<float, float> p in points)
            {
                int x = (int)(p.Item1 * cr.Width);
                int y = (int)(p.Item2 * cr.Height);

                if (distance(e.X, e.Y, x, y) < 5)
                {
                    points.Remove(p);
                    Invalidate();
                    return;
                }
            }

            points.Add(new Tuple<float, float>(
                (float)e.X / cr.Width,
                (float)e.Y / cr.Height
            ));

            Invalidate();
        }
    }
}
