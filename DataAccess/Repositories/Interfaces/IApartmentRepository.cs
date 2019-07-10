using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetAll();
        Apartment GetById(int Id);
        void Save();
        Apartment Add(Apartment apartment);
        IEnumerable<Apartment> GetByCity(int id);
    }
}
