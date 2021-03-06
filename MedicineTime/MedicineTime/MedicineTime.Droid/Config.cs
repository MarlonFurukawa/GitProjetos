using System;
using SQLite.Net.Interop;
using Xamarin.Forms;


[assembly: Dependency(typeof(MedicineTime.Droid.Config))]


namespace MedicineTime.Droid
{
    public class Config : IConfig
    {
        private string _diretorioSQLite;
        private SQLite.Net.Interop.ISQLitePlatform _plataforma;
        public string DiretorioSQLite
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioSQLite))
                {
                    _diretorioSQLite = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretorioSQLite;
            }
        }
        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _plataforma;
            }
        }
    }
}