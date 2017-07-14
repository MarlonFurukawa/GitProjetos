using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace TesteiTextSharp
{    
    public class GeradorEtiquetas
    {
        private int totalLinhas;
        private int totalColunas;

        public int TotalLinhas { get { return totalLinhas; } }
        public int TotalColunas { get { return totalColunas; } }

        public EtiquetaBase TemplateEtiquetaBase { get; set; }
        public DataTable FonteDados { get; set; }

        public Thickness MargensEtiqueta { get; set; }
        public Thickness MargensPagina { get; set; }
        public Size TamanhoPagina { get; set; }
        public Size TamanhoEtiqueta { get; set; }

        public void ImprimirEtiquetas(int PosicaoInicial, string Arquivo)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(new Rectangle(
                                                                           Convert.ToSingle(0),
                                                                           Convert.ToSingle(0),
                                                                           Convert.ToSingle(TamanhoPagina.Width), 
                                                                           Convert.ToSingle(TamanhoPagina.Height)),
                                                                           Convert.ToSingle(MargensPagina.Left),
                                                                           Convert.ToSingle(MargensPagina.Right),
                                                                           Convert.ToSingle(MargensPagina.Top),
                                                                           Convert.ToSingle(MargensPagina.Bottom));
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Arquivo, FileMode.Create));
            doc.Open();

            CalcularEtiquetas();
            int etiquetaAtual = PosicaoInicial;
            int posicaoPagina = PosicaoInicial;

            if (etiquetaAtual > 0)
            {
                foreach (DataRow dr in FonteDados.Rows)
                {
                    InformacoesEtiqueta i = CalcularAreaEtiqueta(posicaoPagina);

                    if (i.LinhaAtual <= totalLinhas)
                    {
                        TemplateEtiquetaBase.ImprimirEtiqueta(i, dr, doc, writer);
                        etiquetaAtual++;
                        posicaoPagina++;
                    }
                    else
                    {
                        doc.NewPage();
                        posicaoPagina = 1;
                        i = CalcularAreaEtiqueta(posicaoPagina);

                        TemplateEtiquetaBase.ImprimirEtiqueta(i, dr, doc, writer);
                        etiquetaAtual++;
                        posicaoPagina++;
                    }
                }
            }
            doc.Close();
        }

        public InformacoesEtiqueta CalcularAreaEtiqueta(int PosicaoEtiqueta)
        {
            if (PosicaoEtiqueta > 0)
            {
                double x = MargensEtiqueta.Left;
                double y = MargensEtiqueta.Top;
                double w = TamanhoEtiqueta.Width;
                double h = TamanhoEtiqueta.Height;

                double modCol = PosicaoEtiqueta % totalColunas;
                double divCol = Math.Truncate(Convert.ToDouble(PosicaoEtiqueta / totalColunas));
                double linhaAtual = (modCol > 0 ? divCol + 1 : divCol);
                double colunaAtual = (modCol > 0 ? modCol : totalColunas);

                InformacoesEtiqueta i = new InformacoesEtiqueta();
                i.LinhaAtual = Convert.ToInt32(linhaAtual);
                i.ColunaAtual = Convert.ToInt32(colunaAtual);
                i.NumeroEtiqueta = PosicaoEtiqueta;

                if (colunaAtual == 1)
                    x = MargensEtiqueta.Left + MargensPagina.Left + (MargensEtiqueta.Right);
                else
                    x = MargensPagina.Left + (colunaAtual * MargensEtiqueta.Left) + ((colunaAtual) * MargensEtiqueta.Right) + (TamanhoEtiqueta.Width * (colunaAtual-1));

                if (linhaAtual == 1)
                    y = MargensEtiqueta.Top + MargensPagina.Top;
                else
                    y = MargensPagina.Top + (linhaAtual * MargensEtiqueta.Top) + (linhaAtual * MargensEtiqueta.Bottom) + (TamanhoEtiqueta.Height * (linhaAtual-1));

                i.AreaEtiqueta = new Rect(x, TamanhoPagina.Height - (y+h), w, h);
                return i;
            }
            else
                return null;
        }        

        public void CalcularEtiquetas()
        {
            totalColunas = Convert.ToInt32(Math.Truncate((TamanhoPagina.Width - (MargensPagina.Left + MargensPagina.Right)) / (TamanhoEtiqueta.Width + MargensEtiqueta.Left + MargensEtiqueta.Right)));
            totalLinhas = Convert.ToInt32(Math.Truncate((TamanhoPagina.Height - (MargensPagina.Top + MargensPagina.Bottom)) / (TamanhoEtiqueta.Height + MargensEtiqueta.Top + MargensEtiqueta.Bottom)));
        }

        public double CmToPx(double cm)
        {
            return cm * PixelUnitFactor.Cm;
        }

        public double PxToCm(double px)
        {
            return px / PixelUnitFactor.Cm;
        }

        public GeradorEtiquetas()
        {
            totalLinhas = 0;
            totalColunas = 0;
            TemplateEtiquetaBase = null;
            FonteDados = null;
            MargensEtiqueta  = new Thickness(0);
            MargensPagina = new Thickness(0);

            // A4 = 210mm × 297mm
            TamanhoPagina = new Size(CmToPx(Convert.ToDouble(21)), CmToPx(Convert.ToDouble(29.7)));
            TamanhoEtiqueta = new Size(100, 100);
            CalcularEtiquetas();
        }
    }    
}
