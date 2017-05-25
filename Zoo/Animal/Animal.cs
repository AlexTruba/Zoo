using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public enum State
    {
        Full,
        Hungry,
        Sick,
        Dead
    }
    abstract class Animal
    {
        public State State { get { return _currentState; } }
        public int Health { get { return _health; } }
        public string Alias { get; }

        private int _animalHealth;
        protected int _health;
        private State _currentState;

        public Animal(string alias,int animalHealth)
        {
            Alias = alias;
            _currentState = State.Full;
            _animalHealth = animalHealth;
            _health = _animalHealth;
        }
        public void Heal()
        {
            if (_currentState == State.Dead)
            {
                Console.WriteLine("Животное: " + Alias + " умерло!");
            }
            else
            {
                if (Health < _animalHealth)
                {
                    _health++;
                    Console.WriteLine("Животное: " + Alias + " вылечено!");
                }
                else
                {
                    Console.WriteLine("Животное: " + Alias + " не нуждаеться в лечении!");
                }
            }
        }
        public void Feed()
        {
            if (_currentState == State.Dead)
            {
                Console.WriteLine("Животное: " + Alias + " умерло!");
            }
            else
            {
                if (_currentState == State.Hungry)
                {
                    _currentState = State.Full;
                    Console.WriteLine("Животное: " + Alias + " покормлено!");
                }
                else
                {
                    Console.WriteLine("Животное: " + Alias + " не нуждаеться в кормлении!");
                }
            }
        }
        public void changeState()
        {
            if (_currentState != State.Dead)
            {
                switch (_currentState)
                {
                    case State.Full:
                        _currentState = State.Hungry;
                        break;
                    case State.Hungry:
                        _currentState = State.Sick;
                        break;
                    case State.Sick:
                        _currentState = State.Full;
                        _health--;
                        if (Health == 0)
                        {
                            Console.WriteLine("Животное: " + Alias + " умерло!");
                            _currentState = State.Dead;
                        }
                        break;
                }
            }
           
        }
    }
}
