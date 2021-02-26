using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorAppLibrary;
using BlazorAppLibrary.Models;

namespace BlazorAppLibrary.Controllers
{
    [ApiController]
    [Route("/survey")]
    public class StatisticsController : ControllerBase
    {
        private readonly myDBContext _context;

        public StatisticsController(myDBContext context)
        {
            _context = context;
        }

       public void Post(int? num)        //Statistic statistic
        {
            if(num!= null)    //statistic!
            {
                Console.WriteLine("num: "+ num);    //($"out statisticController: {statistic.CountAuthorChoice}");
            }
        }

        private bool StatisticExists(int id)
        {
            return _context.Statistics.Any(e => e.Id == id);
        }
    }
}
