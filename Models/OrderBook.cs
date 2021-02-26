using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorAppLibrary.Models
{
    public partial class OrderBook
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? BooksId { get; set; }

        public virtual Book Books { get; set; }
        public virtual User Users { get; set; }
    }
}
