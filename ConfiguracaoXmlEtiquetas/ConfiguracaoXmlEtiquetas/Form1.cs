using System;
using System.Windows.Forms;
using static ConfiguracaoXmlEtiquetas.ConfiguracaoEtiqueta;

namespace ConfiguracaoXmlEtiquetas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public ConfiguracaoEtiquetaVitrine configuracao;
        private void gbConfiguracaoEtiqueta_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var configuracao = ConfiguracaoEtiquetaVitrine.ListarConfiguracao();
            grConfiguracao.DataSource = configuracao;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void grConfiguracao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            ConfiguracaoEtiquetaVitrine p = new ConfiguracaoEtiquetaVitrine()
            {
                Esquerda = Convert.ToDouble(txtEsquerda.Text),
                Direita = Convert.ToDouble(txtDireita.Text),
                Superior = Convert.ToDouble(txtSuperior.Text),
                Inferior = Convert.ToDouble(txtInferior.Text)
            };
            ConfiguracaoEtiquetaVitrine.AdicionarConfiguracao(p);
            ConfiguracaoEtiquetaVitrine.ListarConfiguracao();
            grConfiguracao.DataSource = configuracao;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ConfiguracaoEtiquetaVitrine p = new ConfiguracaoEtiquetaVitrine()
            {
                Esquerda = Convert.ToDouble(txtEsquerda.Text),
                Direita = Convert.ToDouble(txtDireita.Text),
                Superior = Convert.ToDouble(txtSuperior.Text),
                Inferior = Convert.ToDouble(txtInferior.Text)
            };
            ConfiguracaoEtiquetaVitrine.EditarConfiguracao(p);
            var configuracao = ConfiguracaoEtiquetaVitrine.ListarConfiguracao();
            grConfiguracao.DataSource = configuracao;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (grConfiguracao.SelectedRows.Count > 0)
            {
                int indice = grConfiguracao.SelectedRows[0].Index;
                //ConfiguracaoEtiquetaVitrine.ExcluirConfiguracao(conf[indice].Codigo);
                //configuracao = ConfiguracaoEtiquetaVitrine.ListarConfiguracao();
                grConfiguracao.DataSource = configuracao;
            }
        }
    }
}
