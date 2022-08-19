using System.Linq;
using jobapplication.Data.Abstract;
using jobapplication.Data.Database;
using jobapplication.Data.Repositories;
using jobapplication.Entity;

namespace jobapplication.Data.EntityFramework
{
    public class EfWorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {

        private readonly DatabaseContext _context;
        public EfWorkerRepository(DatabaseContext context) : base(context)
        {
            _context = context;

        }

        public Worker GetByEmail(string email)
        {
            return _context.Workers.FirstOrDefault(w => w.Email == email);
        }
    }
}