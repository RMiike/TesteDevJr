using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TDJ.Dominio.Extensions;
using TDJ.Dominio.ViewModel;
using TDJ.Servicos.Interfaces;

namespace TDJ.Servicos.Servicos
{
    public class ServicosDeProduto : Service, IServicosDeProduto
    {

        private readonly HttpClient _httpClient;

        private readonly AppSettings _appSettings;

        public ServicosDeProduto(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            httpClient.BaseAddress = new Uri(_appSettings.BaseUrl);
            _httpClient = httpClient;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var resposta = await _httpClient.GetAsync($"v1/produto-api/{id}");
            return await Deserializar<ProdutoViewModel>(resposta);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var resposta = await _httpClient.GetAsync($"v1/produto-api");
            return await Deserializar<IEnumerable<ProdutoViewModel>>(resposta);
        }
    }
}
