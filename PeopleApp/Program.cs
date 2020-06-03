using System;

namespace Packt.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            var sam = new Person(){Name = "Sam",DateOfBirth = new DateTime(1992,10,16)};
            sam.WriteToConsole();
            
        }
    }
}
