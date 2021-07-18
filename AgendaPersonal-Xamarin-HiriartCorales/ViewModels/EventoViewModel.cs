using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using AgendaPersonal_Xamarin_HiriartCorales.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AgendaPersonal_Xamarin_HiriartCorales.ViewModels
{
    class EventoViewModel
    {
        public static async Task<List<Evento>> ReadEventos()
        {
            var req = new HttpRequestMessage();
            req.RequestUri = new Uri(App.ConnectionString + "api/eventos");
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "applications/json");
            List<Evento> eventos = new List<Evento>();
            try
            {
                var client = new HttpClient();
                HttpResponseMessage res = await client.SendAsync(req);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Evento>>(content);
                    eventos = result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return eventos;
        }
    }
}
