using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PersonsWebApi.Models;
using PersonsWebApi.Controllers.Filters;
using System;
using System.Text;

namespace PersonsWebApi.Controllers
{
    /// <summary>
    /// Controller for Persons web api
    /// </summary>
    public class DataController : ApiController
    {
        /// <summary>
        /// db context
        /// </summary>
        private PersonContext db = new PersonContext();

        /// <summary>
        /// Some filter
        /// </summary>
        private readonly IFilter _filter;
        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="f">some filter</param>
        public DataController(IFilter f)
        {
            _filter = f;
        }

        /// <summary>
        /// GET api/data/person
        /// </summary>
        /// <returns>List of Persons</returns>
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return db.Persons.AsEnumerable();
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Get random string
        /// </summary>
        /// <param name="size">size</param>
        /// <returns>random string</returns>
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }



        /// <summary>
        /// PUT api/data/person/random
        /// </summary>
        /// <returns>New Person description</returns>
        [HttpPut]
        public string PutRandomPerson()
        {
            var pNameSize = Convert.ToInt32(Math.Floor(20 * random.NextDouble() + 8));

            var pName = RandomString(pNameSize).ToLower();
            pName = pName.First().ToString().ToUpper() + pName.Substring(1);
            
            var pAge = Convert.ToInt32(Math.Floor(54 * random.NextDouble() + 8));

            var pGender = random.Next(0, 2);

            db.Persons.Add(new Person() { Name = pName, Age = pAge, Gender = pGender });
            db.SaveChanges();

            return String.Format("{0} {1} {2}",
                pName, pGender == 0 ? "female" : "male", pAge);
          
        }

        /// <summary>
        /// GET api/data/person/filter
        /// </summary>
        /// <returns>Filtered list of Persons</returns>
        [HttpGet]
        public IEnumerable<Person> Filter()
        {
            return _filter.Filter(db.Persons);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}