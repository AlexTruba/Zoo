using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.Animals;
namespace Zoo
{
    class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        private AnimalFactory _animalFactory = new AnimalFactory();
        private Timer timer;
        private Random random = new Random();
        //Function for search animal by alias(name)
        private Animal FindByAlias(string name) => animals.FirstOrDefault(t => t.Alias.ToLower() == name.ToLower());

        //Change state for random animal
        private void ChangeSomeAnimal(object j)
        {
            if (animals.Count != 0) {
                animals[random.Next(0, animals.Count - 1)].changeState(); }
            

        }
        //Function for start simulation zoo
        public void Start()
        {
            TimerCallback tc = new TimerCallback(ChangeSomeAnimal);
            timer = new Timer(tc,null,0, 5000);
            Console.WriteLine("Добро пожаловать в наш зоопарк!");
            Console.WriteLine("Список команд:");
            Console.WriteLine("Add Name Type - добавить новое животное. Пример Add Bobik Wolf");
            Console.WriteLine("Feed Name -  покормить животное. Пример Feed Bobik ");
            Console.WriteLine("Heal Name - вылечить новое животное. Пример Heal Bobik ");
            Console.WriteLine("Remove Name -  удалить животное из зоопарка. Пример Remove Bobik ");
            Console.WriteLine("0 - Показать всех животных, сгруппированных по виду животного");
            Console.WriteLine("1 State -  Показать животных по состоянию. Пример 1 hungry ");
            Console.WriteLine("2 - Показать всех тигров, которые больны");
            Console.WriteLine("3 Alias - Показать слона с определенной кличкой. Пример 3 Bob");
            Console.WriteLine("4 - Показать список всех кличек животных, которые голодны");
            Console.WriteLine("5 - Показать самых здоровых животных каждого вида");
            Console.WriteLine("6 - Показать количество мертвых животных каждого вида");
            Console.WriteLine("7 - Показать всех волков и медведей, у которых здоровье выше 3");
            Console.WriteLine("8 - Показать животное с максимальным здоровьем и животное с минимальным здоровьем ");
            Console.WriteLine("9 - Показать средней количество здоровья у животных в зоопарке");

            while (true)
            {
                
                Console.WriteLine("Введите команду:");
                string answer = Console.ReadLine();
                FindMethod(answer);
                if (animals.Count == animals.Where(t => t.State == State.Dead).ToList().Count && animals.Count != 0)
                {
                    Console.WriteLine("Зоопарк закритый!Все животные умерли!");
                }
            }
            
        }
        //Choose method for user action
        private void FindMethod(string answer)
        {
            var paramets = answer.Split(' ');
            //if user write 3 params then use method add animal
            int numberOfFunction;
            if (Int32.TryParse(paramets[0],out numberOfFunction))
            {
                ZooMethod.ChooseMethod(animals,numberOfFunction,paramets);            
            }
            if (paramets.Length==3)
            {
                if (paramets[0].ToLower()!="add")
                {
                    Console.WriteLine("Извините, но такого метода нету.Попробуйте ещё раз!");
                }
                else
                {
                    Animal make = _animalFactory.GetInstance(paramets[2],paramets[1]);
                    if (make!=null)
                    {
                        animals.Add(make);
                        Console.WriteLine("Животное "+ make.Alias+ " добавлено в зоопарк!");
                    }
                    else
                    {
                        Console.WriteLine("Извините, но такого типа животного нету.Попробуйте ещё раз!");
                    }
                }
            }
            //use another method with 2 params
            else if(paramets.Length == 2)
            {
                Animal someAnimal;
                switch (paramets[0].ToLower())
                {
                    case "feed":
                        someAnimal = FindByAlias(paramets[1]);

                        if (someAnimal != null) someAnimal.Feed();
                        else Console.WriteLine("Животного с таким именем нету в зоопарке!Попробуйте ввести другое имя.");

                        break;
                    case "heal":
                        someAnimal = FindByAlias(paramets[1]);

                        if (someAnimal != null) someAnimal.Heal();
                        else Console.WriteLine("Животного с таким именем нету в зоопарке!Попробуйте ввести другое имя.");

                        break;
                    case "remove":
                        someAnimal = FindByAlias(paramets[1]);

                        if (someAnimal != null)
                        {
                            if (someAnimal.State == State.Dead)
                            {
                                animals.Remove(someAnimal);
                                Console.WriteLine("Животное удалено из зоопарка");
                            }
                            else Console.WriteLine("Животное не умерло, его нельзя удалять!");
                        }
                        else Console.WriteLine("Животного с таким именем нету в зоопарке!Попробуйте ввести другое имя.");

                        break;
                    default:
                        Console.WriteLine("Метода с таким именем нету или указано недостаточное количество параметров!");
                        break;
                }
            }
            else
            {
                
                Console.WriteLine("Извините, но такого метода нету.Попробуйте ещё раз!");
            }
        }
       
    }
}
