using jobapplication.Data.Database;
using jobapplication.Entity;

namespace jobapplication.Data.Repositories
{
    public class EmployerRepository : GenericRepository<Employer>
    {
        public EmployerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}