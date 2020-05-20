using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace Appcarnett.clases
{
    public class UseManager
    {
        const String URL = "http://appnimal.atwebpages.com/";

        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "aplication/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        public async Task<IEnumerable<user>> userlogin(string correo, string password)
        {
            HttpClient client = getClient();

            var result = await client.GetAsync(URL + "login.php?Correo=" + correo + "&Contrasena=" + password);

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<user>>(content);
            }
            else
            {
                return Enumerable.Empty<user>();
            }
        }

        //Metodo de registrar
        public async void registrarusuario(string nombre, string apellido, string correo, string contraseña)
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "registrar.php?Nombre=" + nombre + "&Apellido=" + apellido + "&Correo=" + correo + "&Contrasena=" + contraseña);

        }

        public async Task<IEnumerable<visita>> visitas()
        {
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "visitasm.php");

            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<visita>>(content);
            }
            else
            {
                return Enumerable.Empty<visita>();
            }
        }

        public async void puntos(string iduser)
        {
            
            HttpClient client = getClient();
            var result = await client.GetAsync(URL + "puntos.php?puntos=" + 5 + "&iduser=" + iduser);
        }
    }
}
