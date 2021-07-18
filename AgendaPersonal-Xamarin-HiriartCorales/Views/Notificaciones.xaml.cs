using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AgendaPersonal_Xamarin_HiriartCorales.ViewModels.NotificacionViewModel;

namespace AgendaPersonal_Xamarin_HiriartCorales.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesPage : ContentPage
    {
        public NotificacionesPage()
        {
            InitializeComponent();
            GetNotificaciones();
        }
        public async void GetNotificaciones()
        {
            var notifs = await ReadNotificaciones();
            foreach (var notificacion in notifs)//Para poner el string de descripcion a cada evento
            {
                notificacion.AString();
            }
            this.NotificacionesList.ItemsSource = notifs;
        }
    }   
}