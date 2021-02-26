using BlazorAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class StatisticRepository : Repository<Statistic>
    {
        public StatisticRepository(myDBContext myDB): base(myDB)
        {

        }
    }
}
