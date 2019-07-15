using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class ApartmentsViewModel
    {
        public int CityId { get; set; }
        public List<ApartmentModel> Apartments { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
