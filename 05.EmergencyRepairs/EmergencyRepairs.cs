namespace _05.EmergencyRepairs
{
    using System;

    public static class EmergencyRepairs
    {
        public static void Main()
        {
            var wall = ulong.Parse(Console.ReadLine());
            var emergencyKits = int.Parse(Console.ReadLine());
            var numberOfAttacks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAttacks; i++)
            {
                var attackedBrick = int.Parse(Console.ReadLine());
                wall &= ~(1ul << attackedBrick);
            }

            for (int step = 0; step < 64; step++)
            {
                if (emergencyKits <= 0)
                {
                    break;
                }

                var currentBrick = wall >> step & 1ul;
                var nextBrick = wall >> (step + 1) & 1ul;

                if (currentBrick == 0 && nextBrick == 0)
                {
                    while (step < 64 &&
                        emergencyKits > 0 &&
                        (wall >> step & 1ul) == 0)
                    {
                        wall |= 1ul << step;
                        emergencyKits--;
                        step++;
                    }
                }
            }

            Console.WriteLine(wall);
        }
    }
}
