namespace Conversor_de_Moedas_API.DTOs
{
    public class CurrencyRequestDto
    {
        public string De { get; set; } = string.Empty;
        public string Para { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
    }
}
