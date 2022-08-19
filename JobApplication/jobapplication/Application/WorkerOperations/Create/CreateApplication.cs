using System;
using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.WorkerOperations.Create
{

    public class CreateApplication
    {

        EfWorkerRepository _workerRepository;
        EfAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public int Id { get; set; }

        Advert Advert = new Advert();
        public CreateApplicationModel Model { get; set; }

        public CreateApplication(EfWorkerRepository workerRepository, IMapper mapper, EfAdvertRepository advertRepository)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public void Handle()
        {
            var worker = _workerRepository.GetByEmail(Model.Email);
            Console.WriteLine("Worker Id" + worker.WorkerId);
            _advertRepository.CreateApplication(worker.WorkerId, Id);
        }


    }

    public class CreateApplicationModel
    {
        public string Email { get; set; }

    }
}