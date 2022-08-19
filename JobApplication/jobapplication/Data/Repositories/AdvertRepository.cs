using jobapplication.Data.Database;
using jobapplication.Entity;

namespace jobapplication.Data.Repositories{

    public class AdvertRepository : GenericRepository<Advert>
    {
        public AdvertRepository(DatabaseContext context) : base(context)
        {
        }

    }
    
}