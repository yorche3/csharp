// See https://aka.ms/new-console-template for more information
using System;

namespace HelloUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}!");
        }
    }
}
