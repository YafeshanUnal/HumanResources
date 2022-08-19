using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.EmployerOperations.Create
{
    public class CreateEmployerCommand 
    {
     
     EfBossRepository _bossRepository { get; set; }
     private readonly IMapper _mapper;



     public CreateEmployerCommandModel Model { get; set; }

     public CreateEmployerCommand(EfBossRepository bossRepository, IMapper mapper)
     {
         _bossRepository = bossRepository;
         _mapper = mapper;
     }


     public void Handle()
     {
         var employer = _mapper.Map<Employer>(Model);
         _bossRepository.Insert(employer);
     }
     
    }

    public class CreateEmployerCommandModel{

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }

    }
}