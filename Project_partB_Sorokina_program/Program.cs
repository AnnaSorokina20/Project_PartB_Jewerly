using Project_partB_Sorokina_program;
using System;
using static System.Formats.Asn1.AsnWriter;
class Program
{
    static void Main(string[] args)
    {
        Necklace necklace = new Necklace();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n*** Gemstone Necklace Management ***");
            Console.WriteLine("1. Add a Gemstone");
            Console.WriteLine("2. Remove a Gemstone");
            Console.WriteLine("3. Display Necklace Details");
            Console.WriteLine("4. Sort Stones by Value");
            Console.WriteLine("5. Find Stones by Color");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter gemstone type (1 for Precious, 2 for SemiPrecious): ");
                    int stoneType = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter gemstone name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter gemstone weight (in carats): ");
                    double weight = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter gemstone price: ");
                    decimal price = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter gemstone color: ");
                    string color = Console.ReadLine();

                    if (stoneType == 1)
                    {
                        Console.Write("Enter gemstone clarity (1-10): ");
                        int clarity = Convert.ToInt32(Console.ReadLine());
                        AddGemstone(necklace, stoneType, name, weight, price, color, clarity);
                    }
                    else if (stoneType == 2)
                    {
                        Console.Write("Enter gemstone hardness (1-10): ");
                        int hardness = Convert.ToInt32(Console.ReadLine());
                        AddGemstone(necklace, stoneType, name, weight, price, color, hardness);
                    }
                    else
                    {
                        Console.WriteLine("Invalid gemstone type.");
                    }
                    break;
                case 2:
                    Console.Write("Enter the name of the gemstone to remove: ");
                    string nameToRemove = Console.ReadLine();

                    bool isRemoved = RemoveGemstone(necklace, nameToRemove);
                    if (isRemoved)
                    {
                        Console.WriteLine($"Gemstone '{nameToRemove}' was removed from the necklace.");
                    }
                    else
                    {
                        Console.WriteLine($"Gemstone '{nameToRemove}' not found in the necklace.");
                    }
                    break;
                case 3:
                    Console.WriteLine(necklace.ToString());
                    break;
                case 4:
                    necklace.SortByValue();
                    Console.WriteLine("Necklace sorted by value.");
                    break;
                case 5:
                    Console.Write("Enter the color of gemstones to find: ");
                    string colorToFind = Console.ReadLine();

                    var foundStones = FindStonesByColor(necklace, colorToFind);
                    if (foundStones.Any())
                    {
                        Console.WriteLine($"Found the following gemstones with color {colorToFind}:");
                        foreach (var stone in foundStones)
                        {
                            Console.WriteLine(stone.GetDetails());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No gemstones found with color {colorToFind}.");
                    }
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }


    private static void AddGemstone(Necklace necklace, int stoneType, string name, double weight, decimal price, string color, int additionalProperty)
    {
        if (stoneType == 1)
        {
            PreciousStone preciousStone = new PreciousStone(name, weight, price, color, additionalProperty);
            necklace.AddStone(preciousStone);
        }
        else if (stoneType == 2)
        {
            SemiPreciousStone semiPreciousStone = new SemiPreciousStone(name, weight, price, color, additionalProperty);
            necklace.AddStone(semiPreciousStone);
        }
    }


    private static bool RemoveGemstone(Necklace necklace, string name)
    {
        IGemstone stoneToRemove = necklace.GetStones().FirstOrDefault(stone => stone.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));

        if (stoneToRemove != null)
        {
            necklace.RemoveStone(stoneToRemove);
            return true;
        }
        else
        {
            return false;
        }
    }


    private static List<IGemstone> FindStonesByColor(Necklace necklace, string color)
    {
        return necklace.FindStonesByColor(color);
    }

}
