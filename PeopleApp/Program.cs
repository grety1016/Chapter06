using System;
using Packt.Shared;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    delegate int DelegateWithMatchingSignature(string s) ; 
    class Program
    {       
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

                        
        }
    }
}
