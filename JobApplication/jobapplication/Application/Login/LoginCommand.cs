using System;
using jobapplication.Data.EntityFramework;

namespace jobapplication.Application.Login
{

    public class LoginCommand
    {

        EfBossRepository _bossRepository;
        EfWorkerRepository _workerRepository;
        public LoginCommandModel Model { get; set; }

        public LoginCommand(EfBossRepository bossRepository, EfWorkerRepository workerRepository)
        {
            _bossRepository = bossRepository;
            _workerRepository = workerRepository;
        }
        public void Handle()
        {

            if (Model.UserType == "employer")
            {
                var employer = _bossRepository.GetByEmail(Model.Email);
                if (employer == null)
                {
                    throw new Exception("Employer not found");
                }
                if (employer.password != Model.Password)
                {
                    throw new Exception("Password is incorrect");
                }
            }
            else if (Model.UserType == "worker")
            {
                var worker = _workerRepository.GetByEmail(Model.Email);
                if (worker == null)
                {
                    throw new Exception("Worker not found");
                }
                if (worker.password != Model.Password)
                {
                    throw new Exception("Password is incorrect");
                }
            }
            else
            {
                throw new Exception("User type is not specified");
            }

           

        }
    }

    public class LoginCommandModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

    }
}