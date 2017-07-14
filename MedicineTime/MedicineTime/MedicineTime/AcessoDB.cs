using System;
using SQLite.Net;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedicineTime
{
    public class AcessoDB : IDisposable
    {
        private SQLiteConnection conexaoSQLite;

        public AcessoDB()
        {
            var config = DependencyService.Get<IConfig>();
            conexaoSQLite = new SQLiteConnection(config.Plataforma, Path.Combine(config.DiretorioSQLite, "MedicineTime.db3"));
            conexaoSQLite.CreateTable<Medicamento>();
        }

        public void InserirMedicamento(Medicamentos medicamento)
        {
            conexaoSQLite.Insert(medicamento);
        }

        public void AtualizarMedicamento(Medicamentos medicamento)
        {
            conexaoSQLite.Update(medicamento);
        }

        public void DeletarMedicamento(Medicamentos medicamento)
        {
            conexaoSQLite.Delete(medicamento);
        }

        public Medicamentos GetMedicamento(int codigo)
        {
            return conexaoSQLite.Table<Medicamentos>().FirstOrDefault(c => c.ID == codigo);
        }

        public List<Medicamentos> GetMedicamentos()
        {
            return conexaoSQLite.Table<Medicamentos>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()
        {
            conexaoSQLite.Dispose();
        }
    }
}