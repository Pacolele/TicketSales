using System;
using System.IO;
using System.Collections.Generic;


class Program
{
    List<Item> items = new List<Item>();
    const string path = @"..\..\..\Receipt.txt";

    public Program()
    {
        items.Add(new Item { Price = 100, type = "adult" });
        items.Add(new Item { Price = 25, type = "child" });
        items.Add(new Item { Price = 75, type = "senior" });
    }

    static void Main()
    {
        new Program().Run();
    }

    void Run()
    {


        Console.WriteLine("Hello welcome to this ticket booth here you can buy your tickets \nPlease enter 'help' for available commands\n\n");
        while (true)
        {
            Console.WriteLine("\nMenu\n>>>");
            string input = Console.ReadLine();
            if (input == "exit")
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
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Please enter 'help' for available commands");
                break;
        }
    }

    public void Buy()
    {
        //StreamWriter sw = new StreamWriter(path);
        //Select what type of tickets -> 

        0
        int sum = 0;
        Console.WriteLine("Select what type of ticket u want, adult, child or senior tickets.");
        string ticketType = Console.ReadLine();
        int number = 0;
        try
        {
            Console.WriteLine("Please enter how many tickets you would like.");
            number = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Try writing a number");
        }
        foreach(Item i in items)
        {
            if (ticketType.Equals(i.type))
            {
                sum += i.Price * number;
            }
        }
        Console.WriteLine($"Your total value is: {sum}$");




    }

    //public void AddChildTicket()
    //{
    //    try
    //    {
    //        Console.WriteLine("How many children tickets would u like?");
    //        int amountC = int.Parse(Console.ReadLine());
    //        int totalC = 25 * amountC;

    //    }
    //    catch
    //    {
    //        Console.WriteLine("\nTry entering a number, please");
    //    }
    //}
    //public void AddAdultTicket()
    //{
    //    try
    //    {
    //       Console.WriteLine("How many adult tickets would u like?");
    //       int amountA = int.Parse(Console.ReadLine());
    //        int totalvalue = 100 * amountA;
    //    }
    //    catch
    //    {
    //        Console.WriteLine("\nTry writing a number, please");
    //    }
    //}
    //public void AddSeniorTicket()
    //{
    //    try
    //    {
    //        Console.WriteLine("How many senior tickets would u like?");
    //        int amountS = int.Parse(Console.ReadLine());
    //        int totalvalue = 75 * amountS;
    //    }
    //    catch
    //    {
    //        Console.WriteLine("\nTry writing a number, please");
    //    }
    //}
    private void Help()
    {
        Console.WriteLine("\nbuy - buy tickets \n" +
            "temp - adad\n" +
            "temp - aaaa\n");
    }
}

