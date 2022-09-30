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
            
        }

        int x0, y0;
        int x1, y1;
        int x2, y2;
        int w = 776;
        int h = 407;

        Pen pen = new Pen(Color.Black, 3f);

        
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            
            Random rnd = new Random();
            int x0 = rnd.Next(w);
            int y0 = rnd.Next(h);
            int x1 = rnd.Next(w);
            int y1 = rnd.Next(h);
            int x2 = rnd.Next(w);
            int y2 = rnd.Next(h);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

           
            if (y0 > y1)
            {
                Swap(ref y0, ref y1);
                Swap(ref x0, ref x1);              
            }

            if (y0 > y2)
            {
                Swap(ref y0, ref y2);
                Swap(ref x0, ref x2);              
            }

            if (y1 > y2)
            {
                Swap(ref y1,ref y2);
                Swap(ref x1,ref x2);                
            }


            int cross_x1;
            int cross_x2;
            int dx1 = x1 - x0;
            int dy1 = y1 - y0;
            int dx2 = x2 - x0;
            int dy2 = y2 - y0;

            int top_y = y0;

            while (top_y < y1)
            {
                cross_x1 = x0 + dx1 * (top_y - y0) / dy1;
                cross_x2 = x0 + dx2 * (top_y - y0) / dy2;
                if (cross_x1 > cross_x2)
                {
                    
                    g.DrawRectangle(pen,cross_x2, top_y, cross_x1 - cross_x2, 1);
                }
                else
                {
                    
                    g.DrawRectangle(pen, cross_x1, top_y, cross_x2 - cross_x1, 1);
                }

                top_y++;
            }

            dx1 = x2 - x1;
            dy1 = y2 - y1;
            while (top_y < y2)
            {
                cross_x1 = x1 + dx1 * (top_y - y1) / dy1;
                cross_x2 = x0 + dx2 * (top_y - y0) / dy2;
                if (cross_x1 > cross_x2)
                {
                    
                    g.DrawRectangle(pen, cross_x2, top_y, cross_x1 - cross_x2, 1);
                }
                else
                {
                    
                    g.DrawRectangle(pen, cross_x1, top_y, cross_x2 - cross_x1, 1);
                }

                top_y++;
            }
            

        }

       


    }
}


