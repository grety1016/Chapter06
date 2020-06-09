using System;
using Packt.Shared;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    
    class Program
    {   //delegate definition
         delegate int DelegateWithMatchingSignature(string s);   

         private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.") ;
        }   
        
             
        static void Main(string[] args)
        {
            var harry = new Person { Name = "Harry"};
            var mary = new Person { Name = "Mary"};
            var jill = new Person { Name = "Jill"};
            // call instance method
            var baby1 = mary.ProcreateWith(harry);
            // call static method
            var baby2 = Person.Procreate(harry, jill);
            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine(format: "{0}'s first child is named \"{1}\". ",arg0: harry.Name,arg1: harry.Children[0].Name);


            //concatenating string
            string s1 = "Hello,";
            string s2 = "World!";
            string s3 = string.Concat(s1,s2);
            WriteLine(s3);


            //call overload  operator * method
            var baby3 = harry * mary;
            WriteLine(baby3.Name);

            //Factorial caculations
            var Factorial1 = new Person();            
            WriteLine(Person.Factorial(10));

            //call WantToMethod 
            Person p1 = new Person();
            int answer = p1.MethodIWantToCall("Frog");           

            // create a delegate instance that points to the method
            var d = new DelegateWithMatchingSignature(p1.MethodIWantToCall) ;
            // call the delegate, which calls the method
            int answer2 = d("Frog"); 
            WriteLine(answer.ToString());
            
            harry.Shout += Harry_Shout;
            harry. Poke();
            harry. Poke();
            harry. Poke();
            harry. Poke();


            //IComparable
            Person[] people = 
            {           
                new Person{Name = "Adam"},
                new Person{Name = "Richard"},
                new Person{Name = "Jenny"},
                new Person{Name = "Simon"}
            };

            WriteLine("Inital list of people array:");

            foreach(var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine("Use Person' s IComparable implementation to sort:");
            Array.Sort(people);

            foreach(var person in people)
            {
                WriteLine($"{person.Name}");
            }


            WriteLine("Use PersonComparer' s IComparer implementation to sort: ") ;
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}") ;
            }

            DvdPlayer player1 = new DvdPlayer();
            IPlayable player2 = new DvdPlayer();
            BasePlayer player3 = new DvdPlayer();
            player1.stop();
            player2.Stop();
            player3.StopPlay();
                                    
        }
    }
}
