using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;
using jobapplication.Entity;

namespace jobapplication.Application.AdvertOperations.Query{

    public class GetAdvertByExperienceQuery{

        private readonly EfAdvertRepository _advertRepository;
        private readonly IMapper _mapper;
        
        public GetAdvertByExperienceQuery(EfAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }
        
        public List<Advert> Handle(int experience)
        {
            return _mapper.Map<List<Advert>>(_advertRepository.GetDate(experience));
        }
        
    }
}