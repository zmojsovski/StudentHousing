﻿using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly SHContext _context;

        public RatingRepository(SHContext context)
        {
            _context = context;
        }
        public void Add(Rating rating)
        {
            _context.Ratings.Add(rating);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<Rating> GetRatings()
        {
            return _context.Ratings.AsQueryable();
        }
    }
}
