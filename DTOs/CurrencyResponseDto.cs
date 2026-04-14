namespace Conversor_de_Moedas_API.DTOs
{
    public class CurrencyResponseDto
    {
        public string De { get; set; } = string.Empty;
        public string Para { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
        public decimal Taxa { get; set; }
        public decimal QuantidadeConvertida { get; set; }
        public bool FromCache { get; set; }
    }
}
