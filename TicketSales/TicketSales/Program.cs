using System;
using System.IO;
using System.Collections.Generic;


class Program
{
    List<Item> items = new List<Item>();
    //List<Receipt> receipt = new List<Receipt>();
    const string path = @"..\..\..\Receipt.txt";
    int id = 0;

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
        UpdateID();
        Console.WriteLine("Hello welcome to this ticket booth here you can buy your tickets \nPlease enter 'help' for available commands\n\n");
        while (true)
        {
            Console.WriteLine("\nBooth\n>>>");
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

    private void UpdateID()
    {
        string[] lines = File.ReadAllLines(path);
        id = lines.Length / 4;
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
        Console.WriteLine("You want to refund? \n\n" + "Please enter your order Id to refund");
        string input = Console.ReadLine();
        string[] lines = File.ReadAllLines(path);
        for(int i = 0; i < lines.Length; i++)
        {
            string[] strings = lines[i].Split("$");

            if (strings[0] == "ID" && strings[1] == input)
            {
                lines[i] += "$Refunded";
            }

        }
        File.WriteAllLines(path, lines);
    }

    public void Buy()
    {
        int sum = 0;
        int amountofItems = 0;
        StreamWriter sw = new StreamWriter(path, true);
        sw.WriteLine("ID$" + id);
        Console.WriteLine($"Your order ID:{id}");
        
        foreach (Item i in items)
        {
            Console.WriteLine("how many " + i.type + " tickets would you like?");
            amountofItems = CheckIfInt();
            sum += i.Price * amountofItems;
            sw.WriteLine(i.type + " $" + i.Price * amountofItems);
            
        }
        sw.WriteLine("$" + sum);
        sw.Close();
        Console.WriteLine($"Your total value is: {sum}$");

        id++;
    }

    int CheckIfInt()
    {
        while (true)
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("try entering a number");
            }
        }
    }


    // Problem

    /*
        Console.WriteLine("Are you happy with your order Y/N");
        if (Console.ReadLine().ToUpper() == "Y" )
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Item i in items)
                    sw.WriteLine(i.type + " $" + i.Price * boughtAmount);
            }
            break;
        } */


    /*
               for (int i = 0; i < items.Count; i++)
               {
                   if (ticketType.Equals(items[i].type))
                   {
                       Console.WriteLine("\nPlease enter how many tickets you would like.");
                       boughtAmount = int.Parse(Console.ReadLine());

                       sum += items[i].Price * boughtAmount;
                   }

               }*/

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

