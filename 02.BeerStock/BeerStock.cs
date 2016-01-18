namespace _02.BeerStock
{
    using System;

    public static class BeerStock
    {
        private const int SixpackCount = 6;
        private const int CaseCount = 24;
        private const int BrokenBeerNumber = 100;

        public static void Main()
        {
            var reservedBeers = long.Parse(Console.ReadLine());
            var totalBeers = 0L;

            var command = Console.ReadLine();
            while (command != "Exam Over")
            {
                var deliveryDetails = command.Split();
                var packCount = long.Parse(deliveryDetails[0]);
                var packType = deliveryDetails[1];

                totalBeers = DeliveryToBeers(packType, totalBeers, packCount);
                command = Console.ReadLine();
            }

            var brokenBeers = totalBeers / BrokenBeerNumber;
            totalBeers -= brokenBeers;

            var bersDiff = Math.Abs(totalBeers - reservedBeers);

            var cases = bersDiff / CaseCount;
            bersDiff -= CaseCount * cases;

            var sixPacks = bersDiff / SixpackCount;
            bersDiff -= SixpackCount * sixPacks;

            if (totalBeers >= reservedBeers)
            {
                Console.WriteLine(
                    $"Cheers! Beer left: {cases} cases, {sixPacks} sixpacks and {bersDiff} beers.");
            }
            else
            {
                Console.WriteLine($"Not enough beer. Beer needed: {cases} cases, {sixPacks} sixpacks and {bersDiff} beers.");
            }
        }

        private static long DeliveryToBeers(string packType, long totalBeers, long packCount)
        {
            switch (packType)
            {
                case "beers":
                    totalBeers += packCount;
                    break;
                case "cases":
                    totalBeers += packCount * CaseCount;
                    break;
                case "sixpacks":
                    totalBeers += packCount * SixpackCount;
                    break;
                default:
                    throw new ArgumentException("No such beer type");
            }

            return totalBeers;
        }
    }
}
