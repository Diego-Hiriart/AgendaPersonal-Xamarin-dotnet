using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendaPersonal_Xamarin_HiriartCorales.Views;

namespace AgendaPersonal_Xamarin_HiriartCorales
{
    public partial class App : Application
    {
        public static string ConnectionString = "https://275a3114be06.ngrok.io/";//ngrok http https://localhost:44366/ -host-header="localhost:44366"

        public App()
        {
            InitializeComponent();

            MainPage = new AppShellHC();//Hace que aparezca el menu de flyout
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
