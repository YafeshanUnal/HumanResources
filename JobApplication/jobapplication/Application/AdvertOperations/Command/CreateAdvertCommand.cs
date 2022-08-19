using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.AdvertOperations.Command
{

    public class CreateAdvertCommand
    {


        EfAdvertRepository _advertRepository;
        EfBossRepository _bossRepository;
        private readonly IMapper _mapper;

        Advert advert = new Advert();


        public CreateAdvertCommandModel Model { get; set; }

        public CreateAdvertCommand(EfAdvertRepository advertRepository, IMapper mapper,EfBossRepository bossRepository)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
            _bossRepository = bossRepository;
        }

        public void Handle()
        {   
            // Only employer can create advert
            var employer = _bossRepository.GetByEmail(Model.Email);
            advert.Department = Model.Department;
            advert.Location = Model.Location;
            advert.Experience = Model.Experience;
            advert.Description = Model.Description;
            advert.Detail = Model.Detail;
            advert.EmployerId = employer.EmployerId;
            advert.workTitle = Model.workTitle;            
            _advertRepository.Insert(advert);

        }



    }

    public class CreateAdvertCommandModel
    {

        public string Email { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
        public string workTitle { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }

    }
}