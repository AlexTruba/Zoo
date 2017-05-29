using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo
{
     static class ZooExtension
    {
        public static IEnumerable<IGrouping<string,Animal>> GroupByAnimalType(this IEnumerable<Animal> list)
        {
            return list.GroupBy(t => t.GetType().Name);
        }
        public static IEnumerable<Animal> SelectByState(this IEnumerable<Animal> list,State state)
        {
            return list.Where(t => t.State == state);
        }
        public static IEnumerable<Animal> SickTiger(this IEnumerable<Animal> list)
        {
            return list.Where(t => t.State ==   State.Sick && t.GetType().Name.ToLower()=="tiger");
        }
        public static IEnumerable<Animal> ElephantByAlias(this IEnumerable<Animal> list,string alias)
        {
            return list.Where(t => t.Alias.ToLower()==alias.ToLower() && t.GetType().Name.ToLower() == "elephant");
        }
        public static IEnumerable<string> HungryAnimalsAlias(this IEnumerable<Animal> list)
        {
            return list.Where(t => t.State ==State.Hungry).Select(t=>t.Alias);
        }
        public static Dictionary<string, Animal> HealthiestAnimalsByType(this IEnumerable<Animal> list)
        {
            return list
                .GroupBy(t => t.GetType().Name)
                .Select(t => new { type = t.Key, animal = t.OrderByDescending(l=>l.Health).FirstOrDefault()})
                .ToDictionary(t => t.type, t => t.animal);
        }
        public static Dictionary<string, int> DeadAnimalsByType(this IEnumerable<Animal> list)
        { 
            return list
            .Where(t => t.State == State.Dead)
            .GroupBy(t => t.GetType().Name)
            .Select(t => new { type = t.Key, count = t.Count() })
            .ToDictionary(t => t.type, t => t.count);
           
        }
        public static IEnumerable<Animal> WolfsAndBearsWithHealth(this IEnumerable<Animal> list)
        {
            return list.Where(t => (t.GetType().Name.ToLower() == "wolf" || t.GetType().Name.ToLower() == "bear") && t.Health>=3);
        }
        public static IEnumerable<Animal> MinAndMaxHealth(this IEnumerable<Animal> list)
        {
            return list.Where(l => l.Health == list.Max(k => k.Health) || l.Health == list.Min(k => k.Health)).Distinct().OrderBy(t=>t.Health);
        }
        public static double AverageHealth(this IEnumerable<Animal> list)
        {
            return list.Average(t => t.Health);
        }
    }
}
