using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centroid
{
    internal class Canvas
    {
        Bitmap bitmap;
        Graphics g;
        PictureBox picCanva;

        private double anguloRotacion = 0;
        double factorDeEscala = 1;
        int tranX = 0, tranY = 0;

        public void ActualizarAnguloRotacion(double nuevoAngulo)
        {
            anguloRotacion = nuevoAngulo;
        }

        public void ActualizarEscalado(double nuevoFactor)
        {
            factorDeEscala = nuevoFactor;
        }

        public void MoverFigura(int transX, int transY)
        {
            tranX += transX;
            tranY += transY;
            Render();
        }
        public Canvas(Bitmap bmp, PictureBox pctCanvas) // Modifica el constructor
        {
            bitmap = bmp;
            g = Graphics.FromImage(bitmap);
            picCanva = pctCanvas;
        }

        public void CentrarFigura()
        {
            int nuevoCentroX = bitmap.Width / 2;
            int nuevoCentroY = bitmap.Height / 2;
            int transX = nuevoCentroX - tranX;
            int transY = nuevoCentroY - tranY;

            MoverFigura(transX, transY);
        }


        public void Render()
        {


            g.Clear(Color.Transparent); 
            List<Point> puntosCuadrado = Figure.CrearCuadrado(1);

            Figure.EscalarFigura(puntosCuadrado, factorDeEscala);

            Point pivoteRotacion = puntosCuadrado [0]; 

            Figure.RotarFigura(puntosCuadrado, anguloRotacion, pivoteRotacion);
            Figure.TransladarFigura(puntosCuadrado, tranX - pivoteRotacion.X, tranY - pivoteRotacion.Y);

            using (Pen purple = new Pen(Color.MediumPurple))
            {
                g.DrawLine(purple, puntosCuadrado[0], puntosCuadrado[1]);
                g.DrawLine(purple, puntosCuadrado[1], puntosCuadrado[2]);
                g.DrawLine(purple, puntosCuadrado[2], puntosCuadrado[3]);
                g.DrawLine(purple, puntosCuadrado[3], puntosCuadrado[0]);
            }


            picCanva.Invalidate();
        }
    }
}
