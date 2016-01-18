namespace _01.CakeTycoon
{
    using System;

    public static class Program
    {
        private const double Оvercharge = 1.25;


        public static void Main()
        {
            Console.WriteLine();

            ulong cakesWanted = ulong.Parse(Console.ReadLine());
            double flourPerCake = double.Parse(Console.ReadLine());
            uint flourAvailable = uint.Parse(Console.ReadLine());
            uint trufflesAvailable = uint.Parse(Console.ReadLine());
            uint truffleTotalPrice = uint.Parse(Console.ReadLine());

            uint cakesPossible = (uint)(flourAvailable / flourPerCake);

            if (cakesPossible >= cakesWanted)
            {
                double trufflePrice = (double)truffleTotalPrice * trufflesAvailable;

                double cakePrice = trufflePrice / cakesWanted * Оvercharge;

                Console.WriteLine($"All products available, price of a cake: {cakePrice:F2}");
            }
            else
            {
                double flourRequired = cakesWanted * flourPerCake;

                double flourNeeded = flourRequired - flourAvailable;

                Console.WriteLine($"Can make only {cakesPossible} cakes, need {flourNeeded:F2} kg more flour");
            }
        }
    }
}
