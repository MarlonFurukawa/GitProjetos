using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;// A BIBLIOTECA DE ENTRADA E SAIDA DE ARQUIVOS 
using iTextSharp;//E A BIBLIOTECA ITEXTSHARP E SUAS EXTENÇÕES 
using iTextSharp.text;//ESTENSAO 1 (TEXT) 
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF)

namespace TesteiTextSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region Configuração Font
            float titulo = txtFontTitulo.Text != string.Empty ? Convert.ToInt32(txtFontTitulo.Text) : 0;
            float observacao = txtFontObservacao.Text != string.Empty ? Convert.ToInt32(txtFontObservacao.Text) : 0;
            float valor = txtFontValor.Text != string.Empty ? Convert.ToInt32(txtFontValor.Text) : 0;
            float gramas = txtFontGramas.Text != string.Empty ? Convert.ToInt32(txtFontGramas.Text) : 0;
            float lote = txtFontLote.Text != string.Empty ? Convert.ToInt32(txtFontLote.Text) : 0;
            float validade = txtFontValidade.Text != string.Empty ? Convert.ToInt32(txtFontValidade.Text) : 0;

            iTextSharp.text.Font fntTableFontHdr = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font fntTableFontTitulo = FontFactory.GetFont("Arial", titulo, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fntTableFontObservacao = FontFactory.GetFont("Arial", observacao, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fntTableFontValor = FontFactory.GetFont("Arial", valor, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fntTableFontGramas = FontFactory.GetFont("Arial", gramas, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fntTableFontLote = FontFactory.GetFont("Arial", lote, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font fntTableFontValidade = FontFactory.GetFont("Arial", validade, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            #endregion

            #region Configuração Margens
            float esquerda = txtEsquerda.Text != string.Empty ? Convert.ToInt32(txtEsquerda.Text) : 0;
            float direita = txtDireita.Text != string.Empty ? Convert.ToInt32(txtDireita.Text) : 0;
            float top = txtTop.Text != string.Empty ? Convert.ToInt32(txtTop.Text) : 0;
            float bottom = txtBottom.Text != string.Empty ? Convert.ToInt32(txtBottom.Text) : 0;
            #endregion

            #region Configuração Colunas
            float tamanhocoluna = txtLarguraColunas.Text != string.Empty ? Convert.ToInt32(txtLarguraColunas.Text) : 0;
            float espaco = txtEspacoLinhas.Text != string.Empty ? Convert.ToInt32(txtEspacoLinhas.Text) : 0;
            float espacoluna = txtEspacoColunas.Text != string.Empty ? Convert.ToInt32(txtEspacoColunas.Text) : 0;
            #endregion

            #region Alinhamento
            int aling1 = txtAlinhamentoColuna1.Text != string.Empty ? Convert.ToInt32(txtAlinhamentoColuna1.Text) : 0;
            int aling2 = txtAlinhamentoColuna2.Text != string.Empty ? Convert.ToInt32(txtAlinhamentoColuna2.Text) : 0;
            #endregion

            #region Borda
            int borda = txtBorda.Text != string.Empty ? Convert.ToInt32(txtBorda.Text) : 0;
            #endregion

            string nomerelatorio = "EtiquetasVitrine" + DateTime.Now.Ticks + ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, esquerda, direita, top, bottom);
            string caminho = @"C:\Users\marlon.furukawa\Desktop\Etiquetas\" + nomerelatorio;
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            doc.Open();

            PdfPTable Tabela = new PdfPTable(10);
            Tabela.WidthPercentage = 100;
            Tabela.HorizontalAlignment = 0;

            float[] sglTblHdWidths = new float[10];
            sglTblHdWidths[0] = espacoluna;
            sglTblHdWidths[1] = tamanhocoluna;
            sglTblHdWidths[2] = tamanhocoluna;
            sglTblHdWidths[3] = espacoluna;
            sglTblHdWidths[4] = tamanhocoluna;
            sglTblHdWidths[5] = tamanhocoluna;
            sglTblHdWidths[6] = espacoluna;
            sglTblHdWidths[7] = tamanhocoluna;
            sglTblHdWidths[8] = tamanhocoluna;
            sglTblHdWidths[9] = espacoluna;
            Tabela.SetWidths(sglTblHdWidths);
            for (int i = 0; i < 12; i++)
            {
                PdfPCell Espaco = new PdfPCell(new iTextSharp.text.Paragraph(" "));
                Espaco.FixedHeight = espaco;
                Espaco.Border = borda;
                Espaco.Colspan = 10;

                PdfPCell CellOne = new PdfPCell();
                iTextSharp.text.Paragraph CellOnep = new iTextSharp.text.Paragraph(" ");
                CellOne.Border = 0;
                CellOne.AddElement(CellOnep);

                PdfPCell CellTwo = new PdfPCell();
                iTextSharp.text.Paragraph CellTwop = new iTextSharp.text.Paragraph("1" + "\n", fntTableFontTitulo);
                Phrase CellTwoph = new Phrase("2" + "\n", fntTableFontObservacao);
                Phrase CellTwoph1 = new Phrase("3" + "\n", fntTableFontObservacao);
                Phrase CellTwoph2 = new Phrase("4" + "\n", fntTableFontObservacao);
                Phrase CellTwoph3 = new Phrase("5" + "\n", fntTableFontObservacao);
                CellTwop.Add(CellTwoph);
                CellTwop.Add(CellTwoph1);
                CellTwop.Add(CellTwoph2);
                CellTwop.Add(CellTwoph3);
                CellTwop.Alignment = aling1;
                CellTwo.Border = borda;
                CellTwo.AddElement(CellTwop);

                PdfPCell CellThree = new PdfPCell();
                iTextSharp.text.Paragraph CellThreep = new iTextSharp.text.Paragraph("3" + "\n", fntTableFontTitulo);
                Phrase CellThreeph = new Phrase("2" + "\n", fntTableFontValor);
                Phrase CellThreeph1 = new Phrase("3" + "\n", fntTableFontGramas);
                Phrase CellThreeph2 = new Phrase("4" + "\n", fntTableFontLote);
                Phrase CellThreeph3 = new Phrase("5" + "\n", fntTableFontValidade);
                CellThreep.Add(CellThreeph);
                CellThreep.Add(CellThreeph1);
                CellThreep.Add(CellThreeph2);
                CellThreep.Add(CellThreeph3);
                CellThreep.Alignment = aling2;
                CellThree.Border = borda;
                CellThree.AddElement(CellThreep);

                PdfPCell CellFor = new PdfPCell();
                iTextSharp.text.Paragraph CellForp = new iTextSharp.text.Paragraph(" ");
                CellFor.Border = borda;
                CellFor.AddElement(CellForp);

                PdfPCell CellFive = new PdfPCell();
                iTextSharp.text.Paragraph CellFivep = new iTextSharp.text.Paragraph("5" + "\n", fntTableFontTitulo);
                Phrase CellFiveph = new Phrase("2" + "\n", fntTableFontObservacao);
                Phrase CellFiveph1 = new Phrase("3" + "\n", fntTableFontObservacao);
                Phrase CellFiveph2 = new Phrase("4" + "\n", fntTableFontObservacao);
                Phrase CellFiveph3 = new Phrase("5" + "\n", fntTableFontObservacao);
                CellFivep.Add(CellTwoph);
                CellFivep.Add(CellTwoph1);
                CellFivep.Add(CellTwoph2);
                CellFivep.Add(CellTwoph3);
                CellFivep.Alignment = aling1;
                CellFive.Border = borda;
                CellFive.AddElement(CellFivep);

                PdfPCell CellSix = new PdfPCell();
                iTextSharp.text.Paragraph CellSixp = new iTextSharp.text.Paragraph("6" + "\n", fntTableFontTitulo);
                Phrase CellSixph = new Phrase("2" + "\n", fntTableFontValor);
                Phrase CellSixph1 = new Phrase("3" + "\n", fntTableFontGramas);
                Phrase CellSixph2 = new Phrase("4" + "\n", fntTableFontLote);
                Phrase CellSixph3 = new Phrase("5" + "\n", fntTableFontValidade);
                CellSixp.Add(CellSixph);
                CellSixp.Add(CellSixph1);
                CellSixp.Add(CellSixph2);
                CellSixp.Add(CellSixph3);
                CellSixp.Alignment = aling2;
                CellSix.Border = borda;
                CellSix.AddElement(CellSixp);

                PdfPCell CellSeven = new PdfPCell();
                iTextSharp.text.Paragraph CellSevenp = new iTextSharp.text.Paragraph(" ");
                CellSeven.Border = borda;
                CellSeven.AddElement(CellSevenp);

                PdfPCell CellEight = new PdfPCell();
                iTextSharp.text.Paragraph CellEightp = new iTextSharp.text.Paragraph("8" + "\n", fntTableFontTitulo);
                Phrase CellEightph = new Phrase("2" + "\n", fntTableFontObservacao);
                Phrase CellEightph1 = new Phrase("3" + "\n", fntTableFontObservacao);
                Phrase CellEightph2 = new Phrase("4" + "\n", fntTableFontObservacao);
                Phrase CellEightph3 = new Phrase("5" + "\n", fntTableFontObservacao);
                CellEightp.Add(CellEightph);
                CellEightp.Add(CellEightph1);
                CellEightp.Add(CellEightph2);
                CellEightp.Add(CellEightph3);
                CellEightp.Alignment = aling1;
                CellEight.Border = borda;
                CellEight.AddElement(CellEightp);

                PdfPCell CellNine = new PdfPCell();
                iTextSharp.text.Paragraph CellNinep = new iTextSharp.text.Paragraph("9" + "\n", fntTableFontTitulo);
                Phrase CellNineph = new Phrase("2" + "\n", fntTableFontValor);
                Phrase CellNineph1 = new Phrase("3" + "\n", fntTableFontGramas);
                Phrase CellNineph2 = new Phrase("4" + "\n", fntTableFontLote);
                Phrase CellNineph3 = new Phrase("5" + "\n", fntTableFontValidade);
                CellNinep.Add(CellNineph);
                CellNinep.Add(CellNineph1);
                CellNinep.Add(CellNineph2);
                CellNinep.Add(CellNineph3);
                CellNinep.Alignment = aling2;
                CellNine.Border = borda;
                CellNine.AddElement(CellNinep);

                PdfPCell CellTen = new PdfPCell();
                iTextSharp.text.Paragraph CellTenp = new iTextSharp.text.Paragraph(" ");
                CellTen.Border = borda;
                CellTen.AddElement(CellTenp);

                Tabela.AddCell(Espaco);
                Tabela.AddCell(CellOne);
                Tabela.AddCell(CellTwo);
                Tabela.AddCell(CellThree);
                Tabela.AddCell(CellFor);
                Tabela.AddCell(CellFive);
                Tabela.AddCell(CellSix);
                Tabela.AddCell(CellSeven);
                Tabela.AddCell(CellEight);
                Tabela.AddCell(CellNine);
                Tabela.AddCell(CellTen);
                //Tabela.AddCell(Espaco);
            }

            doc.Add(Tabela);
            doc.Close();
            System.Diagnostics.Process.Start(caminho);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //string nomerelatorio = "EtiquetasKits" + DateTime.Now.Ticks + ".pdf";
            //Document doc = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
            //string caminho = @"C:\Users\marlon.furukawa\Desktop\Etiquetas\" + nomerelatorio;
            ////PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            ////string pdfpath = Microsoft.SqlServer.Server.MapPath("PDFs");
            ////string imagepath = Server.MapPath("Images");
            //FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
            string nomerelatorio = "EtiquetasKits" + DateTime.Now.Ticks + ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
            string caminho = @"C:\Users\marlon.furukawa\Desktop\Etiquetas\" + nomerelatorio;
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            doc.Open();
            //Document doc = new Document();
            Font font1 = new Font(FontFactory.GetFont("adobe garamond pro", 36f));
            Font font2 = new Font(Font.NORMAL, 9f);
            doc.SetMargins(45f, 45f, 60f, 60f);
            try
            {
                //FileStream output = new FileStream(doc + nomerelatorio, FileMode.Create);
                //PdfWriter writer = PdfWriter.GetInstance(doc, output);
                doc.Open();
                PdfContentByte cb = wri.DirectContent;
                ColumnText ct = new ColumnText(cb);
                ct.Alignment = Element.ALIGN_JUSTIFIED;

                iTextSharp.text.Paragraph heading = new iTextSharp.text.Paragraph("Chapter 1", font1);
                heading.Leading = 40f;
                doc.Add(heading);
                //Image L = Image.GetInstance(imagepath + "/l.gif");
                //L.SetAbsolutePosition(doc.Left, doc.Top - 180);
                //doc.Add(L);

                ct.AddText(new Phrase("orem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ullamcorper vitae, placerat at, diam. Integer ac turpis vel ligula rutrum auctor! Morbi egestas erat sit amet diam. Ut ut ipsum? Aliquam non sem. Nulla risus eros, mollis quis, blandit ut; luctus eget, urna. Vestibulum vestibulum dapibus erat. Proin egestas leo a metus?\n\n", font2));
                ct.AddText(new Phrase("Vivamus enim nisi, mollis in, sodales vel, convallis a, augue? Proin non enim. Nullam elementum euismod erat. Aliquam malesuada eleifend quam! Nulla facilisi. Aenean ut turpis ac est tempor malesuada. Maecenas scelerisque orci sit amet augue laoreet tempus. Duis interdum est ut eros. Fusce dictum dignissim elit. Morbi at dolor. Fusce magna. Nulla tellus turpis, mattis ut, eleifend a, adipiscing vitae, mauris. Pellentesque mattis lobortis mi.\n\n", font2));
                ct.AddText(new Phrase("Nullam sit amet metus scelerisque diam hendrerit porttitor. Aenean pellentesque, lorem a consectetuer consectetuer, nunc metus hendrerit quam, mattis ultrices lorem tellus lacinia massa. Aliquam sit amet odio. Proin mauris. Integer dictum quam a quam accumsan lacinia. Pellentesque pulvinar feugiat eros. Suspendisse rhoncus. Sed consectetuer leo eu nisi. Suspendisse massa! Sed suscipit lacus sit amet elit! Aliquam sollicitudin condimentum turpis. Nunc ut augue! Maecenas eu eros. Morbi in urna consectetuer ipsum vehicula tristique.\n\n", font2));
                ct.AddText(new Phrase("Donec imperdiet purus vel ligula. Vestibulum tempor, odio ut scelerisque eleifend, nulla sapien laoreet dui; vel aliquam arcu libero eu ante. Curabitur rutrum tristique mi. Sed lobortis iaculis arcu. Suspendisse mauris. Aliquam metus lacus, elementum quis, mollis non, consequat nec, tortor.\n", font2));
                ct.AddText(new Phrase("Quisque id diam. Ut egestas leo a elit. Nulla in metus. Aliquam iaculis turpis non augue. Donec a nunc? Phasellus eu eros. Nam luctus. Duis eu mi. Ut mollis. Nulla facilisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean pede. Nulla facilisi. Vestibulum mattis adipiscing nulla. Praesent orci ante, mattis in, cursus eget, posuere sed, mauris.\n\n", font2));
                ct.AddText(new Phrase("Nulla facilisi. Nunc accumsan risus aliquet quam. Nam pellentesque! Aenean porttitor. Aenean congue ullamcorper velit. Phasellus suscipit placerat tellus. Vivamus diam odio, tempus quis, suscipit a, dictum eu; lectus. Sed vel nisl. Ut interdum urna eu nibh. Praesent vehicula, orci id venenatis ultrices, mauris urna mollis lacus, et blandit odio magna at enim. Pellentesque lorem felis, ultrices quis, gravida sed, pharetra vitae, quam. Mauris libero ipsum, pharetra a, faucibus aliquet, pellentesque in, mauris. Cras magna neque, interdum vel, varius nec; vulputate at, erat. Quisque vitae urna. Suspendisse potenti. Nulla luctus purus at turpis! Vestibulum vitae dui. Nullam odio.\n\n", font2));
                ct.AddText(new Phrase("Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed eget mi at sem iaculis hendrerit. Nulla facilisi. Etiam sed elit. In viverra dapibus sapien. Aliquam nisi justo, ornare non, ultricies vitae, aliquam sit amet, risus! Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus risus. Vestibulum pretium augue non mi. Sed magna. In hac habitasse platea dictumst. Quisque massa. Etiam viverra diam pharetra ante. Phasellus fringilla velit ut odio! Nam nec nulla.\n\n", font2));
                ct.AddText(new Phrase("Integer augue. Morbi orci. Sed quis nibh. Nullam ac magna id leo faucibus ornare. Vestibulum eget lectus sit amet nunc facilisis bibendum. Donec adipiscing convallis mi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus enim. Mauris ligula lorem, pellentesque quis, semper sed, tristique sit amet, justo. Suspendisse potenti. Proin vitae enim. Morbi et nisi sit amet sapien ve.\n\n", font2));

                float gutter = 15f;
                float colwidth = (doc.Right - doc.Left - gutter) / 2;
                float[] left = { doc.Left + 90f , doc.Top - 80f,
                  doc.Left + 90f, doc.Top - 170f,
                  doc.Left, doc.Top - 170f,
                  doc.Left , doc.Bottom };

                float[] right = { doc.Left + colwidth, doc.Top - 80f,
                    doc.Left + colwidth, doc.Bottom };

                float[] left2 = { doc.Right - colwidth, doc.Top - 80f,
                    doc.Right - colwidth, doc.Bottom };

                float[] right2 = {doc.Right, doc.Top - 80f,
                    doc.Right, doc.Bottom };

                int status = 0;
                int i = 0;
                //Checks the value of status to determine if there is more text
                //If there is, status is 2, which is the value of NO_MORE_COLUMN
                while (ColumnText.HasMoreText(status))
                {
                    if (i == 0)
                    {
                        //Writing the first column
                        ct.SetColumns(left, right);
                        i++;
                    }
                    else
                    {
                        //write the second column
                        ct.SetColumns(left2, right2);
                    }
                    //Needs to be here to prevent app from hanging
                    ct.YLine = doc.Top - 80f;
                    //Commit the content of the ColumnText to the document
                    //ColumnText.Go() returns NO_MORE_TEXT (1) and/or NO_MORE_COLUMN (2)
                    //In other words, it fills the column until it has either run out of column, or text, or both
                    status = ct.Go();
                }
            }
            catch (Exception ex)
            {
                //Log(ex.Message);
            }
            finally
            {
                doc.Close();
            }
            System.Diagnostics.Process.Start(caminho);
            //#region Configuração Font
            //float titulo = txtFontTitulo.Text != string.Empty ? Convert.ToInt32(txtFontTitulo.Text) : 0;
            //float observacao = txtFontObservacao.Text != string.Empty ? Convert.ToInt32(txtFontObservacao.Text) : 0;
            //float valor = txtFontValor.Text != string.Empty ? Convert.ToInt32(txtFontValor.Text) : 0;
            //float produtos = txtFontProdutos.Text != string.Empty ? Convert.ToInt32(txtFontProdutos.Text) : 0;
            //float contagem = txtFontContagemProdutos.Text != string.Empty ? Convert.ToInt32(txtFontContagemProdutos.Text) : 0;

            //iTextSharp.text.Font fntTableFontHdr = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            //iTextSharp.text.Font fntTableFontTitulo = FontFactory.GetFont("Arial", titulo, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //iTextSharp.text.Font fntTableFontObservacao = FontFactory.GetFont("Arial", observacao, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //iTextSharp.text.Font fntTableFontValor = FontFactory.GetFont("Arial", valor, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //iTextSharp.text.Font fntTableFontProdutos = FontFactory.GetFont("Arial", produtos, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //iTextSharp.text.Font fntTableFontContProdutos = FontFactory.GetFont("Arial", contagem, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            ////iTextSharp.text.Font fntTableFontValidade = FontFactory.GetFont("Arial", validade, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //#endregion

            //#region Configuração Margens
            //float esquerda = txtEsquerda.Text != string.Empty ? Convert.ToInt32(txtEsquerda.Text) : 0;
            //float direita = txtDireita.Text != string.Empty ? Convert.ToInt32(txtDireita.Text) : 0;
            //float top = txtTop.Text != string.Empty ? Convert.ToInt32(txtTop.Text) : 0;
            //float bottom = txtBottom.Text != string.Empty ? Convert.ToInt32(txtBottom.Text) : 0;
            //#endregion

            //#region Configuração Colunas
            //float tamanhocoluna = txtLarguraColunas.Text != string.Empty ? Convert.ToInt32(txtLarguraColunas.Text) : 0;
            //float espaco = txtEspacoLinhas.Text != string.Empty ? Convert.ToInt32(txtEspacoLinhas.Text) : 0;
            //float espacoluna = txtEspacoColunas.Text != string.Empty ? Convert.ToInt32(txtEspacoColunas.Text) : 0;
            //#endregion

            //#region Alinhamento
            //int aling1 = txtAlinhamentoColuna1.Text != string.Empty ? Convert.ToInt32(txtAlinhamentoColuna1.Text) : 0;
            //int aling2 = txtAlinhamentoColuna2.Text != string.Empty ? Convert.ToInt32(txtAlinhamentoColuna2.Text) : 0;
            //int aling3 = txtAlinhamentoColuna3.Text != string.Empty ? Convert.ToInt32(txtAlinhamentoColuna3.Text) : 0;
            //#endregion

            //#region Borda
            //int borda = txtBorda.Text != string.Empty ? Convert.ToInt32(txtBorda.Text) : 0;
            //#endregion

            //string nomerelatorio = "EtiquetasKits" + DateTime.Now.Ticks + ".pdf";
            //Document doc = new Document(iTextSharp.text.PageSize.A4, esquerda, direita, top, bottom);
            //string caminho = @"C:\Users\marlon.furukawa\Desktop\Etiquetas\" + nomerelatorio;
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            //doc.Open();

            //PdfPTable Tabela = new PdfPTable(13);
            //Tabela.WidthPercentage = 100;
            //Tabela.HorizontalAlignment = 0;

            //float[] sglTblHdWidths = new float[13];
            //sglTblHdWidths[0] = espacoluna;
            //sglTblHdWidths[1] = tamanhocoluna;
            //sglTblHdWidths[2] = tamanhocoluna;
            //sglTblHdWidths[3] = tamanhocoluna;
            //sglTblHdWidths[4] = espacoluna;
            //sglTblHdWidths[5] = tamanhocoluna;
            //sglTblHdWidths[6] = tamanhocoluna;
            //sglTblHdWidths[7] = tamanhocoluna;
            //sglTblHdWidths[8] = espacoluna;
            //sglTblHdWidths[9] = tamanhocoluna;
            //sglTblHdWidths[10] = tamanhocoluna;
            //sglTblHdWidths[11] = tamanhocoluna;
            //sglTblHdWidths[12] = espacoluna;
            //Tabela.SetWidths(sglTblHdWidths);
            //for (int i = 0; i < 3; i++)
            //{
            //    PdfPCell Espaco = new PdfPCell(new iTextSharp.text.Paragraph(" "));
            //    Espaco.FixedHeight = espaco;
            //    Espaco.Border = borda;
            //    Espaco.Colspan = 13;

            //    PdfPCell CellOne = new PdfPCell(new iTextSharp.text.Paragraph(" "));
            //    CellOne.Border = borda;

            //    PdfPCell CellTwo = new PdfPCell();
            //    iTextSharp.text.Paragraph CellTwop = new iTextSharp.text.Paragraph("Kit Teste", fntTableFontTitulo);
            //    //Phrase CellTwoph = new Phrase(" ", fntTableFontTitulo);
            //    //Phrase CellTwoph1 = new Phrase("R$7,99", fntTableFontValor);
            //    iTextSharp.text.Paragraph CellTwoph1 = new iTextSharp.text.Paragraph("R$7,99", fntTableFontValor);

            //    iTextSharp.text.Paragraph CellTwop1 = new iTextSharp.text.Paragraph("Contem 6 Itens", fntTableFontContProdutos);
            //    iTextSharp.text.Paragraph CellTwop2 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop3 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop4 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop5 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop6 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop7 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop8 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop9 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop10 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop11 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop12 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop13 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop14 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop15 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop16 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop17 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop18 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop19 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop20 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop21 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop22 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTwop23 = new iTextSharp.text.Paragraph("Contém Gluten", fntTableFontObservacao);

            //    CellTwop.Alignment = 0;
            //    CellTwoph1.Alignment = 2;
            //    CellTwop1.Alignment = 1;
            //    CellTwop2.Alignment = 0;
            //    CellTwop3.Alignment = 0;
            //    CellTwop4.Alignment = 0;
            //    CellTwop5.Alignment = 0;
            //    CellTwop6.Alignment = 0;
            //    CellTwop7.Alignment = 0;
            //    CellTwop8.Alignment = 0;
            //    CellTwop9.Alignment = 0;
            //    CellTwop10.Alignment = 0;
            //    CellTwop11.Alignment = 0;
            //    CellTwop12.Alignment = 0;
            //    CellTwop13.Alignment = 0;
            //    CellTwop14.Alignment = 0;
            //    CellTwop15.Alignment = 0;
            //    CellTwop16.Alignment = 0;
            //    CellTwop17.Alignment = 0;
            //    CellTwop18.Alignment = 0;
            //    CellTwop19.Alignment = 0;
            //    CellTwop20.Alignment = 0;
            //    CellTwop21.Alignment = 0;
            //    CellTwop22.Alignment = 0;
            //    CellTwop23.Alignment = 1;

            //    //CellTwop.Add(CellTwoph);
            //    CellTwop.Add(CellTwoph1);

            //    CellTwo.AddElement(CellTwop);
            //    CellTwo.AddElement(CellTwop1);
            //    CellTwo.AddElement(CellTwop2);
            //    CellTwo.AddElement(CellTwop3);
            //    CellTwo.AddElement(CellTwop4);
            //    CellTwo.AddElement(CellTwop5);
            //    CellTwo.AddElement(CellTwop6);
            //    CellTwo.AddElement(CellTwop7);
            //    CellTwo.AddElement(CellTwop8);
            //    CellTwo.AddElement(CellTwop9);
            //    CellTwo.AddElement(CellTwop10);
            //    CellTwo.AddElement(CellTwop11);
            //    CellTwo.AddElement(CellTwop12);
            //    CellTwo.AddElement(CellTwop13);
            //    CellTwo.AddElement(CellTwop14);
            //    CellTwo.AddElement(CellTwop15);
            //    CellTwo.AddElement(CellTwop16);
            //    CellTwo.AddElement(CellTwop17);
            //    CellTwo.AddElement(CellTwop18);
            //    CellTwo.AddElement(CellTwop19);
            //    CellTwo.AddElement(CellTwop20);
            //    CellTwo.AddElement(CellTwop21);
            //    CellTwo.AddElement(CellTwop22);
            //    CellTwo.AddElement(CellTwop23);
            //    CellTwo.Border = borda;
            //    CellTwo.Colspan = 3;

            //    //PdfPCell CellThree = new PdfPCell(new iTextSharp.text.Paragraph("1"));

            //    //PdfPCell CellFor = new PdfPCell(new iTextSharp.text.Paragraph("1"));

            //    PdfPCell CellFive = new PdfPCell(new iTextSharp.text.Paragraph(" "));
            //    CellFive.Border = borda;

            //    PdfPCell CellSix = new PdfPCell();
            //    iTextSharp.text.Paragraph CellSixp = new iTextSharp.text.Paragraph("Kit Teste", fntTableFontTitulo);
            //    //Phrase CellTwoph = new Phrase(" ", fntTableFontTitulo);
            //    //Phrase CellTwoph1 = new Phrase("R$7,99", fntTableFontValor);
            //    iTextSharp.text.Paragraph CellSixph1 = new iTextSharp.text.Paragraph("R$7,99", fntTableFontValor);

            //    iTextSharp.text.Paragraph CellSixp1 = new iTextSharp.text.Paragraph("Contem 6 Itens", fntTableFontContProdutos);
            //    iTextSharp.text.Paragraph CellSixp2 = new iTextSharp.text.Paragraph("Produto  Produto Produto Produto Produto Produto Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp3 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp4 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp5 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp6 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp7 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp8 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp9 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp10 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp11 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp12 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp13 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp14 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp15 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp16 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp17 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp18 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp19 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp20 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp21 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp22 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellSixp23 = new iTextSharp.text.Paragraph("Contém Gluten", fntTableFontObservacao);

            //    CellSixp.Alignment = 0;
            //    CellSixph1.Alignment = 2;
            //    CellSixp1.Alignment = 1;
            //    CellSixp2.Alignment = 0;
            //    CellSixp3.Alignment = 0;
            //    CellSixp4.Alignment = 0;
            //    CellSixp5.Alignment = 0;
            //    CellSixp6.Alignment = 0;
            //    CellSixp7.Alignment = 0;
            //    CellSixp8.Alignment = 0;
            //    CellSixp9.Alignment = 0;
            //    CellSixp10.Alignment = 0;
            //    CellSixp11.Alignment = 0;
            //    CellSixp12.Alignment = 0;
            //    CellSixp13.Alignment = 0;
            //    CellSixp14.Alignment = 0;
            //    CellSixp15.Alignment = 0;
            //    CellSixp16.Alignment = 0;
            //    CellSixp17.Alignment = 0;
            //    CellSixp18.Alignment = 0;
            //    CellSixp19.Alignment = 0;
            //    CellSixp20.Alignment = 0;
            //    CellSixp21.Alignment = 0;
            //    CellSixp22.Alignment = 0;
            //    CellSixp23.Alignment = 1;

            //    //CellTwop.Add(CellTwoph);
            //    CellSixp.Add(CellTwoph1);

            //    CellSix.AddElement(CellSixp);
            //    CellSix.AddElement(CellSixp1);
            //    CellSix.AddElement(CellSixp2);
            //    CellSix.AddElement(CellSixp3);
            //    CellSix.AddElement(CellSixp4);
            //    CellSix.AddElement(CellSixp5);
            //    CellSix.AddElement(CellSixp6);
            //    CellSix.AddElement(CellSixp7);
            //    CellSix.AddElement(CellSixp8);
            //    CellSix.AddElement(CellSixp9);
            //    CellSix.AddElement(CellSixp10);
            //    CellSix.AddElement(CellSixp11);
            //    CellSix.AddElement(CellSixp12);
            //    CellSix.AddElement(CellSixp13);
            //    CellSix.AddElement(CellSixp14);
            //    CellSix.AddElement(CellSixp15);
            //    CellSix.AddElement(CellSixp16);
            //    CellSix.AddElement(CellSixp17);
            //    CellSix.AddElement(CellSixp18);
            //    CellSix.AddElement(CellSixp19);
            //    CellSix.AddElement(CellSixp20);
            //    CellSix.AddElement(CellSixp21);
            //    CellSix.AddElement(CellSixp22);
            //    CellSix.AddElement(CellSixp23);
            //    CellSix.Border = borda;
            //    CellSix.Colspan = 3;
            //    //PdfPCell CellSeven = new PdfPCell(new iTextSharp.text.Paragraph("1"));

            //    //PdfPCell CellEight = new PdfPCell(new iTextSharp.text.Paragraph("1"));

            //    PdfPCell CellNine = new PdfPCell(new iTextSharp.text.Paragraph(" "));
            //    CellNine.Border = borda;

            //    PdfPCell CellTen = new PdfPCell();
            //    iTextSharp.text.Paragraph CellTenp = new iTextSharp.text.Paragraph("Kit Teste", fntTableFontTitulo);
            //    //Phrase CellTwoph = new Phrase(" ", fntTableFontTitulo);
            //    //Phrase CellTwoph1 = new Phrase("R$7,99", fntTableFontValor);
            //    iTextSharp.text.Paragraph CellTenph1 = new iTextSharp.text.Paragraph("R$7,99", fntTableFontValor);

            //    iTextSharp.text.Paragraph CellTenp1 = new iTextSharp.text.Paragraph("Contem 6 Itens", fntTableFontContProdutos);
            //    iTextSharp.text.Paragraph CellTenp2 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp3 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp4 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp5 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp6 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp7 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp8 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp9 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp10 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp11 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp12 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp13 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp14 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp15 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp16 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp17 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp18 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp19 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp20 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp21 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp22 = new iTextSharp.text.Paragraph("Produto", fntTableFontProdutos);
            //    iTextSharp.text.Paragraph CellTenp23 = new iTextSharp.text.Paragraph("Contém Gluten", fntTableFontObservacao);

            //    CellTenp.Alignment = 0;
            //    CellTenph1.Alignment = 2;
            //    CellTenp1.Alignment = 1;
            //    CellTenp2.Alignment = 0;
            //    CellTenp3.Alignment = 0;
            //    CellTenp4.Alignment = 0;
            //    CellTenp5.Alignment = 0;
            //    CellTenp6.Alignment = 0;
            //    CellTenp7.Alignment = 0;
            //    CellTenp8.Alignment = 0;
            //    CellTenp9.Alignment = 0;
            //    CellTenp10.Alignment = 0;
            //    CellTenp11.Alignment = 0;
            //    CellTenp12.Alignment = 0;
            //    CellTenp13.Alignment = 0;
            //    CellTenp14.Alignment = 0;
            //    CellTenp15.Alignment = 0;
            //    CellTenp16.Alignment = 0;
            //    CellTenp17.Alignment = 0;
            //    CellTenp18.Alignment = 0;
            //    CellTenp19.Alignment = 0;
            //    CellTenp20.Alignment = 0;
            //    CellTenp21.Alignment = 0;
            //    CellTenp22.Alignment = 0;
            //    CellTenp23.Alignment = 1;

            //    //CellTwop.Add(CellTwoph);
            //    CellTenp.Add(CellTenph1);

            //    CellTen.AddElement(CellTenp);
            //    CellTen.AddElement(CellTenp1);
            //    CellTen.AddElement(CellTenp2);
            //    CellTen.AddElement(CellTenp3);
            //    CellTen.AddElement(CellTenp4);
            //    CellTen.AddElement(CellTenp5);
            //    CellTen.AddElement(CellTenp6);
            //    CellTen.AddElement(CellTenp7);
            //    CellTen.AddElement(CellTenp8);
            //    CellTen.AddElement(CellTenp9);
            //    CellTen.AddElement(CellTenp10);
            //    CellTen.AddElement(CellTenp11);
            //    CellTen.AddElement(CellTenp12);
            //    CellTen.AddElement(CellTenp13);
            //    CellTen.AddElement(CellTenp14);
            //    CellTen.AddElement(CellTenp15);
            //    CellTen.AddElement(CellTenp16);
            //    CellTen.AddElement(CellTenp17);
            //    CellTen.AddElement(CellTenp18);
            //    CellTen.AddElement(CellTenp19);
            //    CellTen.AddElement(CellTenp20);
            //    CellTen.AddElement(CellTenp21);
            //    CellTen.AddElement(CellTenp22);
            //    CellTen.AddElement(CellTenp23);
            //    CellTen.Border = borda;
            //    CellTen.Colspan = 3;
            //    //PdfPCell CellEleven = new PdfPCell(new iTextSharp.text.Paragraph("1"));

            //    //PdfPCell CellTwelve = new PdfPCell(new iTextSharp.text.Paragraph("1"));

            //    PdfPCell CellThirteen = new PdfPCell(new iTextSharp.text.Paragraph(" "));
            //    CellThirteen.Border = borda;

            //    Tabela.AddCell(Espaco);
            //    Tabela.AddCell(CellOne);
            //    Tabela.AddCell(CellTwo);
            //    //Tabela.AddCell(CellThree);
            //    //Tabela.AddCell(CellFor);
            //    Tabela.AddCell(CellFive);
            //    Tabela.AddCell(CellSix);
            //    //Tabela.AddCell(CellSeven);
            //    //Tabela.AddCell(CellEight);
            //    Tabela.AddCell(CellNine);
            //    Tabela.AddCell(CellTen);
            //    //Tabela.AddCell(CellEleven);
            //    //Tabela.AddCell(CellTwelve);
            //    Tabela.AddCell(CellThirteen);
            //}

            //doc.Add(Tabela);
            //doc.Close();
            //System.Diagnostics.Process.Start(caminho);
        }
    }
}
