using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Models
{
    public class StatisticViewModel
    {
        public string MaxPop { get; set; }
        public string MinPop { get; set; }

        public static int FullCountAuthorChoice { get; set; } = 0;
        public static int FullCountTitleChoice { get; set; } = 0;
        public static int FullCountGenreChoice { get; set; } = 0;
        public static int FullCountImageChoice { get; set; } = 0;

        public int[] viewStatistics; 
        public enum Choice { Author = 0, Genre, Image, Title };

        public void GetMaxMin()
        {
            viewStatistics = new int[] { FullCountAuthorChoice, FullCountGenreChoice, FullCountImageChoice, FullCountTitleChoice };
            int maxInt = viewStatistics.Max();
            int minInt = viewStatistics.Min();

            int[] indexisMax = { }, indexisMin = { };
            for (int i = 0; i < viewStatistics.Length; i++)
            {
                if (viewStatistics[i] == maxInt)   
                {
                    indexisMax= indexisMax.Append(i).ToArray();
                }
                else if (viewStatistics[i] == minInt)
                {
                    indexisMin= indexisMin.Append(i).ToArray();
                }
            }
            MaxPop = ((Choice)indexisMax.FirstOrDefault()).ToString();
            MinPop = ((Choice)indexisMin.FirstOrDefault()).ToString();

        }

    }
}
