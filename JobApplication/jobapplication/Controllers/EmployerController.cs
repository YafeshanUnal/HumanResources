using AutoMapper;
using jobapplication.Application.EmployerOperations.Create;
using jobapplication.Application.EmployerOperations.Query;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace jobapplication.Controller{


    [ApiController]
    [Route("[controller]s")]
    public class EmployerController : ControllerBase{

        EfBossRepository _bossRepository { get; set; }        
        private readonly IMapper _mapper;

        public EmployerController( EfBossRepository bossRepository, IMapper mapper)
        {
            _bossRepository = bossRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployer(){
            GetEmployerQuery query = new GetEmployerQuery(_bossRepository, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateEmployer([FromBody] CreateEmployerCommandModel newEmployer){
            CreateEmployerCommand command = new CreateEmployerCommand(_bossRepository, _mapper);
            command.Model = newEmployer;
            command.Handle();
            return Ok();


        }

    }
}