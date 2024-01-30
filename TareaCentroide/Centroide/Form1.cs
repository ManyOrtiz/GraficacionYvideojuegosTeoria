using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Centroid
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Bitmap bmp;
        Graphics g;
        DrawLine line;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            bmp = new Bitmap(PicCanva.Width, PicCanva.Height);
            g = Graphics.FromImage(bmp);
            PicCanva.Image = bmp;
            canvas = new Canvas(bmp, PicCanva);
            line = new DrawLine(bmp, PicCanva);

            canvas.Render();
            line.RenderLine(g);
            PicCanva.Invalidate();
        }

        private void ActualizarAnguloDesdeTextBox()
        {
            if (double.TryParse(textBox1.Text, out double angulo))
            {
                canvas.ActualizarAnguloRotacion(angulo);
                canvas.Render();
                line.RenderLine(g);
                PicCanva.Invalidate();
            }

        }

        private void ActualizarEscalaDesdeTextBox()
        {
            if (double.TryParse(textBox2.Text, out double factor))
            {
                canvas.ActualizarEscalado(factor);
                canvas.Render();
                line.RenderLine(g);
                PicCanva.Invalidate();
            }

        }

        private void PCT_CANVAS_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarAnguloDesdeTextBox();
            ActualizarEscalaDesdeTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int desplazamientoX = 100; 
            canvas.MoverFigura(desplazamientoX, 0);
            canvas.Render();
            line.RenderLine(g);
            PicCanva.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int desplazamientoX = -100; 
            canvas.MoverFigura(desplazamientoX, 0); 
            canvas.Render();
            line.RenderLine(g);
            PicCanva.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int desplazamientoY = 100;
            canvas.MoverFigura(0, desplazamientoY);
            canvas.Render();
            line.RenderLine(g);
            PicCanva.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int desplazamientoY = -100;
            canvas.MoverFigura(0, desplazamientoY);
            canvas.Render();
            line.RenderLine(g);
            PicCanva.Invalidate();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            canvas.CentrarFigura();
            canvas.Render();
            line.RenderLine(g);
            PicCanva.Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
