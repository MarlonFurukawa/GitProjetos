using System;
using Xamarin.Forms;

namespace MedicineTime
{
    public partial class Medicamento : ContentPage
    {
        public Medicamento()
        {
            InitializeComponent();
            using (var dados = new AcessoDB())
            {
                this.ListaMedicamento.ItemsSource = dados.GetMedicamentos();
            }
        }
        protected void SalvarClicked(object sender, EventArgs e)
        {

            var medicamento = new Medicamentos
            {
                Nome = this.NomeMedicamento.Text,

                DataIncio = Convert.ToDateTime(this.DataIni.ToString()),
                DataFim = Convert.ToDateTime(this.DataF.ToString()),
                Hora = this.Hor.Text,
                Intervalo = this.Interval.Text,
                Dosagem = this.Dosa.Text,

            };


            using (var dados = new AcessoDB())

            {

                dados.InserirMedicamento(medicamento);

                this.ListaMedicamento.ItemsSource = dados.GetMedicamentos();

            }

        }
    }
}
