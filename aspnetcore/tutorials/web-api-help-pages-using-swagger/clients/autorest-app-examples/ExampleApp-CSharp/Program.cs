using System;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramV1.SendAPIRequests(args);

            Console.WriteLine("<---------------------------->");

            ProgramV2.SendAPIRequests(args);
        }   
    }
}
