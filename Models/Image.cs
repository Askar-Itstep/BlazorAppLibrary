using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorAppLibrary.Models
{
    public partial class Image
    {
        public Image()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
