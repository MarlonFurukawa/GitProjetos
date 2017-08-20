using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoboLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool JaEntreiNoEvento = false;
        public MainWindow()
        {
            InitializeComponent();
            webBrowerNavegacao.Navigate(new Uri(" https://www.facebook.com/"));
        }
        private void webBrowerNavegacao_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (JaEntreiNoEvento == false)
            {
                mshtml.HTMLDocument htmldoc;
                htmldoc = webBrowerNavegacao.Document as mshtml.HTMLDocument;

                htmldoc.getElementById("email").innerText = Login.Text;
                htmldoc.getElementById("pass").innerText = Password.Password.ToString();

                if (Login.Text != null && Password.Password.ToString() != null)
                    htmldoc.getElementById("u_0_0").click();

                JaEntreiNoEvento = true;
                webBrowerNavegacao.LoadCompleted -= webBrowerNavegacao_LoadCompleted;
            }
        }
    }
}
