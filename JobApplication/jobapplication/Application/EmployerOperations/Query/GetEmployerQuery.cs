using System.Collections.Generic;
using AutoMapper;
using jobapplication.Data.EntityFramework;

namespace jobapplication.Application.EmployerOperations.Query
{

    public class GetEmployerQuery
    {

        EfBossRepository _bossRepository { get; set; }
        private readonly IMapper _mapper;

        public GetEmployerQueryModel Model { get; set; }

        public GetEmployerQuery(EfBossRepository bossRepository, IMapper mapper)
        {
            _bossRepository = bossRepository;
            _mapper = mapper;
        }


        public List<GetEmployerQueryModel> Handle()
        {
            var bosses = _bossRepository.GetListAll();
            List<GetEmployerQueryModel> vm = _mapper.Map<List<GetEmployerQueryModel>>(bosses);
            return vm;
        }

    }


    public class GetEmployerQueryModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Title { get; set; }
    }
}