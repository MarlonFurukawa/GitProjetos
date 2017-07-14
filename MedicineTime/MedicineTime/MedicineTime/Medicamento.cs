using System;
using SQLite.Net.Attributes;


namespace MedicineTime
{
    public class Medicamentos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        public DateTime DataIncio { get; set; }
        public DateTime DataFim { get; set; }
        [MaxLength(5)]
        public string Hora { get; set; }
        [MaxLength(2)]
        public string Intervalo { get; set; }
        [MaxLength(50)]
        public string Dosagem { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", Nome, DataIncio, DataFim, Hora, Intervalo, Dosagem);
        }

    }
}
