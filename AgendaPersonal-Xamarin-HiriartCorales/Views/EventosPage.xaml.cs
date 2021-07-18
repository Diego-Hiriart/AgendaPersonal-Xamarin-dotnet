using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AgendaPersonal_Xamarin_HiriartCorales.ViewModels.EventoViewModel;
using AgendaPersonal_Xamarin_HiriartCorales.Models;
using System.Diagnostics;

namespace AgendaPersonal_Xamarin_HiriartCorales.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventosPage : ContentPage
    {
        public EventosPage()
        {
            InitializeComponent();
            GetEventos();      
        }
        public async void GetEventos()
        {          
            var eventos = await ReadEventos();
            foreach (Evento evento in eventos)//Para poner el string de descripcion a cada evento
            {
                evento.AString();
            }
            this.EventosList.ItemsSource = eventos;
        }
    }
}