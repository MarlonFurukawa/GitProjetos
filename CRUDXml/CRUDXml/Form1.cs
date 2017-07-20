using CRUDXml.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDXml
{
    public partial class Form1 : Form
    {
        private Clientes clientes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clientes = new Clientes();
            clientes.Carregar();
            dataGridView1.DataSource = clientes.ListarTodos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text
            };

            clientes.Adicionar(cli);
            clientes.Salvar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes.ListarTodos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //clientes.Remover();
            clientes.Salvar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes.ListarTodos();
        }
    }
}
