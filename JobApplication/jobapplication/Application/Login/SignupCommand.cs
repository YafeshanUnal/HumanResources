using System;
using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.Login
{

    public class SignupCommand
    {

        EfBossRepository _bossRepository { get; set; }
        EfWorkerRepository _workerRepository { get; set; }
        private readonly IMapper _mapper;

        Employer employer = new Employer();
        Worker worker = new Worker();

        public SignupCommandModel Model { get; set; }

        public SignupCommand(EfBossRepository bossRepository, EfWorkerRepository workerRepository, IMapper mapper)
        {
            _bossRepository = bossRepository;
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public void Handle()
        {

            if (Model.UserType == "employer")
            {

                employer.Name = Model.Name;
                employer.Surname = Model.Surname;
                employer.Email = Model.Email;
                employer.password = Model.Password;
                _bossRepository.Insert(employer);
            }
            else if (Model.UserType == "worker")
            {
                worker.Name = Model.Name;
                worker.Surname = Model.Surname;
                worker.Email = Model.Email;
                worker.password = Model.Password;
                _workerRepository.Insert(worker);
            }
            else
            {
                throw new Exception("User type is not specified");
            }

        }


    }

    public class SignupCommandModel
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

    }
}