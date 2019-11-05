using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banheiro_livre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BanheiroController : ControllerBase
    {
        private readonly ILogger<BanheiroController> _logger;
        private readonly BanheiroService _banheiroService;

        public BanheiroController(ILogger<BanheiroController> logger, BanheiroService banheiroService)
        {
            _logger = logger;
            _banheiroService = banheiroService;
        }

        [HttpGet]
        public string[] Get()
        {
            return _banheiroService.GetAll();
        }
    }
}