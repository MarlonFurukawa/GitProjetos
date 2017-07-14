using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace TesteiTextSharp
{
    public class InformacoesEtiqueta
    {
        public static int dpi = 72;

        public int LinhaAtual { get; set; }
        public int ColunaAtual { get; set; }
        public Rect AreaEtiqueta { get; set; }
        public int NumeroEtiqueta { get; set; }
        public Rect AreaRealEtiqueta
        {
            get
            {
                return new Rect(
                    PixelsToPoints(AreaEtiqueta.Left, dpi),
                    PixelsToPoints(AreaEtiqueta.Top, dpi),
                    PixelsToPoints(AreaEtiqueta.Width, dpi),
                    PixelsToPoints(AreaEtiqueta.Height, dpi));
            }
        }


        public static double PixelsToPoints(double value, int dpi)
        {
            return value / dpi * 72;
        }
    }
}
