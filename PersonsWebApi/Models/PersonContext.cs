using System.Data.Entity;

namespace PersonsWebApi.Models
{
    /// <summary>
    /// Db context for Persons
    /// </summary>
    public class PersonContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }

}