using System;
using System.Collections.Generic;

namespace Matjary.Models
{
    public partial class ProductPersons
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int PersonId { get; set; }

        public virtual Persons Person { get; set; }
        public virtual Products Product { get; set; }
    }
}
