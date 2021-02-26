using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorAppLibrary.Models
{
    public partial class Statistic
    {
        public int Id { get; set; }
        public int CountAuthorChoice { get; set; } = 0;
        public int CountTitleChoice { get; set; } = 0;
        public int CountGenreChoice { get; set; } = 0;
        public int CountIsImageChoice { get; set; } = 0;
    }
}
