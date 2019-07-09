using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    interface IRatingRepository
    {
        List<Rating> GetAll();
        float GetById(int Id);
        void Update();
    }
}
