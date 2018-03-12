using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FanSoft.CadCli.Api.Clientes
{
    [Route("api/v1/clientes")]
    public class ClientesController:Controller
    {
        private readonly Core.Domain.Contracts.Repositories.IClienteRepository _ctx;
        public ClientesController(Core.Domain.Contracts.Repositories.IClienteRepository ctx) => _ctx = ctx;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var clientes = (await _ctx.GetAsync()).ToVM();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = (await _ctx.GetAsync(id));

            if (cliente == null)
                return NotFound();

            return Ok(cliente.ToVM());
        }
    }
}
