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
        int x = 0, y = 0, x2 = 0, y2 = 0;
        Bitmap bmp = new Bitmap(400,400);

        public void bresenham(int x0, int y0, int x1, int y1)
        {
            if (x0 > x1) { 
                int t;
                t = x0;
                x0 = x1;
                x1 = t;
                t = y0;
                y0 = y1;
                y1 = t;
            }
            int deltax = x1 - x0;
            int deltay = Math.Abs(y1 - y0);
            int error = 0;
            int deltaerr = (deltay + 1);
            int y = y0;
            int diry = y1 - y0;
            if (diry > 0) diry = 1;
            if (diry < 0)
                diry = -1;
            for (int x = x0; x <= x1; x++) {
                bmp.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                error = error + deltaerr;
                if (error >= deltax + 1)
                {
                    y = y + diry;
                    error = error - (deltax + 1);
                }
            }
        }

        public void wu(int x0, int y0, int x1, int y1)
        {
            bmp.SetPixel(x0, y0, Color.FromArgb(255,0,0,0));
            // Последний аргумент — интенсивность в долях единицы
            float dx = x1 - x0; float dy = y1 - y0;
            float gradient = dy / dx;
            bool rotate = false;
            if (Math.Abs(dy) > Math.Abs(dx)) {
                rotate = true;
                int t;
                t = x0;
                x0 = y0;
                y0 = t;
                t = x1;
                x1 = y1;
                y1 = t;
                gradient = dx / dy;
            }
            if (x0 > x1)
            {
                int t;
                t = x0;
                x0 = x1;
                x1 = t;
                t = y0;
                y0 = y1;
                y1 = t;
            }
            float y = y0 + gradient;
            for (int x = x0 + 1; x <= x1 - 1; x+=1)
            {
                if (rotate)
                {
                    bmp.SetPixel((int)y, x, Color.FromArgb((int)((1.0 - (y - (int)y)) * 255), 0, 0, 0));
                    bmp.SetPixel((int)y+1, x, Color.FromArgb((int)((y - (int)y) * 255), 0, 0, 0));
                }
                else 
                {
                    bmp.SetPixel(x, (int)y, Color.FromArgb((int)((1.0 - (y - (int)y)) * 255), 0, 0, 0));
                    bmp.SetPixel(x, (int)y + 1, Color.FromArgb((int)((y - (int)y) * 255), 0, 0, 0));
                }
                y += gradient;
            }
        }

        public void points(out int x, out int y ,out int x2, out int y2) {
            Random r = new Random();
            x = r.Next(0, bmp.Size.Width);
            y = r.Next(0, bmp.Size.Height);
            x2 = r.Next(0, bmp.Size.Width);
            y2 = r.Next(0, bmp.Size.Height);
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            points(out x, out y, out x2, out y2);
            bresenham(x, y, x2, y2);
            pictureBox1.Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            points(out x, out y, out x2, out y2);
            wu(x, y, x2, y2);
            pictureBox1.Refresh();
        }
    }
}


