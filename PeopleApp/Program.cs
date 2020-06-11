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
            Array.Sort(people);
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

            //object example
            var t1 = new Thing();
            t1.Data = 42 ;
            WriteLine(t1.Process(42)); 

            var t2 = new Thing();
            t2.Data = "Apple" ;
            WriteLine(t2.Process("Apple")); 

            //generic types
            var gt1 = new GenericThing<int>() ;
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer:{gt1.Process(42) }") ;
            var gt2 = new GenericThing<string>() ;
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string:{gt2.Process("apple") }") ;


            //generic method
            string number1 = "4";
            WriteLine("{0} squared is {1}",
            arg0: number1,
            arg1: Squarer.Square<string>(number1));
            byte number2 = 3;
            WriteLine("{0} squared is {1}",
            arg0: number2,
            arg1: Squarer.Square<int>(number2));


            //with struct 
            var vec1 = new DisplacementVector(-2,5);
            var vec2 = new DisplacementVector(3,7);
            var vec3 = vec1 + vec2;
            WriteLine($"({vec1.X}, {vec1.Y}) + ({vec2.X}, {vec2.Y}) =({vec3.X}, {vec3.Y}) ") ;
           
           
            //inheriting class
            Person john2 = new Employee()
            {
                Name = "john jones2",
                DateOfBirth = new DateTime(1997-10-16)
            };
            Employee john = new Employee
            {
                Name = "john jones",
                DateOfBirth = new DateTime(1997-10-16),
                EmployeeCode = "123456"
                
            };
            
             

            Employee aliceInEmployee = new Employee
            { Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee. WriteToConsole() ;
            aliceInPerson. WriteToConsole() ;
            WriteLine(aliceInEmployee.ToString() ) ;
            WriteLine(aliceInPerson.ToString() ) ;

            
            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson) } IS an Employee") ;
                Employee explicitAlice = (Employee) aliceInPerson;
                // safely do something with explicitAlice
            }
            Person e1 = new Person();

            e1.DateOfBirth = new DateTime(1970,05,04); 
            
            try
            {
                e1.TimeTravel(new DateTime(1999, 12, 31) ) ;
                e1.TimeTravel(new DateTime(1950, 12, 25) ) ;
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message) ;
            }

            //validate email
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine("{0} is a valid e-mail address: {1}",
            arg0: email1,
            arg1: StringExtensions.IsValidEmail(email1) ) ;
            WriteLine("{0} is a valid e-mail address: {1}",
            arg0: email2,
            arg1: StringExtensions.IsValidEmail(email2) ) ;

            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email1,
            arg1: email1.IsValidEmail() ) ;
            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email2,
            arg1: email2.IsValidEmail() ) ;

            email1.Insert(email1,2,"");
             

        }
    }
}
