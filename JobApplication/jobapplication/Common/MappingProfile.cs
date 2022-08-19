using jobapplication.Application.AdvertOperations.Command;
using jobapplication.Entity;
using AutoMapper;
using jobapplication.Application.AdvertOperations.Query;
using jobapplication.Application.EmployerOperations.Create;
using jobapplication.Application.EmployerOperations.Query;
using jobapplication.Application.WorkerOperations.Create;
using jobapplication.Application.WorkerOperations.Query;

namespace jobapplication.Common{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAdvertCommandModel, Advert>();
            CreateMap<Advert, AdvertQueryModel>();
            CreateMap<CreateEmployerCommandModel, Employer>();
            CreateMap<Employer, GetEmployerQueryModel>();
            CreateMap<CreateWorkerCommandModel, Worker>();
            CreateMap<Worker, GetWorkerQueryModel>();

        }
    }
}