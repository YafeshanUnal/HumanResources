using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;

namespace jobapplication.Application.AdvertOperations.Query{

    public class GetAdvertQuery{

        EfAdvertRepository _advertRepository;

        private readonly IMapper _mapper;

        public GetAdvertQuery(EfAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public List<AdvertQueryModel> Handle(){


            var advert = _advertRepository.GetListAll();
            List<AdvertQueryModel> vm = _mapper.Map<List<AdvertQueryModel>>(advert);


            return vm;


        }
    }

    public class AdvertQueryModel
    {
        public int AdvertId { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
        public string workTitle { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int BossId { get; set; }
        public int WorkerId { get; set; }
    }
}