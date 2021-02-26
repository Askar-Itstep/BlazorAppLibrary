using BlazorAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class BooksRepository : Repository<Book>
    {
        public BooksRepository(myDBContext myDB): base(myDB)
        {

        }
    }
}
