using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Application.Queries.Car
{
    public class GetCarByTenantIdResult
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string VIN { get; set; }
        public string Transmission { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string TenantId { get; set; }
    }
}
