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
            case "refund":
                Refund();
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Please enter 'help' for available commands");
                break;
        }
    }

    private void Refund()
    {

    }

    public void Buy()
    {
        //StreamWriter sw = new StreamWriter(path);
        //Select what type of tickets -> 
        /*
        int id = 0;

        for(id = 0; id > items.Count; id++)
        {

        }
        */
        int id = 0;
        int sum = 0;
        int[] numbers = new int[items.Count];

        while (true)
        {

            Console.WriteLine("\nSelect what type of ticket u want, adult, child or senior tickets.\nType 'done' if ur happy with your order.");
            string ticketType = Console.ReadLine();

            try
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (ticketType.Equals(items[i].type))
                    {
                        Console.WriteLine("\nPlease enter how many tickets you would like.");
                        numbers[i] = int.Parse(Console.ReadLine());
                        sum += items[i].Price * numbers[i];
                    }
                    
                }
            }
            catch
            {
                Console.WriteLine("\nTry writing a number");
            }
            Console.WriteLine($"Your total value is: {sum}$");
            Console.WriteLine("Are you happy with your order Y/N");
            if (Console.ReadLine().ToUpper() == "Y" )
            {
                Console.WriteLine($"Your order ID:{id}");
                id++;
                break;
            } 
            
                
        }




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
            "refund - refunds tickets\n" +
            "exit - get out of here\n");
    }
}

