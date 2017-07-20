using ConfiguracaoXmlEtiquetas.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ConfiguracaoXmlEtiquetas
{
    public partial class Form1 : Form
    {
        private Etiquetas etiquetas;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            etiquetas = new Etiquetas();
            etiquetas.Carregar();
            dataGridView1.DataSource = etiquetas.ListarTodos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Etiqueta etq = new Etiqueta()
            {
                Descricao = txtDescricao.Text,
                Esquerda = txtEsquerda.Text,
                Direita = txtDireita.Text,
                Superior = txtSuperior.Text,
                Inferior = txtInferior.Text,
                Coluna = txtCol1.Text,
                Coluna1 = txtCol2.Text,
                Coluna2 = txtCol3.Text,
                Campo = txtCampo1.Text,
                Campo1 = txtCampo2.Text,
                Campo2 = txtCampo3.Text,
                Campo3 = txtCampo4.Text,
                //Campo4 =.Text,
                //Campo5 =.Text,
                //Campo6 =.Text,
                //Campo7 =.Text,
                Fonte = txtFonte1.Text,
                Fonte1 = txtFonte2.Text,
                Fonte2 = txtFonte3.Text,
                Fonte3 = txtFonte4.Text
                //Fonte4 =.Text,
                //Fonte5 =.Text,
                //Fonte6 =.Text,
                //Fonte7 =.Text

            };

            etiquetas.Adicionar(etq);
            etiquetas.Salvar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = etiquetas.ListarTodos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Etiqueta>));
            FileStream fs = new FileStream("E://Etiquetas.xml", FileMode.Truncate);
            ser.Serialize(fs, etiquetas);
            fs.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Text = "";
            txtEsquerda.Text = "";
            txtDireita.Text = "";
            txtSuperior.Text = "";
            txtInferior.Text = "";
            txtCol1.Text = "";
            txtCol2.Text = "";
            txtCol3.Text = "";
            txtCampo1.Text = "";
            txtCampo2.Text = "";
            txtCampo3.Text = "";
            txtCampo4.Text = "";
            txtFonte1.Text = "";
            txtFonte2.Text = "";
            txtFonte3.Text = "";
            txtFonte4.Text = "";
            txtDescricao.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            etiquetas.Salvar();
        }
    }
}
