using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Domain.Tenant
{
    public class TenantSettings
    {       
        public DefaultDb DefaultDb { get; set; }
        public List<TenantInfo> Tenants { get; set; }
    }
}
