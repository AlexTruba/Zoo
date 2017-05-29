using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    static class ZooMethod
    {
        public static void ChooseMethod(List<Animal> list,int number,string[] param)
        {
            switch (number)
            {
                case 0:
                    try
                    {
                        foreach (var item in list.GroupByAnimalType())
                        {
                            Console.WriteLine(item.Key);
                            foreach (var t in item)
                            {
                                Console.WriteLine("\t" + t.Alias);
                            }
                            Console.WriteLine("--------------");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 1:
                    try
                    {
                        State state;
                        if (Enum.TryParse(param[1],out state))
                        {
                            foreach (var t in list.SelectByState(state))
                            {
                                Console.WriteLine(t.Alias);
                            }
                        }
                        else Console.WriteLine("Такого состояния нету!");


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 2:
                    try
                    {
                        foreach (var t in list.SickTiger())
                        {
                            Console.WriteLine(t.Alias);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 3:
                    try
                    {
                        foreach (var t in list.ElephantByAlias(param[1]))
                        {
                            Console.WriteLine(t.Alias);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 4:
                    try
                    {
                        foreach (var t in list.HungryAnimalsAlias())
                        {
                            Console.WriteLine(t);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 5:
                    try
                    {
                        foreach (var item in list.HealthiestAnimalsByType())
                        {
                            Console.WriteLine("Animal type - "+ item.Key+", Health - " + item.Value);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 6:
                    try
                    {
                        foreach (var item in list.DeadAnimalsByType())
                        {
                            Console.WriteLine("Animal type - " + item.Key + ", Count - " + item.Value);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 7:
                    try
                    {
                        foreach (var t in list.WolfsAndBearsWithHealth())
                        {
                            Console.WriteLine("Animal type - " + t.GetType().Name + ", Health - " + t.Health);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 8:
                    try
                    {
                        var a = list.MinAndMaxHealth();
                        Console.WriteLine("Min Health Animal alias: "+ a.ElementAt(0).Alias);
                        Console.WriteLine("Max Health Animal alias: " + a.ElementAt(1).Alias);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                case 9:
                    try
                    {
                        Console.WriteLine("Average health in zoo: "+list.AverageHealth());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла неизвестная проблема!Возможно животных похитили инопланетяне");
                    }
                    break;
                default:
                    Console.WriteLine("Метода с таким номером нету!");
                    break;
            }
        }
    }
}
