using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    interface ICityRepository
    {
        List<City> GetAll();
        City GetById(int Id);
        void Update();
    }
}
