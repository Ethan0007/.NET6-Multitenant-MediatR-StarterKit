using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Application.Commands.Car
{
    public class UpdateCarCommand : IRequest<bool>
    {
        public UpdateCarCommand(int id , string name, decimal price,
           string vin, string transmission, string exteriorColor,
           string interiorColor)
        {
            Id = id;
            Name = name;
            Price = price;
            VIN = vin;
            Transmission = transmission;
            ExteriorColor = exteriorColor;
            InteriorColor = interiorColor;
        }

        public int Id { set; get; }
        public string Name { get; private set; }
        public decimal? Price { get; private set; }
        public string VIN { get; private set; }
        public string Transmission { get; private set; }
        public string ExteriorColor { get; private set; }
        public string InteriorColor { get; private set; }
    }
}
