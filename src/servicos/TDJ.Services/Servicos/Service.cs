using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.ViewModel;

namespace TDJ.Servicos.Servicos
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }
        protected async Task<T> Deserializar<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var conteudo = responseMessage.Content.ReadAsStringAsync();
            var resultado = JsonSerializer.Deserialize<ClienteViewModel>(await responseMessage.Content.ReadAsStringAsync(), options);
            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

    }
}
