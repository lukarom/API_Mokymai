using API_Mokymai.Models.Dto;
using API_Mokymai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace API_Mokymai.Controllers.P006
{
    /// <summary>
    /// 6 paskaita. Demonstracija dotNet logging funkcionalumui
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;
        private readonly IBadService _badService;
        private readonly IDivideByZero _divideByZero;
        public LoggingController(ILogger<LoggingController> logger,
            IBadService badService, IDivideByZero dividingByZero)
        {
            _logger = logger;
            _badService = badService;
           _divideByZero = dividingByZero;
        }


        /// <summary>
        /// Demonstruojamas bazinis visu loginimo lygiu funkcionalumas
        /// </summary>
        /// <returns>rezultatu masyvas</returns>
        /// <response code="200">Teisingai ivykdoma loginimo logika ir gaunama informacija</response>
        /// <response code="500">Vaje labai baisi klaida</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetLoggingResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get()
        {
            _logger.LogCritical("Betkokia critical informacija is logerio");
            _logger.LogError("Betkokia error informacija is logerio");
            _logger.LogWarning("Betkokia warning");

            _logger.LogInformation("Betkokia informacija is logerio");
            _logger.LogDebug("Betkokia debug informacija is logerio");
            _logger.LogTrace("Betkokia trace");


            return Ok();
        }

        /// <summary>
        /// Demonstruojamas serviso 'luzimo' situacijos loginimas
        /// </summary>
        /// <returns></returns>
        [HttpGet("BadService")]
        [ProducesResponseType(typeof(GetServiceResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetBadService(int a)
        {
            var b = new Person
            {
                Name = "Petras",
                Surname = "Petraitis",
            };

            _logger.LogInformation("BadService buvo iskvietas {time} a={a} b={b}", DateTime.Now, a, JsonConvert.SerializeObject(b));
            try
            {
                _badService.DoSomeWork();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Blogas servisas nuluzo {time}", DateTime.Now);
            }
            return Ok(new GetServiceResult(555555));
        }

        /// <summary>
        /// Atlieka dalyba is nulio
        /// </summary>
        /// <returns></returns>
        [HttpGet("DividingByZero")]
        [ProducesResponseType(typeof(GetServiceResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult DivideByZero(int x, int y)
        {
            double result = 0;
            _logger.LogInformation("{0}, su parametrais x={1} ir y={2} ", DateTime.Now, x, y);
            try
            {
                result = _divideByZero.DividingByZero(x, y);

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"{0} x = {1}/y={2}", DateTime.Now, x, y);
            }
            return Ok(result);
        }
     
        /*
 * Užduotis
1. Prašykite GET metodą kuris per query priima du sveikus skaičius (Metodą tinkamai jį dokumentuokite)
2. Parašykite servisą kuris atlieka vieno skaičiaus dalybą iš kito. 
   Servise sąmoningai padarykite klaidą, kad vykdant dalybą iš 0 servisas nulūžta
3. Padarykite diagnostinį loginimą kuriame matytusi vartotojo elgsena ir įvesti skaičiai
4. Padarykite exception loginimą kuriame matytųsi gauta klaida, įvesti skaičiai ir klaidos data
 */

    }
}
