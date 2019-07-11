using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    interface ICityService
    {
        City GetCityById(int Id);
    }
}
