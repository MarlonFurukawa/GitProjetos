using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TesteiTextSharp
{
    /// <summary>
    /// Interaction logic for TesteEtiqueta.xaml
    /// </summary>
    public partial class TesteEtiqueta : Window
    {
        public TesteEtiqueta()
        {
            InitializeComponent();
        }

        private void btnTeste_Click(object sender, RoutedEventArgs e)
        {
            /* CONSTANTES DA ETIQUETA */
            int ETIQUETA_INICIAL = 1;
            int MAX_PAGINAS = 1;
            int MAX_COLUNAS = 3;
            int MAX_LINHAS = 12;
            int LARGURA_ETIQUETA = 100;
            int ALTURA_ETIQUETA = 70;
            Thickness MARGEM_PAGINA = new Thickness(10);
            Thickness MARGEM_ETIQUETA = new Thickness(5);
            string CAMINHO = @"C:\Temp\Teste.pdf";

            /* CRIAR O DATATABLE */
            DataTable dt = new DataTable();
            dt.Columns.Add("nome");
            dt.Columns.Add("endereco");
            dt.AcceptChanges();

            for (int p = 0; p < MAX_PAGINAS; p++)
            {
                for (int x = 0; x < MAX_COLUNAS; x++)
                {
                    for (int y = 0; y < MAX_LINHAS; y++)
                    {
                        string nome = string.Format("L{0}C{1}", y, x);
                        DataRow dr = dt.NewRow();
                        dr["nome"] = nome;
                        dr["endereco"] = "Endereço de " + nome;
                        dt.Rows.Add(dr);
                    }
                }
            }
            dt.AcceptChanges();
               
            /* EXEMPLO PARA CRIAÇÃO DAS ETIQUETAS */
            GeradorEtiquetas ge = new GeradorEtiquetas()
            {
                FonteDados = dt,
                MargensEtiqueta = MARGEM_ETIQUETA,
                MargensPagina = MARGEM_PAGINA,
                TamanhoPagina = new Size(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height),
                TamanhoEtiqueta = new Size(LARGURA_ETIQUETA, ALTURA_ETIQUETA),
                TemplateEtiquetaBase = new TemplateEtiquetaTeste()                
            };

            ge.ImprimirEtiquetas(ETIQUETA_INICIAL, CAMINHO);            
            System.Diagnostics.Process.Start(CAMINHO);
        }
    }

    public class TemplateEtiquetaTeste : EtiquetaBase
    {
        public override void ImprimirEtiqueta(InformacoesEtiqueta i, DataRow dr, iTextSharp.text.Document doc, PdfWriter writer)
        {
            Rect r = i.AreaEtiqueta;

            //if (i.NumeroEtiqueta == 2)
            //{
                iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(
                                                        Convert.ToSingle(r.Left),
                                                        Convert.ToSingle(r.Top),
                                                        Convert.ToSingle(r.Right),
                                                        Convert.ToSingle(r.Bottom));
                rect.BorderColor = new BaseColor(System.Drawing.Color.Black);
                rect.Border = 5;
                rect.BackgroundColor = new BaseColor(System.Drawing.Color.Blue);

                PdfContentByte cb = writer.DirectContent;                                
                ColumnText ct = new ColumnText(cb);
                ct.SetSimpleColumn(rect);
                ct.AddElement(new iTextSharp.text.Paragraph(Convert.ToString(dr["nome"])));
                ct.Go();

                doc.Add(rect);
            //}
        }
    }
}
