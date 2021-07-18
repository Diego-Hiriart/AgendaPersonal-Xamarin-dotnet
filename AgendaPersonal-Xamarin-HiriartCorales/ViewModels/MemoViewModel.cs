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
    class MemoViewModel
    {
        public static async Task<List<Memo>> ReadMemos()
        {
            var req = new HttpRequestMessage();
            req.RequestUri = new Uri(App.ConnectionString + "api/memos");
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "applications/json");
            List<Memo> memos = new List<Memo>();
            try
            {
                var client = new HttpClient();
                HttpResponseMessage res = await client.SendAsync(req);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Memo>>(content);
                    memos = result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            var eventos = await EventoViewModel.ReadEventos();
            foreach(var memo in memos)
            {
                foreach (var evento in eventos)
                {
                    if (memo.MemoID==evento.MemoID)
                    {
                        memo.Evento = evento.Titulo;
                    }
                }
            }
            return memos;
        }
    }
}
