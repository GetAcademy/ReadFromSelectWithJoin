using System.Text.Json;
using ReadFromSelectWithJoin.DTOs;

namespace ReadFromSelectWithJoin
{
    internal class GroupDemo
    {
        public static void Run()
        {
            var people = new[]
            {
                new Person { Name = "Ada", City = "Oslo" },
                new Person { Name = "Bertil", City = "Oslo" },
                new Person { Name = "Cecilie", City = "Larvik" },
            };

            var groups = people
                .GroupBy(p => p.City)
                .Select(group => new City
                {
                    Name = group.Key,
                    People = group.ToList()
                });
            foreach (var group in groups)
            {
                Console.WriteLine("Gruppe: " + group.Name);
                foreach (var person in group.People)
                {
                    Console.WriteLine("  " + person.Name);
                }
            }
        }
    }
}
