using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.Extensions;
using TDJ.Servicos.Interfaces;

namespace TDJ.Servicos.Servicos
{
    public class ServicosDeCliente : Service, IServicosDeCliente
    {
        private readonly HttpClient _httpClient;


        public ServicosDeCliente(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            httpClient.BaseAddress = new Uri(appSettings.Value.BaseUrl);
            _httpClient = httpClient;
        }

        public async Task<ResultadoCustomizado> ObterPorId(Guid id)
        {
            var resposta = await _httpClient.GetAsync($"/v1/cliente-api/{id}");

            return await Deserializar<ResultadoCustomizado>(resposta);
        }

        public async Task<ResultadoCustomizado> ObterTodos()
        {
            var resposta = await _httpClient.GetAsync($"/v1/cliente-api/");
            return await Deserializar<ResultadoCustomizado>(resposta);

        }
    }
}
