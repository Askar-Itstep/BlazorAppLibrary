using BlazorAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class AuthorsRepository : Repository<Author>
    {
        public AuthorsRepository(myDBContext myDB):base(myDB)
        {

        }
    }
}
