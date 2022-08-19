using System.Linq;
using jobapplication.Data.Abstract;
using jobapplication.Data.Database;
using jobapplication.Data.Repositories;
using jobapplication.Entity;

namespace jobapplication.Data.EntityFramework
{
    public class EfBossRepository : GenericRepository<Employer>, IEmployerRepository
    {
      
      private readonly DatabaseContext _context;

      public EfBossRepository(DatabaseContext context) : base(context)
      {
          _context = context;
      }

        public Employer GetByEmail(string email)
        {
            return _context.Employers.FirstOrDefault(e => e.Email == email);
        }
    }
}