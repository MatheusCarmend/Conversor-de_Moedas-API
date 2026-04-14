//Interface
using Conversor_de_Moedas_API.DTOs;

namespace Conversor_de_Moedas_API.Services
{
    public interface ICurrencyService
    {
        Task<CurrencyResponseDto> ConvertAsync(CurrencyRequestDto request);
    }
}
