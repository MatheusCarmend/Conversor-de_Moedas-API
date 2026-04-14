using Conversor_de_Moedas_API.DTOs;
using Conversor_de_Moedas_API.Models;
using Conversor_de_Moedas_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;

        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }

        [HttpPost("convert")]
        public async Task<IActionResult> Convert([FromBody] CurrencyRequestDto request)
        {
            try
            {
                var result = await _service.ConvertAsync(request);

                return Ok(new ApiResponse<object>(
                    true,
                    "Conversão realizada com sucesso",
                    result
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(
                    false,
                    ex.Message,
                    null
                ));
            }
        }
    }
}