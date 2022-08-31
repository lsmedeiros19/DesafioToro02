using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Services.Interfaces;

namespace ProjetoToro.Controllers
{
    [Route("api/[controller]")]
    public class UserPositionController : Controller
    {
        private ILogger<UserPositionController> Logger { get; }    
        private IUserPositionService Service { get; }

        public UserPositionController(ILoggerFactory logger, IUserPositionService service)
        {
            Logger = logger.CreateLogger<UserPositionController>(); 
            Service = service;
        }

        [HttpGet("ProcessarPosicao")]
        public async Task<IActionResult> ProcessarPosicao()
        {
            Logger.LogInformation($"Processando posição do cliente");
            await Service.ProcessarPosicao();
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                Logger.LogInformation($"Retornando posição do cliente {id}.");
                return Ok(await Service.Get());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
