using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo
{
    class AnimalFactory
    {
        public Animal GetInstance(string name,string alias)
        {
            Animal make = null;
            foreach (var item in Assembly.GetAssembly(typeof(Animal)).GetTypes().Where(t => t.IsSubclassOf(typeof(Animal))))
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    make = (Animal)Activator.CreateInstance(item,new object[] {alias});
                }
            }
            return make;
        }
    }
}
