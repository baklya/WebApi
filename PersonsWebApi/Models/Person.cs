namespace PersonsWebApi.Models
{
    /// <summary>
    /// Person entity
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
    }
}