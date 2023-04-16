using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Domain.Repository
{
    public interface ITenant : IService
    {
        public string TenantId { get; set; }
    }
}
