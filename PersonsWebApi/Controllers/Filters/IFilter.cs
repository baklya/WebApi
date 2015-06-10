using PersonsWebApi.Models;
using System.Collections.Generic;

namespace PersonsWebApi.Controllers.Filters
{
    /// <summary>
    /// Interface for Persons Filter
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Filter function
        /// </summary>
        /// <param name="collection">input collection</param>
        /// <returns>filtered collection</returns>
        IEnumerable<Person> Filter(IEnumerable<Person> collection);
    }
}
