using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public bool Active { get; protected set; } = true;


      
    }
}
