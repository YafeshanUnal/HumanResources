using AutoMapper;
using jobapplication.Application.Login;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace jobapplication.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class SignupController:ControllerBase{

        EfBossRepository _bossRepository;
        EfWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public SignupController(EfBossRepository bossRepository , EfWorkerRepository workerRepository, IMapper mapper)
        {
            _bossRepository = bossRepository;
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Signup([FromBody] SignupCommandModel signup){
            SignupCommand command = new SignupCommand(_bossRepository,_workerRepository,_mapper);
            command.Model = signup;
            command.Handle();
            return Ok();
        }        


    }

}