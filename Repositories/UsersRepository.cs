using BlazorAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class UsersRepository : Repository<User>
    {
        public UsersRepository(myDBContext myDB): base(myDB)
        {

        }
    }
}
