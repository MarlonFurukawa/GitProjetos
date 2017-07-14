using SQLite.Net.Interop;

namespace MedicineTime
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}