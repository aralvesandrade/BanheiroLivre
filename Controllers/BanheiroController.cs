using System;
using AutoMapper;
using banheiro_livre.Domain;
using banheiro_livre.Extensions;
using banheiro_livre.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banheiro_livre.Controllers
{
    [Route("api/banheiro")]
    [ApiController]
    public class BanheiroController : ControllerBase
    {
        private readonly BanheiroService _banheiroService;
        private readonly IMapper _mapper;
        private readonly ILogger<BanheiroController> _logger;

        public BanheiroController(ILogger<BanheiroController> logger, IMapper mapper, BanheiroService banheiroService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _banheiroService = banheiroService ?? throw new ArgumentNullException(nameof(banheiroService));
        }

        [HttpGet("todos")]
        public IActionResult ListarTodos()
        {
            var banheiros = _banheiroService.ListarTodos();

            return Ok(banheiros);
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var response = new Banheiro();

            try
            {
                (bool sucesso, string erroMensagem, Banheiro banheiro) = _banheiroService.ListarPorId(id);

                if (!sucesso)
                    return BadRequest(erroMensagem);
                else
                    response = banheiro;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message} - {ex.StackTrace}");
                return ReplyHelper.ErrorMessage(ex.Message);
            }

            return Ok(response);
        }

        [HttpPost("inserir")]
        public IActionResult Adicionar([FromBody]ViewModelBanheiro body)
        {
            Banheiro banheiro = null;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var request = _mapper.Map<Banheiro>(body);
                banheiro = _banheiroService.Adicionar(request);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message} - {ex.StackTrace}");
                return ReplyHelper.ErrorMessage(ex.Message);
            }

            return Ok(banheiro);
        }
    }
}