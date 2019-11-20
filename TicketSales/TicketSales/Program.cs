using System;
using System.Collections.Generic;
class Program
{
    private List<tickets> antColony = new List<tickets>();
    static void Main()
    {
        new Program().Run();
    }

    void Run()
    {
        Console.WriteLine("Hello welcome to this ticket booth here you can buy your tickets \nPlease enter 'help' for available commands\n\n");
        while (true)
        {
            Console.WriteLine("Please enter your command\n>>>");
            string input = Console.ReadLine();
            if(input == "exit")
            {
                break;
            }

            else
            {
                InputCentre(input);
            }
        }
       
    }

    void InputCentre(string input)
    {
        switch (input)
        {
            case "help":
                Help();
                break;

            case "buy":
                Buy();
                break;

            default:
                Console.WriteLine("Please enter 'help' for available commands");
                break;
        }
    }

    private void Buy()
    {
        
    }

    private void Help()
    {
        Console.WriteLine("\nbuy - buy a ticket or multiple tickets\n" +
            "temp - adad\n" +
            "temp - aaaa\n");
    }
}

