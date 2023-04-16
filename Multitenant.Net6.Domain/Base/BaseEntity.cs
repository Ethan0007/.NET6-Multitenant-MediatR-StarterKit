using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Net6.Domain.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; private set; }
        public DateTime DateCreated { set; get; }
        public DateTime DateUpdated { set; get; }
    }
}
