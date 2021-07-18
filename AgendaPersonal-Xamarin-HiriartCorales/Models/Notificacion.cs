using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AgendaPersonal_Xamarin_HiriartCorales.Models
{
    class Notificacion : INotifyPropertyChanged
    {
        public int NotificacionID { get; set; }
        public string Titulo { get; set; }
        public DateTime Hora { get; set; }

        public string Evento { get; set; }
        public string EnString { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AString()
        {
            string evento = String.IsNullOrEmpty(this.Evento) == true ? "ninguno" : this.Evento;
            this.EnString = String.Format("Fecha y hora: {0} {1}. Evento: {2}", this.Hora.ToShortDateString(), 
                this.Hora.ToShortTimeString(), evento);
        }
    }
}
