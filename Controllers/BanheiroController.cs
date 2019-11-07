using System;
using AutoMapper;
using banheiro_livre.Domain;
using banheiro_livre.Extensions;
using banheiro_livre.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banheiro_livre.Controllers
{
    [Route("api/banheiro")]
    [ApiController]
    public class BanheiroController : ControllerBase
    {
        private readonly ILogger<BanheiroController> _logger;
        private readonly IMapper _mapper;
        private IValidator<AdicionarBanheiroPostRequest> _adicionarBanheiroValidator;
        private readonly BanheiroService _banheiroService;

        public BanheiroController(
            ILogger<BanheiroController> logger,
            IMapper mapper,
            IValidator<AdicionarBanheiroPostRequest> adicionarBanheiroValidator,
            BanheiroService banheiroService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _adicionarBanheiroValidator = adicionarBanheiroValidator ?? throw new ArgumentNullException(nameof(adicionarBanheiroValidator));
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
                    //return BadRequest(erroMensagem);
                    return BadRequest(new ErrorResponse(new ErrorModel{ Message = erroMensagem }));
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
        public IActionResult Adicionar([FromBody]AdicionarBanheiroPostRequest body)
        {
            var response = new AdicionarBanheiroPostResponse();

            //var validationResult = _adicionarBanheiroValidator.Validate(body);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var request = _mapper.Map<Banheiro>(body);
                var banheiro = _banheiroService.Adicionar(request);
                response = _mapper.Map<AdicionarBanheiroPostResponse>(banheiro);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mensagem: {ex.Message} - {ex.StackTrace}");
                return ReplyHelper.ErrorMessage(ex.Message);
            }

            return Ok(response);
        }
    }
}