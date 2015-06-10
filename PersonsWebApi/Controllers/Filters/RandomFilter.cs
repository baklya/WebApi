using PersonsWebApi.Models;
using System;
using System.Collections.Generic;

namespace PersonsWebApi.Controllers.Filters
{
    /// <summary>
    /// Random selection
    /// </summary>
    public class RandomFilter : IFilter
    {
        public IEnumerable<Person> Filter(IEnumerable<Person> collection)
        {
            Random rnd = new Random();
            var res = new List<Person>();

            foreach (var p in collection)
            {
                if(rnd.NextDouble() >= 0.5)
                {
                    res.Add(p);
                }
            }

            return res;
        }
    }
}