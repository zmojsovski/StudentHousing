﻿using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly SHContext _context;

        //private  SHContext context = new SHContext();
        public ApartmentRepository(SHContext context)
        {
            _context = context;
        }
        public void Add(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
        }

        public IQueryable<Apartment> GetApartments()
        {
            return _context.Apartments.AsQueryable();
        }

        public IQueryable<Apartment> GetByCity(int id)
        {
            return _context.Apartments.Where(x => x.CityId == id).Include(x => x.Ratings);         
        }
    }
}
