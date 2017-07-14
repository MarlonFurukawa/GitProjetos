using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraBits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var Texto = txtString.Text;
            GetBits(Texto);
        }
        public string GetBits(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.Unicode.GetBytes(input))
            {
                sb.Append(Convert.ToString(b, 2));
            }

            var Tamanho = sb.Length;
            lbTamanho.Text = Tamanho.ToString();

            var result = Convert.ToString(sb.Length * 32);
            lbResultado.Text = result;
            //MessageBox.Show(result);
            return sb.ToString();
        }
    }
}
