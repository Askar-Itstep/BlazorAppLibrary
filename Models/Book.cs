using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorAppLibrary.Models
{
    public partial class Book
    {
        public Book()
        {
            OrderBooks = new HashSet<OrderBook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public int? AuthorsId { get; set; }
        public int? Pages { get; set; }
        public int? GenresId { get; set; }
        public int? ImagesId { get; set; }

        public virtual Author Authors { get; set; }
        public virtual Genre Genres { get; set; }
        public virtual Image Images { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
