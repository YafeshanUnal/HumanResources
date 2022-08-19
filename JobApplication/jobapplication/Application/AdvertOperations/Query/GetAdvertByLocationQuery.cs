using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.AdvertOperations.Query{

    public class  GetAdvertByLocationQuery{

        private readonly EfAdvertRepository _advertRepository;
        private readonly IMapper _mapper;
        
        public GetAdvertByLocationQuery(EfAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }
        
        public List<Advert> Handle(string location)
        {
            return _mapper.Map<List<Advert>>(_advertRepository.GetLocation(location));
        }
        
    }
}