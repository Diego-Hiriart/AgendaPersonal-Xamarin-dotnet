using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AgendaPersonal_Xamarin_HiriartCorales.Models
{
    class Memo : INotifyPropertyChanged
    {
        public int MemoID { get; set; }
        public string Contenido { get; set; }

        public string Evento { get; set; }

        public DateTime? Fecha { get; set; }
        public string EnString { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AString()
        {
            string evento = String.IsNullOrEmpty(this.Evento)==true ? "ninguno" : this.Evento;
            this.EnString = String.Format("Evento: {0}", evento);
        }
    }
}
