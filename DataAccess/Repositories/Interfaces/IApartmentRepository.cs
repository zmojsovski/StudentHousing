using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    interface IApartmentRepository
    {
        List<Apartment> GetAll();
        Apartment GetById(int Id);
        void Update();
        void Add();
    }
}
