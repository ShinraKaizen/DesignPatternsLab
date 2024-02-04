using System;
using System.Net.NetworkInformation;
using DesignPatternsLibrary.Singleton;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while(!exit)
        {
            Console.WriteLine("Select a design pattern to demonstrate:");
            Console.WriteLine("1. Singleton Pattern");
            Console.WriteLine("e - Exit");
            
            string choice = Console.ReadLine(); 

            switch(choice)
            {
                case "1":
                    DemonstrateSingleton();
                    break;
                case "2":
                    Console.WriteLine("Not implemented yet");
                    break;
                case "e":
                    exit = true;
                    break;
                default:
                    Console.WriteLine($"{choice} is not a valid option. Please try again.");
                    break;            
            }
        }
    }

    static void DemonstrateSingleton()
    {
        ConfigurationManager configManager1 = ConfigurationManager.GetInstance();
        ConfigurationManager configManager2 = ConfigurationManager.GetInstance();

        if(configManager1 == configManager2)
        {
            Console.WriteLine("Singleton works! Both variables contain the same instance.");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances");
            Console.WriteLine("");
        }
    }
}