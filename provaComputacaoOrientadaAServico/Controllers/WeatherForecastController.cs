using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using provaComputacaoOrientadaAServico.Model;
using provaComputacaoOrientadaAServico.PostgreSQL;
using provaComputacaoOrientadaAServico.Repository;

namespace provaComputacaoOrientadaAServico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DbConnection dbConnection = new DbConnection();

        private CorRepository corRepository = new CorRepository();

        private static readonly string[] Summaries = new[]

        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        

        // GET: api/YourEntities
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Cor>>> GetAll()
        {
            var cores = corRepository.GetAll();
            return Ok(cores);
        }

        [HttpGet("GetById{id}")]
        public ActionResult<Cor> GetById(int id)
        {
            var cor = corRepository.GetById(id);
            if (cor == null)
            {
                return NotFound();
            }
            return Ok(cor);
        }

        [HttpPost("Add")]
        public ActionResult<bool> Add(Cor cor = null)
        {
            var result = false;
            if (cor == null)
            {
                return StatusCode(400, "a cor deve ser informano .");
            }
            else
            {
                result = corRepository.Add(cor);
            }
            
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return Ok(result);
        }

        [HttpDelete("DeletById{id}")]
        public IActionResult Delete(int id)
        {
            var cor = corRepository.GetById(id);
            if (cor == null)
            {
                return NotFound();
            }

            var result = corRepository.Delete(id);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpPut("Update{id}")]
        public IActionResult Update(int id, [FromBody] Cor cor = null)
        {
            if (cor == null || cor.Id != id )
            {
                return BadRequest();
            }

            var existingCor = corRepository.GetById(id);
            if (existingCor == null)
            {
                return NotFound();
            }

            var result = corRepository.Update(cor);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

    }
}
