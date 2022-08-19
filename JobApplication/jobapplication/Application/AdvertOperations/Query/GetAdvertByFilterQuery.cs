using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.AdvertOperations.Query{

    public class GetAdvertByFilterQuery{
        public string Department { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
        public EfAdvertRepository _efAdvertRepository { get; set; }
        public IMapper _mapper { get; set; }
        public GetAdvertByFilterQuery(EfAdvertRepository efAdvertRepository, IMapper mapper)
        {
            _efAdvertRepository = efAdvertRepository;
            _mapper = mapper;
        }
        public List<Advert> Handle()
        {
            var result = _efAdvertRepository.GetAdvertByFilter(Department, Location, Experience);
            return _mapper.Map<List<Advert>>(result);
        }
    }

}