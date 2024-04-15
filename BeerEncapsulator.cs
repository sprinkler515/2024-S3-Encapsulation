using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace _0413_S3_Encapsulation
{
    internal class BeerEncapsulator
    {
        private int _availableBottles = 0;
        private int _availableCapsules = 0;
        private double _availableBeerVolume = 0;

        public int SetAvailableBottles(int bottles) =>
            _availableBottles = bottles;

        public int SetAvailableCapsules(int capsules) =>
            _availableCapsules = capsules;

        public double AddBeer(double volume) =>
            _availableBeerVolume += Math.Abs(volume);

        public int MaxBeerBottles() =>
            (int)_availableBeerVolume / 33;

        public int ProduceEncapsulatedBeerBottles(int quantity)
        {
            int bottles = _availableBottles;
            int capsules = _availableCapsules;
            int encapsulatedBottles = Math.Min(bottles, capsules);

            if (encapsulatedBottles < quantity)
            {
                Console.WriteLine("Insufficent quantity of encapsulated empty bottles.");
                RequiredComponents("bottle", bottles, quantity);
                RequiredComponents("capsule", capsules, quantity);
                return 0;
            }
            if (MaxBeerBottles() < quantity)
            {
                Console.WriteLine($"Insufficient volume of beer ({quantity * 33 - _availableBeerVolume:N2}cl).");
                return 0;
            }
            return quantity;
        }

        public void DisplayComponents()
        {
            Console.WriteLine($"Bottles available: {_availableBottles}");
            Console.WriteLine($"Capsules available: {_availableCapsules}");
            Console.WriteLine($"Volume available: {_availableBeerVolume:N2}\n");
        }

        public double GetBeerVolume() => _availableBeerVolume;

        public static void RequiredComponents(string component, int quantityComponent, int quantityRequired)
        {
            int missingQuantity = quantityRequired - quantityComponent;

            if (missingQuantity > 0)
                Console.WriteLine($"Insufficient quantity of {missingQuantity} {component} components.");
        }
    }
}
