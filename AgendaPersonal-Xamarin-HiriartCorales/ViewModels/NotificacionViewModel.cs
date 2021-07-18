using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AgendaPersonal_Xamarin_HiriartCorales.Models;
using Newtonsoft.Json;

namespace AgendaPersonal_Xamarin_HiriartCorales.ViewModels
{
    class NotificacionViewModel
    {
        public static async Task<List<Notificacion>> ReadNotificaciones()
        {
            var req = new HttpRequestMessage();
            req.RequestUri = new Uri(App.ConnectionString + "api/notificaciones");
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "applications/json");
            List<Notificacion> notifs = new List<Notificacion>();
            try
            {
                var client = new HttpClient();
                HttpResponseMessage res = await client.SendAsync(req);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Notificacion>>(content);
                    notifs = result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            var eventos = await EventoViewModel.ReadEventos();
            foreach (var notificacion in notifs)
            {
                foreach (var evento in eventos)
                {
                    if (notificacion.NotificacionID == evento.NotificacionID)
                    {
                        notificacion.Evento = evento.Titulo;
                    }
                }
            }
            return notifs;
        }
    }
}
