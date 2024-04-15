using System.Globalization;

namespace _0413_S3_Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity, beerProduced;
            CultureInfo culture = new("en-US");
            BeerEncapsulator beerEncapsulator = new();

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            SetComponents(beerEncapsulator);
            PromptAddBeer(beerEncapsulator);
            beerEncapsulator.DisplayComponents();

            Console.Write("How many bottles of beers do you want to make: ");
            quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            beerProduced = beerEncapsulator.ProduceEncapsulatedBeerBottles(quantity);

            if (beerProduced == 0)
                Console.WriteLine("No beer bottles were produced.");
            else
                Console.WriteLine($"Success! Bottle of beer produced: {beerProduced}");
        }

        static int ValidPositiveInt(int entry)
        {
            while (entry <= 0)
            {
                Console.Write("Invalid value. Please enter a positive number: ");
                entry = Convert.ToInt32(Console.ReadLine());
            }
            return entry;
        }

        static double ValidPositiveDouble(double entry)
        {
            while (entry < 33)
            {
                Console.Write("Invalid value. Please enter a positive number: ");
                entry = Convert.ToDouble(Console.ReadLine());
            }
            return entry;
        }

        static void PromptAddBeer(BeerEncapsulator beerEncapsulator)
        {
            string answer;
            bool answered = false;

            while (!answered)
            {
                Console.Write("Do you want to add additional beer? (y/n) ");
                answer = Console.ReadLine() ?? "";
                if (answer == "y")
                {
                    Console.Write("\nAdd additional beer: ");
                    beerEncapsulator.AddBeer(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine($"New volume available: {beerEncapsulator.GetBeerVolume():N2}\n");
                }
                else if (answer == "n") answered = true;
                else Console.WriteLine("Unknown command. Try again.\n");
            }
            Console.WriteLine();
        }

        static void SetComponents(BeerEncapsulator beerEncapsulator)
        {
            int bottles, capsules;
            double beerVolume;

            Console.Write("Bottles available (min: 1): ");
            bottles = Convert.ToInt32(Console.ReadLine());
            bottles = ValidPositiveInt(bottles);

            Console.Write("Capsules available (min: 1): ");
            capsules = Convert.ToInt32(Console.ReadLine());
            capsules = ValidPositiveInt(capsules);

            Console.Write("Volume of beer available (min: 33): ");
            beerVolume = Convert.ToDouble(Console.ReadLine());
            beerVolume = ValidPositiveDouble(beerVolume);
            Console.WriteLine();
            beerEncapsulator.SetAvailableBottles(bottles);
            beerEncapsulator.SetAvailableCapsules(capsules);
            beerEncapsulator.AddBeer(beerVolume);
        }
    }
}
