using System;
using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.AdvertOperations.Command{

    public class GetAdvertByFilterCommand{

      
        public EfAdvertRepository _efAdvertRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetAdvertByFilterCommandModel Model { get; set; }
        public GetAdvertByFilterCommand(EfAdvertRepository efAdvertRepository, IMapper mapper)
        {
            _efAdvertRepository = efAdvertRepository;
            _mapper = mapper;
        }
        public List<Advert> Handle()
        {
            var result = _efAdvertRepository.GetAdvertByFilter(Model.Department, Model.Location, Model.Experience);
            Console.WriteLine(Model.Department + " " + Model.Location + " " + Model.Experience);
            return _mapper.Map<List<Advert>>(result);
        }
    }

    public class GetAdvertByFilterCommandModel{
        public string Department { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
    }
}