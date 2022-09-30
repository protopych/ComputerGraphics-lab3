using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(776,407);
        }
                   
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.LightGray);
            
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            Random rnd = new Random();
            int x0 = rnd.Next(w);
            int y0 = rnd.Next(h);
            int x1 = rnd.Next(w);
            int y1 = rnd.Next(h);
            int x2 = rnd.Next(w);
            int y2 = rnd.Next(h);

            var p1 = new Point(x0, y0);
            var p2 = new Point(x1, y1);
            var p3 = new Point(x2, y2);
            Triangle(p1,p2,p3);

            pictureBox1.Invalidate();

        }

        void Triangle(Point p1, Point p2, Point p3)
        {
            if (p1.Y == p2.Y && p1.Y == p3.Y) return;

            if (p1.Y > p2.Y)
                Swap(ref p1, ref p2);

            if (p1.Y > p3.Y)
                Swap(ref p1, ref p3);

            if (p2.Y > p3.Y)
                Swap(ref p3, ref p2);

            int total_height = p3.Y - p1.Y;
            for (int i = 0; i < total_height; i++)
            {

                bool second_half = i > p2.Y - p1.Y || p2.Y == p1.Y;
                int segment_height = second_half ? p3.Y - p2.Y : p2.Y - p1.Y;
                float alpha = (float)i / total_height;
                float beta = (float)(i - (second_half ? p2.Y - p1.Y : 0)) / segment_height;
                var pa = new Point((int)(p1.X + (p3.X - p1.X) * alpha), (int)(p1.Y + (p3.Y - p1.Y) * alpha));
                var pb = second_half ? new Point((int)(p2.X + (p3.X - p2.X) * beta), (int)(p2.Y + (p3.Y - p2.Y) * beta)) : new Point((int)(p1.X + (p2.X - p1.X) * beta), (int)(p1.Y + (p2.Y - p1.Y) * beta));

                if (pa.X > pb.X)
                    Swap(ref pa, ref pb);

                for (int j = pa.X; j <= pb.X; j++)
                {
                    double r = 255;
                    double g = 255;
                    double b = 255;
                    var color = Color.FromArgb((int)(r * (total_height - i) / total_height), (int)(g * (i + 1) / (p3.Y - p1.Y)), (int)(b * (pb.X - j) / (pb.X - pa.X + 1)));
                    (pictureBox1.Image as Bitmap).SetPixel(j, p1.Y + i, color);
                }
            }
        }


    }
}


