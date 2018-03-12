using FanSoft.CadCli.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts = FanSoft.CadCli.Core.Domain.Contracts;
using Commands = FanSoft.CadCli.Core.Domain.Commands;

namespace FanSoft.CadCli.Api.Clientes
{
    [Route("api/v1/clientes")]
    public class ClientesController : Controller
    {
        private readonly Contracts.Repositories.IClienteRepository _ctx;
        private readonly Contracts.Data.IUnitOfWork _uow;
        private readonly Commands.ClienteCommand.ClientesCommandHandler _commandHandler;

        public ClientesController(
            Contracts.Repositories.IClienteRepository ctx,
            Contracts.Data.IUnitOfWork uow,
            Commands.ClienteCommand.ClientesCommandHandler commandHandler)
        {
            _ctx = ctx;
            _uow = uow;
            _commandHandler = commandHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var clientes = (await _ctx.GetAsync()).ToVM();
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = (await _ctx.GetAsync(id));

            if (cliente == null)
                return NotFound();

            return Ok(cliente.ToVM());
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] Commands.ClienteCommand.AddClienteCommand command)
        {
            var data = _commandHandler.Handle(command) as Cliente;

            //TODO
            //if (_commandHandler.Errors.Any())
            //    return BadRequest(_commandHandler.Errors);

            if (!await this.Commit())
                return StatusCode(500);

            return CreatedAtRoute("GetCliente", new { id = data.Id }, new
            {
                id = data.Id,
                nome = data.Nome,
                sexo = data.Sexo
            });

        }

        protected async Task<bool> Commit()
        {
            try
            {
                await _uow.CommitAsync();
                return true;
            }
            catch
            {
                //log
                return false;
            }

        }
    }
}
