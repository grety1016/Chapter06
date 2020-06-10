using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{

    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
             // Compare the Name lengths. . .
            int result = x.Name.Length.CompareTo(y.Name.Length) ;
            /// . . . if they are equal. . .
            if (result == 0)
            {
                // . . . then compare by the Names. . .
                 return x.Name.CompareTo(y.Name);
            }
            else
            {
                // . . . otherwise compare by the lengths.
                return result;
            }
        }

    }

    public class Person:IComparable<Person> 
    {
        //event delegate field
        public event  EventHandler Shout;
        // data field
        public int AngerLevel;
        //fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        //methods

      
       
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // if something is listening. . .
                if (Shout != null) //equate  Shout?. Invoke(this, EventArgs. Empty) ;
                {
                    // . . . then call the delegate
                    Shout(this,EventArgs.Empty) ;
                }
            }
        }

        public virtual void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public static Person Procreate(Person p1,Person p2)
        {
            var baby = new Person()
            {
                Name  = $"Baby of {p1.Name} and {p2.Name}."
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }
        
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this,partner);
        }

        //overload operator *
        public static Person operator * (Person p1,Person p2)
        {
            return Procreate(p1,p2);
        }

        // method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number) } cannot be less than zero. ") ;
            }
            return localFactorial(number) ;

            int localFactorial(int localNumber) // local function
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1) ;
            }
        }

        //dalegate  
        public int MethodIWantToCall(string input)
        {
            return input.Length; // it doesn' t matter what this does
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        //TimeEarlierBirthDate
        public void TimeTravel(DateTime when)
        {
            if(when  <  DateOfBirth)
            {
                 throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode! ");
            }
            else
            {
                WriteLine($"Wellcome to {when:yyyy}!");
            }
        }
    }
}
