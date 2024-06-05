using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Tests.Helpers
{
    /// <summary>
    /// Classe auxiliar para desenvolvimento dos testes
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Método para retornar um objeto HTTP CLIENT para
        /// fazer requisições para os serviços da API
        /// </summary>
        public static HttpClient CreateClient
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Método para serializar os dados de um objeto
        /// e retorna-lo no formato JSON
        /// </summary>
        public static StringContent CreateContent<T>(T obj)
            => new StringContent(JsonConvert.SerializeObject(obj),
                Encoding.UTF8, "application/json");

        /// <summary>
        /// Método para deserializar os dados de um objeto
        /// retornado em uma chamada feita para a API
        /// </summary>
        public static T? ReadContent<T>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
    }
}
