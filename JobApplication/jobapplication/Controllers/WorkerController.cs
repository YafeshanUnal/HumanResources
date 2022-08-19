using AutoMapper;
using jobapplication.Application.WorkerOperations.Create;
using jobapplication.Application.WorkerOperations.Query;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace jobapplication.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class WorkerController: ControllerBase{

        EfWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerController(EfWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }
        

        [HttpGet]
        public IActionResult GetAllWorkers(){
            GetWorkerQuery query = new GetWorkerQuery(_workerRepository, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateWorker([FromBody] CreateWorkerCommandModel newWorker){
            CreateWorkerCommand command = new CreateWorkerCommand(_workerRepository, _mapper);
            command.Model = newWorker;
            command.Handle();
            return Ok();
        }
    }
}