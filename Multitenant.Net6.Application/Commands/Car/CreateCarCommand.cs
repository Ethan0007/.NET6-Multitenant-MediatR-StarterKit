using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Application.Commands.Car
{
    public record CreateCarCommand(string Name, decimal Price,
            string VIN, 
            string Transmission, 
            string ExteriorColor,
            string InteriorColor, 
            string TenantId) 
        : IRequest<bool>
    { }
}


