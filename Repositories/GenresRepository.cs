using BlazorAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class GenresRepository : Repository<Genre>
    {
        public GenresRepository(myDBContext myDB): base(myDB)
        {
                
        }
    }
}
