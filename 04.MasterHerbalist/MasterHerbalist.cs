namespace _04.MasterHerbalist
{
    using System;

    public static class MasterHerbalist
    {
        public static void Main()
        {
            var dailyExpenses = int.Parse(Console.ReadLine());
            var daysPassed = 0;
            var totalIncome = 0;

            var command = Console.ReadLine();
            while (command != "Season Over")
            {
                var commandArgs = command.Split();

                var hoursAvail = int.Parse(commandArgs[0]);
                var path = commandArgs[1];
                var herbPrice = int.Parse(commandArgs[2]);

                var herbsCollected = 0;

                for (int hour = 0; hour < hoursAvail; hour++)
                {
                    if (char.ToLower(path[hour % path.Length]) == 'h')
                    {
                        herbsCollected++;
                    }
                }

                totalIncome += herbsCollected * herbPrice;

                daysPassed++;

                command = Console.ReadLine();
            }

            var dailyTotalIncome = (double)totalIncome / daysPassed;

            if (dailyTotalIncome >= dailyExpenses)
            {
                var moneyRemaining = dailyTotalIncome - dailyExpenses;

                Console.WriteLine($"Times are good. Extra money per day: {moneyRemaining:F2}.");
            }
            else
            {
                var moneyNeeded = (int)((dailyExpenses - dailyTotalIncome) * daysPassed);

                Console.WriteLine($"We are in the red. Money needed: {moneyNeeded}.");
            }
        }
    }
}
