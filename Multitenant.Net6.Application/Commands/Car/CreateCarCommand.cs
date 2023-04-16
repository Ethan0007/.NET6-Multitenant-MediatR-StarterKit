using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Application.Commands.Car
{
    public class CreateCarCommand : IRequest<bool>
    {
        public CreateCarCommand(string name, decimal price, 
            string vin, string transmission, string exteriorColor,
            string interiorColor, string tenantId)
        {
            Name = name;
            Price = price;
            VIN = vin;
            Transmission = transmission;
            ExteriorColor = exteriorColor;
            InteriorColor = interiorColor;
            TenantId = tenantId;
        }

        public string Name { get; private set; }
        public decimal? Price { get; private set; }
        public string VIN { get; private set; }
        public string Transmission { get; private set; }
        public string ExteriorColor { get; private set; }
        public string InteriorColor { get; private set; }
        public string TenantId { get; private set; }
    }
}
