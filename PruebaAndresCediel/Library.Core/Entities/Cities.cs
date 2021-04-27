using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public partial class Cities
    {
        public Cities()
        {
            Writer = new HashSet<Writer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Country { get; set; }

        public virtual Country CountryNavigation { get; set; }
        public virtual ICollection<Writer> Writer { get; set; }
    }
}
