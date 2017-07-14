using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConfiguracaoXmlEtiquetas
{
    public class ConfiguracaoEtiqueta
    {
        public class ConfiguracaoEtiquetaVitrine
        {
            #region Configuração Margem
            public double Direita { get; set; }
            public double Esquerda { get; set; }
            public double Superior { get; set; }
            public double Inferior { get; set; }
            #endregion

            #region Configuração Tamanho Coluna
            public double TamanhoCol1 { get; set; }
            public double TamanhoCol2 { get; set; }
            public double TamanhoCol3 { get; set; }
            #endregion

            #region Configuração Tamanho Campos
            public double TamanhoCampo1 { get; set; }
            public double TamanhoCampo2 { get; set; }
            public double TamanhoCampo3 { get; set; }
            public double TamanhoCampo4 { get; set; }
            public double TamanhoCampo5 { get; set; }
            public double TamanhoCampo6 { get; set; }
            public double TamanhoCampo7 { get; set; }
            public double TamanhoCampo8 { get; set; }
            public double TamanhoCampo9 { get; set; }
            #endregion

            #region Configuração Tamanho Fonte
            public double TamanhoFonte1 { get; set; }
            public double TamanhoFonte2 { get; set; }
            public double TamanhoFonte3 { get; set; }
            public double TamanhoFonte4 { get; set; }
            public double TamanhoFonte5 { get; set; }
            public double TamanhoFonte6 { get; set; }
            public double TamanhoFonte7 { get; set; }
            public double TamanhoFonte8 { get; set; }
            public double TamanhoFonte9 { get; set; }
            #endregion

            public void ConfigurarEtiqueta()
            {
                string arquivo = "C:\\Users\\marlon.furukawa\\Google Drive\\Projetos\\ConfiguracaoXmlEtiquetas\\ConfiguracaoXmlEtiquetas\\CONFIGURACAO_ETIQUETA.xml";
                string coluna = "C:\\Users\\marlon.furukawa\\Google Drive\\Projetos\\ConfiguracaoXmlEtiquetas\\ConfiguracaoXmlEtiquetas\\COLUNAS_ETIQUETA.xml";
                string campo = "C:\\Users\\marlon.furukawa\\Google Drive\\Projetos\\ConfiguracaoXmlEtiquetas\\ConfiguracaoXmlEtiquetas\\CAMPOS_ETIQUETA.xml";
                string fonte = "C:\\Users\\marlon.furukawa\\Google Drive\\Projetos\\ConfiguracaoXmlEtiquetas\\ConfiguracaoXmlEtiquetas\\FONTE_ETIQUETA.xml";

                XmlTextReader x = new XmlTextReader(arquivo);
                XmlTextReader y = new XmlTextReader(coluna);
                XmlTextReader z = new XmlTextReader(campo);
                XmlTextReader w = new XmlTextReader(fonte);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_ESQUERDA")
                        Esquerda = Convert.ToDouble((x.ReadString()));
                    if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_DIREITA")
                        Direita = Convert.ToDouble((x.ReadString()));
                    if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_SUPERIOR")
                        Superior = Convert.ToDouble((x.ReadString()));
                    if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_INFERIOR")
                        Inferior = Convert.ToDouble((x.ReadString()));
                }
                while (y.Read())
                {
                    if (y.NodeType == XmlNodeType.Element && y.Name == "TAMANHO_COLUNA")
                        TamanhoCol1 = Convert.ToDouble((y.ReadString()));
                    if (y.NodeType == XmlNodeType.Element && y.Name == "TAMANHO_COLUNA1")
                        TamanhoCol2 = Convert.ToDouble((y.ReadString()));
                    if (y.NodeType == XmlNodeType.Element && y.Name == "TAMANHO_COLUNA2")
                        TamanhoCol3 = Convert.ToDouble((y.ReadString()));
                }
                while (z.Read())
                {
                    if (z.NodeType == XmlNodeType.Element && z.Name == "TAMANHO_CAMPO")
                        TamanhoCampo1 = Convert.ToDouble((z.ReadString()));
                    if (z.NodeType == XmlNodeType.Element && z.Name == "TAMANHO_CAMPO1")
                        TamanhoCampo2 = Convert.ToDouble((z.ReadString()));
                    if (z.NodeType == XmlNodeType.Element && z.Name == "TAMANHO_CAMPO2")
                        TamanhoCampo3 = Convert.ToDouble((z.ReadString()));
                }
                while (w.Read())
                {
                    if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE")
                        TamanhoFonte1 = Convert.ToDouble((w.ReadString()));
                    if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE1")
                        TamanhoFonte2 = Convert.ToDouble((w.ReadString()));
                    if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE2")
                        TamanhoFonte3 = Convert.ToDouble((w.ReadString()));
                    if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE3")
                        TamanhoFonte4 = Convert.ToDouble((w.ReadString()));
                }
            }

            public static List<ConfiguracaoEtiquetaVitrine> ListarConfiguracao()
            {
                List<ConfiguracaoEtiquetaVitrine> conf = new List<ConfiguracaoEtiquetaVitrine>();
                XElement xml = XElement.Load("CONFIGURACAO_ETIQUETA.xml");
                XElement xml1 = XElement.Load("COLUNAS_ETIQUETA.xml");
                XElement xml2 = XElement.Load("CAMPOS_ETIQUETA.xml");
                XElement xml3 = XElement.Load("FONTE_ETIQUETA.xml");
                foreach (XElement x in xml.Elements())
                {
                    ConfiguracaoEtiquetaVitrine p = new ConfiguracaoEtiquetaVitrine()
                    {
                        Esquerda = Convert.ToDouble(x.Attribute("MARGEM_ESQUERDA").Value),
                        Direita = Convert.ToDouble(x.Attribute("MARGEM_DIREITA").Value),
                        Superior = Convert.ToDouble(x.Attribute("MARGEM_SUPERIOR").Value),
                        Inferior = Convert.ToDouble(x.Attribute("MARGEM_INFERIOR").Value)
                    };
                    conf.Add(p);
                }
                //foreach (XElement x in xml1.Elements())
                //{
                //    ConfiguracaoEtiquetaVitrine p = new ConfiguracaoEtiquetaVitrine()
                //    {
                //        TamanhoCol1 = Convert.ToDouble(x.Attribute("TAMANHO_COLUNA").Value),
                //        TamanhoCol2 = Convert.ToDouble(x.Attribute("TAMANHO_COLUNA1").Value),
                //        TamanhoCol3 = Convert.ToDouble(x.Attribute("TAMANHO_COLUNA2").Value),
                //    };
                //    conf.Add(p);
                //}
                //foreach (XElement x in xml2.Elements())
                //{
                //    ConfiguracaoEtiquetaVitrine p = new ConfiguracaoEtiquetaVitrine()
                //    {
                //        TamanhoCampo1 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO").Value),
                //        TamanhoCampo2 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO1").Value),
                //        TamanhoCampo3 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO2").Value),
                //        //TamanhoCampo4 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO3").Value),
                //        //TamanhoCampo5 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO4").Value),
                //        //TamanhoCampo6 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO5").Value),
                //        //TamanhoCampo7 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO6").Value),
                //        //TamanhoCampo8 = Convert.ToDouble(x.Attribute("TAMANHO_CAMPO7").Value),
                //    };
                //    conf.Add(p);
                //}
                //foreach (XElement x in xml3.Elements())
                //{
                //    ConfiguracaoEtiquetaVitrine p = new ConfiguracaoEtiquetaVitrine()
                //    {
                //        TamanhoFonte1 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE").Value),
                //        TamanhoFonte2 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE1").Value),
                //        TamanhoFonte3 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE2").Value),
                //        //TamanhoFonte4 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE").Value),
                //        //TamanhoFonte5 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE").Value),
                //        //TamanhoFonte6 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE").Value),
                //        //TamanhoFonte7 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE").Value),
                //        //TamanhoFonte8 = Convert.ToDouble(x.Attribute("TAMANHO_FONTE").Value),
                //    };
                //    conf.Add(p);
                //}
                return conf;
            }
            public static void AdicionarConfiguracao(ConfiguracaoEtiquetaVitrine p)
            {
                XElement x = new XElement("CONFIGURACAO_ETIQUETA");

                x.Add(new XAttribute("MARGEM_ESQUERDA", p.Esquerda));
                x.Add(new XAttribute("MARGEM_DIREITA", p.Direita));
                x.Add(new XAttribute("MARGEM_SUPERIOR", p.Superior));
                x.Add(new XAttribute("MARGEM_INFERIOR", p.Inferior));
                XElement xml = XElement.Load("CONFIGURACAO_ETIQUETA.xml");
                xml.Add(x);
                xml.Save("CONFIGURACAO_ETIQUETA.xml");

                XElement x1 = new XElement("COLUNAS_ETIQUETA");
                x1.Add(new XAttribute("TAMANHO_COLUNA", p.TamanhoCol1));
                x1.Add(new XAttribute("TAMANHO_COLUNA1", p.TamanhoCol2));
                x1.Add(new XAttribute("TAMANHO_COLUNA2", p.TamanhoCol3));
                XElement xml1 = XElement.Load("COLUNAS_ETIQUETA.xml");
                xml1.Add(x);
                xml1.Save("COLUNAS_ETIQUETA.xml");

                XElement x2 = new XElement("CAMPOS_ETIQUETA");
                x2.Add(new XAttribute("TAMANHO_CAMPO", p.TamanhoCampo1));
                x2.Add(new XAttribute("TAMANHO_CAMPO1", p.TamanhoCampo2));
                x2.Add(new XAttribute("TAMANHO_CAMPO2", p.TamanhoCampo3));
                XElement xml2 = XElement.Load("CAMPOS_ETIQUETA.xml");
                xml2.Add(x);
                xml2.Save("CAMPOS_ETIQUETA.xml");

                XElement x3 = new XElement("FONTE_ETIQUETA");
                x3.Add(new XAttribute("TAMANHO_FONTE", p.TamanhoCampo1));
                x3.Add(new XAttribute("TAMANHO_FONTE1", p.TamanhoCampo2));
                x3.Add(new XAttribute("TAMANHO_FONTE2", p.TamanhoCampo3));
                XElement xml3 = XElement.Load("FONTE_ETIQUETA.xml");
                xml3.Add(x);
                xml3.Save("FONTE_ETIQUETA.xml");
            }
            public static void ExcluirConfiguracao(double MARGEM_ESQUERDA, double TAMANHO_COLUNA, double TAMANHO_CAMPO, double TAMANHO_FONTE)
            {
                XElement xml = XElement.Load("CONFIGURACAO_ETIQUETA.xml");
                XElement x = xml.Elements().Where(p => p.Attribute("MARGEM_ESQUERDA").Value.Equals(MARGEM_ESQUERDA)).First();
                if (x != null)
                {
                    x.Remove();
                }
                xml.Save("CONFIGURACAO_ETIQUETA.xml");

                XElement xml1 = XElement.Load("COLUNAS_ETIQUETA.xml");
                XElement x1 = xml1.Elements().Where(p => p.Attribute("TAMANHO_COLUNA").Value.Equals(TAMANHO_COLUNA)).First();
                if (x1 != null)
                {
                    x1.Remove();
                }
                xml1.Save("COLUNAS_ETIQUETA.xml");

                XElement xml2 = XElement.Load("CAMPOS_ETIQUETA.xml");
                XElement x2 = xml2.Elements().Where(p => p.Attribute("TAMANHO_CAMPO").Value.Equals(TAMANHO_CAMPO)).First();
                if (x2 != null)
                {
                    x2.Remove();
                }
                xml2.Save("CAMPOS_ETIQUETA.xml");

                XElement xml3 = XElement.Load("FONTE_ETIQUETA.xml");
                XElement x3 = xml3.Elements().Where(p => p.Attribute("TAMANHO_FONTE").Value.Equals(TAMANHO_FONTE)).First();
                if (x3 != null)
                {
                    x3.Remove();
                }
                xml3.Save("FONTE_ETIQUETA.xml");
            }
            public static void EditarConfiguracao(ConfiguracaoEtiquetaVitrine conf)
            {
                XElement xml = XElement.Load("CONFIGURACAO_ETIQUETA.xml");
                XElement x = xml.Elements().Where(p => p.Attribute("MARGEM_ESQUERDA").Value.Equals(conf.Esquerda)).First();
                if (x != null)
                {
                    x.Attribute("MARGEM_ESQUERDA").SetValue(conf.Esquerda);
                    x.Attribute("MARGEM_DIREITA").SetValue(conf.Direita);
                    x.Attribute("MARGEM_SUPERIOR").SetValue(conf.Superior);
                    x.Attribute("MARGEM_INFERIOR").SetValue(conf.Inferior);
                }
                xml.Save("CONFIGURACAO_ETIQUETA.xml");
            }
        }
        //public class ConfiguracaoEtiquetaKit
        //{
        //    #region Configuração Margem
        //    public double Direita { get; set; }
        //    public double Esquerda { get; set; }
        //    public double Superior { get; set; }
        //    public double Inferior { get; set; }
        //    #endregion

        //    #region Configuração Tamanho Coluna
        //    public double TamanhoCol1 { get; set; }
        //    public double TamanhoCol2 { get; set; }
        //    public double TamanhoCol3 { get; set; }
        //    #endregion

        //    #region Configuração Tamanho Campos
        //    public double TamanhoCampo1 { get; set; }
        //    public double TamanhoCampo2 { get; set; }
        //    public double TamanhoCampo3 { get; set; }
        //    public double TamanhoCampo4 { get; set; }
        //    public double TamanhoCampo5 { get; set; }
        //    public double TamanhoCampo6 { get; set; }
        //    public double TamanhoCampo7 { get; set; }
        //    public double TamanhoCampo8 { get; set; }
        //    public double TamanhoCampo9 { get; set; }
        //    #endregion

        //    #region Configuração Tamanho Fonte
        //    public double TamanhoFonte1 { get; set; }
        //    public double TamanhoFonte2 { get; set; }
        //    public double TamanhoFonte3 { get; set; }
        //    public double TamanhoFonte4 { get; set; }
        //    public double TamanhoFonte5 { get; set; }
        //    public double TamanhoFonte6 { get; set; }
        //    public double TamanhoFonte7 { get; set; }
        //    public double TamanhoFonte8 { get; set; }
        //    public double TamanhoFonte9 { get; set; }
        //    #endregion

        //    public void ConfigurarEtiqueta()
        //    {
        //        string arquivo = "C:\\Users\\marlon.furukawa\\Desktop\\CONFIGURACAO_ETIQUETA.xml";
        //        string coluna = "C:\\Users\\marlon.furukawa\\Desktop\\COLUNAS_ETIQUETA.xml";
        //        string campo = "C:\\Users\\marlon.furukawa\\Desktop\\CAMPOS_ETIQUETA.xml";
        //        string fonte = "C:\\Users\\marlon.furukawa\\Desktop\\FONTE_ETIQUETA.xml";

        //        XmlTextReader x = new XmlTextReader(arquivo);
        //        XmlTextReader y = new XmlTextReader(coluna);
        //        XmlTextReader z = new XmlTextReader(campo);
        //        XmlTextReader w = new XmlTextReader(fonte);

        //        while (x.Read())
        //        {
        //            if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_ESQUERDA")
        //                Esquerda = Convert.ToDouble((x.ReadString()));
        //            if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_DIREITA")
        //                Direita = Convert.ToDouble((x.ReadString()));
        //            if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_SUPERIOR")
        //                Superior = Convert.ToDouble((x.ReadString()));
        //            if (x.NodeType == XmlNodeType.Element && x.Name == "MARGEM_INFERIOR")
        //                Inferior = Convert.ToDouble((x.ReadString()));
        //        }
        //        while (y.Read())
        //        {
        //            if (y.NodeType == XmlNodeType.Element && y.Name == "TAMANHO_COLUNA")
        //                TamanhoCol1 = Convert.ToDouble((y.ReadString()));
        //            if (y.NodeType == XmlNodeType.Element && y.Name == "TAMANHO_COLUNA1")
        //                TamanhoCol2 = Convert.ToDouble((y.ReadString()));
        //            if (y.NodeType == XmlNodeType.Element && y.Name == "TAMANHO_COLUNA2")
        //                TamanhoCol3 = Convert.ToDouble((y.ReadString()));
        //        }
        //        while (z.Read())
        //        {
        //            if (z.NodeType == XmlNodeType.Element && z.Name == "TAMANHO_CAMPO")
        //                TamanhoCampo1 = Convert.ToDouble((z.ReadString()));
        //            if (z.NodeType == XmlNodeType.Element && z.Name == "TAMANHO_CAMPO1")
        //                TamanhoCampo2 = Convert.ToDouble((z.ReadString()));
        //            if (z.NodeType == XmlNodeType.Element && z.Name == "TAMANHO_CAMPO2")
        //                TamanhoCampo3 = Convert.ToDouble((z.ReadString()));
        //        }
        //        while (w.Read())
        //        {
        //            if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE")
        //                TamanhoFonte1 = Convert.ToDouble((w.ReadString()));
        //            if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE1")
        //                TamanhoFonte2 = Convert.ToDouble((w.ReadString()));
        //            if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE2")
        //                TamanhoFonte3 = Convert.ToDouble((w.ReadString()));
        //            if (w.NodeType == XmlNodeType.Element && w.Name == "TAMANHO_FONTE3")
        //                TamanhoFonte4 = Convert.ToDouble((w.ReadString()));
        //        }
        //    }
        //}
    }
}
