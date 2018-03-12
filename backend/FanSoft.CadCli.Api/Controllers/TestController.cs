using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FanSoft.CadCli.Api.Controllers
{
    public class TestController : Controller
    {
        [Route("api/v1/test")]
        [AllowAnonymous]
        public string Get()
        {
            return $"Teste de api/v1/test executado às {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }
    }
}
