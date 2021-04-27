using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public partial class Writer
    {
        public Writer()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public int City { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }

        public virtual Cities CityNavigation { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
