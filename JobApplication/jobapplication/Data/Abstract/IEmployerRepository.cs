using jobapplication.Data.Repositories;
using jobapplication.Entity;

namespace jobapplication.Data.Abstract
{
    public interface IEmployerRepository : IGenericRepository<Employer>
    {

        Employer GetByEmail(string email);
    }
}