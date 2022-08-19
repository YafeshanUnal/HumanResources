using System.Collections.Generic;
using System.Linq;
using jobapplication.Data.Abstract;
using jobapplication.Data.Database;
using jobapplication.Data.Repositories;
using jobapplication.Entity;

namespace jobapplication.Data.EntityFramework
{

    public class EfAdvertRepository : GenericRepository<Advert>, IAdvertRepository
    {

        private readonly DatabaseContext _context;

        public EfAdvertRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }


        public List<Advert> GetDepartment(string department)
        {
            return _context.Adverts.Where(x => x.Department == department).ToList();
        }

        public List<Advert> GetLocation(string location)
        {
            return _context.Adverts.Where(x => x.Location == location).ToList();
        }


        public List<Advert> GetDate(int experience)
        {
            return _context.Adverts.Where(x => x.Experience == experience).ToList();
        }

        public void CreateApplication(int workerId, int advertId)
        {
            var advert = _context.Adverts.Where(x => x.AdvertId == advertId).FirstOrDefault();
            advert.WorkerId = workerId;
            _context.SaveChanges();

        }

        public List<Advert> GetAdvertByFilter(string department, string location, int experience)
        {
            if (department == "")
            {
                return _context.Adverts.Where(x => x.Location == location && x.Experience == experience).ToList();
            }
            else if(department == "" && experience == 0){
                return _context.Adverts.Where(x => x.Location == location).ToList();
            }
            if (location == "")
            {
                return _context.Adverts.Where(x => x.Department == department && x.Experience == experience).ToList();
            }
            if (experience == 0)
            {
                return _context.Adverts.Where(x => x.Department == department && x.Location == location).ToList();
            }

            // Up section are completed to succesfully

            return _context.Adverts.Where(x => x.Department == department && x.Location == location && x.Experience == experience).ToList();
        }

    }
}