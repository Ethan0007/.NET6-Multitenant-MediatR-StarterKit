using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Application.Queries.Car
{
    public class GetCarByTenantId : IRequest<List<GetCarByTenantIdResult>>
    {
        public GetCarByTenantId(string tenantId)
        {
            TenantId = tenantId;
        }

        public string TenantId { get; private set; }
    }
}
