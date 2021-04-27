using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? Price { get; set; }
        public int? Writer { get; set; }

        public virtual Writer WriterNavigation { get; set; }
    }
}
