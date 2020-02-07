using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    #region GlobalInfo
    List<Item> items = new List<Item>();
    //List<Receipt> receipt = new List<Receipt>();
    const string receipt = @"..\..\..\Receipt.txt";
    const string information = @"..\..\..\Information.txt";
    int id = 0;
    int newSum = 0;
    int RefundSum = 0;
    #endregion
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
        UpdateRefunds();
        UpdateInfo();
        SaveInfo();
        UpdateID();
        Console.WriteLine("Hello welcome to this ticket booth here you can buy your tickets \nPlease enter 'help' for available commands\n\n");
        while (true)
        {
            Console.WriteLine("\nTicket booth\n>>>");
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
        string[] lines = File.ReadAllLines(receipt);
        id = lines.Length / 4;
    }

    private void UpdateInfo()
    {
        newSum = 0;
        string[] lines = File.ReadAllLines(receipt);
        if (lines.Length < 2)
            return;
        for (int i = 0; i < lines.Length; i+=5)
        {
            string[] substrings = lines[i].Split("%");
            if (substrings.Length == 2)
                continue;
            string money = lines[i+4];
            newSum += int.Parse(money.Substring(1));
        }

    }
    private void UpdateRefunds()
    {
        RefundSum = 0;
        string[] lines = File.ReadAllLines(receipt);
        if (lines.Length < 2)
            return;
        for (int i = 0; i < lines.Length; i += 5)
        {
            string[] substrings = lines[i].Split("%");
            if (substrings.Length == 1)
                continue;
            string money = lines[(i + 4)];
            RefundSum += int.Parse(money.Substring(1));
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
        Console.WriteLine("You want to refund? \n\n" + "Please enter your order Id to refund");
        string input = Console.ReadLine();
        string[] lines = File.ReadAllLines(receipt);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] strings = lines[i].Split("$");

            if (strings[0] == "ID" && strings[1] == input)
            {
                lines[i] += "%Refunded";
            }

        }
        File.WriteAllLines(receipt, lines);
        UpdateRefunds();
        SaveInfo();
    }

    public void Buy()
    {
        int sum = 0;
        int amountofItems = 0;
        StreamWriter sw = new StreamWriter(receipt, true);
        sw.WriteLine("ID$" + id);

        Console.WriteLine($"Your order ID is:{id}");

        foreach (Item i in items)
        {
            Console.WriteLine("\nhow many " + i.type + " tickets would you like?");
            amountofItems = CheckIfInt();
            sum += i.Price * amountofItems;
            sw.WriteLine(i.type + " $" + i.Price * amountofItems);

        }
        sw.WriteLine("$" + sum);
        sw.Close();
        Console.WriteLine($"Your total value is: {sum}$");

        id++;

        UpdateInfo();
        SaveInfo();
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
    private void Help()
    {
        Console.WriteLine("\nbuy - buy tickets \n" +
            "refund - refunds tickets\n" +
            "exit - get out of here\n");
    }

    void SaveInfo()
    {
        string[] strings = new string[2];
        strings[0] = "Total made money$" + newSum;
        strings[1] = "Refunded money$" + RefundSum;
        File.WriteAllLines(information, strings);
    }
}