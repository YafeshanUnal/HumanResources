using System;
using jobapplication.Data.EntityFramework;

namespace jobapplication.Application.Login{


    public class WorkerLoginCommand{

        EfWorkerRepository _workerRepository;
        public WorkerLoginCommandModel Model { get; set; }

        public WorkerLoginCommand(EfWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public void Handle()
        {

            var worker = _workerRepository.GetByEmail(Model.Email);
            Console.WriteLine(worker.Email+" "+worker.password);
            if (worker == null)
            {
                throw new Exception("Employer not found");
            }

            try
            {
                if (Model.Email == worker.Email && Model.Password == worker.password)
                {
                    Console.WriteLine("Login Successful");

                }
            }

            catch
            {
                throw new Exception("Login Failed");
            }


        }
    }

    public class WorkerLoginCommandModel
    {

        public string Email { get; set; }
        public string Password { get; set; }

    }
}