using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<Cities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
