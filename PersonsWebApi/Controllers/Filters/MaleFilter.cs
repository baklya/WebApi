using PersonsWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonsWebApi.Controllers.Filters
{
    /// <summary>
    /// Select males only
    /// </summary>
    public class MaleFilter : IFilter
    {
        public IEnumerable<Person> Filter(IEnumerable<Person> collection)
        {
            return collection.Where(p => p.Gender == 1);
        }
    }
}