using AutoMapper;
using jobapplication.Application.WorkerOperations.Create;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace jobapplication.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class ApplicationController : ControllerBase{

        EfWorkerRepository _workerRepository;
        EfAdvertRepository _advertRepository;
        private readonly IMapper _mapper;
        

        public ApplicationController(EfAdvertRepository advertRepository, EfWorkerRepository workerRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public IActionResult CreateApp([FromBody] CreateApplicationModel newApplication,int id){
            CreateApplication command = new CreateApplication(_workerRepository,_mapper,_advertRepository);
            command.Id = id;
            command.Model = newApplication;
            command.Handle();
            return Ok();
        }



    }
}