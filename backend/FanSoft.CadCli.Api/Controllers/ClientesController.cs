using FanSoft.CadCli.Core.Data.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FanSoft.CadCli.Api.Controllers
{
    [Route("api/v1/clientes")]
    public class ClientesController : Controller
    {
        private readonly CadCliDataContext _ctx;
        public ClientesController(CadCliDataContext ctx) => _ctx = ctx;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var clientes = await _ctx.Clientes.ToListAsync();
            return Ok(clientes);
        }


    }
}
