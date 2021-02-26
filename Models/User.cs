using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorAppLibrary.Models
{
    public partial class User
    {
        public User()
        {
            OrderBooks = new HashSet<OrderBook>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
