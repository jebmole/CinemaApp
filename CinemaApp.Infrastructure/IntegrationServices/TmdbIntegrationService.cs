using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CinemaApp.Infrastructure.IntegrationServices
{
    public class TmdbIntegrationService : IPeliculaIntegracion
    {
        public PeliculaTmbdResponse GetMovies()
        {
            string urlBase = "https://api.themoviedb.org/3/";
            string endpoint = "movie/now_playing";
            string queryString = "?api_key=a6db559033af943be136a2110dbd4b5f&language=es-ES";

            //Se define la url completa a invocar
            var url = urlBase + endpoint + queryString;
            HttpClient cliente = new HttpClient();
            var request = cliente.GetAsync(url).Result;
            
            //Se valida si el API respondio un codigo 200 - OK
            if (request.IsSuccessStatusCode)
            {
                //Obtenemos la respuesta en una cadena de texto con formato JSON
                var responseJson = request.Content.ReadAsStringAsync().Result;

                //Se convierte la variable de texto JSON en un objeto
                var response = JsonConvert.DeserializeObject<PeliculaTmbdResponse>(responseJson);
                return response;
            }

            return null;
        }
    }
}
