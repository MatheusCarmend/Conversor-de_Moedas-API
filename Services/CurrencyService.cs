//Implementação
using Conversor_de_Moedas_API.DTOs;
using Conversor_de_Moedas_API.DTOs;
using System.Text.Json;

namespace Conversor_de_Moedas_API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyResponseDto> ConvertAsync(CurrencyRequestDto request)
        {
            var from = request.De.ToUpper();
            var to = request.Para.ToUpper();

            // 🔴 validação básica
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                throw new Exception("Moedas devem ser informadas");

            if (request.Quantidade <= 0)
                throw new Exception("Valor deve ser maior que zero");

            // 🔗 chamada da API externa
            var url = $"https://api.exchangerate-api.com/v4/latest/{from}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao buscar taxa de câmbio");

            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);

            var rates = doc.RootElement.GetProperty("rates");

            if (!rates.TryGetProperty(to, out var rateElement))
                throw new Exception("Moeda de destino inválida");

            var rate = rateElement.GetDecimal();

            return new CurrencyResponseDto
            {
                De = from,
                Para = to,
                Quantidade = request.Quantidade,
                Taxa = rate,
                QuantidadeConvertida = request.Quantidade * rate,
                FromCache = false
            };
        }
    }
}