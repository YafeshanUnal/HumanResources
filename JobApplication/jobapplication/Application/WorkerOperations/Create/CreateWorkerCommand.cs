using AutoMapper;
using jobapplication.Entity;
using jobapplication.Data.EntityFramework;

namespace jobapplication.Application.WorkerOperations.Create{

    public class CreateWorkerCommand{

        EfWorkerRepository _workerRepository { get; set; }
        private readonly IMapper _mapper;
        public CreateWorkerCommandModel Model { get; set; }
        public CreateWorkerCommand(EfWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }


        public void Handle()
        {
            var worker = _mapper.Map<Worker>(Model);
            _workerRepository.Insert(worker);
        }



    }


    public class CreateWorkerCommandModel{

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string WorkerTitle { get; set; }
    }
}