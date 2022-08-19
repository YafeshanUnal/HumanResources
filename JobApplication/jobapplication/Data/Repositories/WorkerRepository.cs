using jobapplication.Data.Database;
using jobapplication.Entity;

namespace jobapplication.Data.Repositories{
    public class WorkerRepository : GenericRepository<Worker>
    {
        public WorkerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}