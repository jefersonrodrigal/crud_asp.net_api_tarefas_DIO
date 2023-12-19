using ApiTarefas.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public HomeView Index()
        {
            return new HomeView
            {
                Menssagem = "Voce acessou nossa API",
                Documentacao ="/Swagger"
            };
        }
    }
}