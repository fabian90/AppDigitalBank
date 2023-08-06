using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WcfServiceUsuario.Data.Interface;
using WcfServiceUsuario.Dtos;

namespace WcfServiceUsuario.Data.Implementation
{
    public class MonitoreoServiceApI : IMonitoreoServiceApI
    {
        public async Task AgregarErrorLog(ErrorLogDto errorLog)
        {
            AutenticacionDto autenticacion= new AutenticacionDto();
            autenticacion.username = "usuarioPrueba";
            autenticacion.password = "123";
            string token= GeneraToke(autenticacion);
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseMonitoreoUrl"];
            using (var httpClient = new HttpClient())
            {
                var jsonContent = JsonSerializer.Serialize(errorLog);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                apiBaseUrl = $"{apiBaseUrl}/api/ErrorLog/"; // Combina la URL base con la ruta de la API
                //HttpResponseMessage response = await httpClient.PostAsync("api/data");
               var response = await httpClient.PostAsync(apiBaseUrl, httpContent);
               
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody =  response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta de la API: " + responseBody);
                    }
                    else
                    {
                        Console.WriteLine("Error en la llamada a la API: " + response.StatusCode);
                    }
                
            }
        }
        private string GeneraToke(AutenticacionDto autenticacion)
        {
            string toke = "";
           var apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseMonitoreoUrl"]; // Obtiene la URL de la API desde la configuración
            var apiUrl = $"{apiBaseUrl}/api/Authenticate/GenerarToke?username={autenticacion.username}&password={autenticacion.password}"; // Combina la URL base con la ruta de la API
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    ApiResponse content = JsonSerializer.Deserialize < ApiResponse > (response.Content.ReadAsStringAsync().Result);                   
                    Console.WriteLine("Respuesta de la API: " + content);
                    toke=content.Data.Token;
                    return toke;
                }
                else
                {
                    Console.WriteLine("Error en la llamada a la API: " + response.StatusCode);
                }

            }
            
            return toke;
        }
    }
}
