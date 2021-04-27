using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Core.DTOs
{
    public class DtoBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int Writer { get; set; }
        public string WriterName { get; set; }
    }
}
