using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;

namespace jobapplication.Application.WorkerOperations.Query{



    public class GetWorkerQuery{

        EfWorkerRepository _workerRepository { get; set; }
        private readonly IMapper _mapper;
        public GetWorkerQuery(EfWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }
        public List<GetWorkerQueryModel> Handle(){
            var worker = _workerRepository.GetListAll();
            List<GetWorkerQueryModel> vm =  _mapper.Map<List<GetWorkerQueryModel>>(worker);
            return vm;
        }
    }

    public class GetWorkerQueryModel{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Title { get; set; }
    }
}