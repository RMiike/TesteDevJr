using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TDJ.Dominio.ViewModel;
using TDJ.Servicos.Interfaces;

namespace TDJ.Servicos.Servicos
{
    public class ServicosDeProduto : IServicosDeProduto
    {

        private readonly HttpClient _httpClient;

        public ServicosDeProduto(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44350");
            _httpClient = httpClient;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            //TODO
            var resposta = await _httpClient.GetAsync($"/v1/produto-api/{id}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<ProdutoViewModel>(await resposta.Content.ReadAsStringAsync(), options);


        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var resposta = await _httpClient.GetAsync($"/v1/produto-api");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            return JsonSerializer.Deserialize<IEnumerable<ProdutoViewModel>>(await resposta.Content.ReadAsStringAsync(), options);
        }
    }
}
