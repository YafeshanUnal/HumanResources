using AutoMapper;
using jobapplication.Application.AdvertOperations.Command;
using jobapplication.Application.AdvertOperations.Query;
using jobapplication.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace jobapplication.Controllers{

    [ApiController]
    [Route("[controller]s")]

    public class AdvertController : ControllerBase{

        EfAdvertRepository _efAdvertRepository;
        EfBossRepository _efBossRepository;
        private readonly IMapper _mapper;

        public AdvertController(EfAdvertRepository efAdvertRepository , IMapper mapper,EfBossRepository efBossRepository)
        {
            _efAdvertRepository = efAdvertRepository;
            _mapper = mapper;
            _efBossRepository = efBossRepository;
        }

        [HttpGet]
        public IActionResult GetAllAdverts(){
            GetAdvertQuery query = new GetAdvertQuery(_efAdvertRepository, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAdvert([FromBody] CreateAdvertCommandModel newAdvert){
            CreateAdvertCommand command = new CreateAdvertCommand(_efAdvertRepository, _mapper,_efBossRepository);
            command.Model = newAdvert;
            command.Handle();
            return Ok();
        }

        [HttpPost("filter")]
        public IActionResult GetAdvertByFilter([FromBody] GetAdvertByFilterCommandModel filter){
            GetAdvertByFilterCommand command = new GetAdvertByFilterCommand(_efAdvertRepository, _mapper);
            command.Model = filter;
            var result = command.Handle();
            return Ok(result);
        }

        // [HttpGet("department={department}")]
        // public IActionResult GetByDepartment(string department){
        //     GetAdvertByDepartmentQuery query = new GetAdvertByDepartmentQuery(_efAdvertRepository, _mapper);
        //     var result = query.Handle(department);
        //     return Ok(result);
        // }

        // [HttpGet("location={location}")]
        // public IActionResult GetByLocation(string location){
        //     GetAdvertByLocationQuery query = new GetAdvertByLocationQuery(_efAdvertRepository, _mapper);
        //     var result = query.Handle(location);
        //     return Ok(result);
        // }

        // [HttpGet("experience/{experience}")]
        // public IActionResult GetByExperience(int experience){
        //     GetAdvertByExperienceQuery query = new GetAdvertByExperienceQuery(_efAdvertRepository, _mapper);
        //     var result = query.Handle(experience);
        //     return Ok(result);
        // }


    }
}