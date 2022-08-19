using jobapplication.Data.Repositories;
using jobapplication.Entity;

namespace jobapplication.Data.Abstract
{
    public interface IWorkerRepository : IGenericRepository<Worker>
    {

        Worker GetByEmail(string email);
    }
}