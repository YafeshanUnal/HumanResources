using jobapplication.Application.Login;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace jobapplication.Application.Controllers{


    [ApiController]
    [Route("[controller]s")]
    public class LoginController:ControllerBase{

        EfBossRepository _bossRepository;
        EfWorkerRepository _workerRepository;

        public LoginController(EfBossRepository bossRepository , EfWorkerRepository workerRepository)
        {
            _bossRepository = bossRepository;
            _workerRepository = workerRepository;
        }

        [HttpPost]
        public IActionResult LoginEmployer([FromBody] LoginCommandModel login){
            LoginCommand command = new LoginCommand(_bossRepository,_workerRepository);
            command.Model = login;
            command.Handle();
            return Ok();
        }

        
    }
}