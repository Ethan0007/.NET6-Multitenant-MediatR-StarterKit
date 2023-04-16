using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Domain.Tenant
{
    public class DefaultDb
    {
        public string DBProvider { get; set; }
        public string ConnectionString { get; set; }
    }
}
