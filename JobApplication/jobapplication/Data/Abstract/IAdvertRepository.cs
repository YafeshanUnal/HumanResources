using System.Collections.Generic;
using jobapplication.Data.Repositories;
using jobapplication.Entity;

namespace jobapplication.Data.Abstract
{
    public interface IAdvertRepository : IGenericRepository<Advert>
    {

        List<Advert> GetDepartment (string department);
        List<Advert> GetLocation(string location);
        List<Advert> GetDate(int experience);

        void CreateApplication(int workerId,int advertId);

        List<Advert> GetAdvertByFilter(string department, string location, int experience);

    }
}