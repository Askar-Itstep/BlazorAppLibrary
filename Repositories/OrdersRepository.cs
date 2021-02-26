using BlazorAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public class OrdersRepository : Repository<OrderBook>
    {
        public OrdersRepository(myDBContext myDB): base(myDB)
        {
                
        }
    }
}
