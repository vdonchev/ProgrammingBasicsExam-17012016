namespace _03.IlluminatiLock
{
    using System;

    public static class IlluminatiLock
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var height = size - 1;
            var eye = '#';
            var background = '.';

            var firstLastLine = string.Format("{0}{1}{0}", new string(background, size), new string(eye, size));
            var middleLine = string.Format("{{0}}{0}{0}{{1}}{0}{{2}}{0}{{1}}{0}{0}{{0}}", eye);

            var outter = size - 2;
            var inner = 0;
            var middle = size - 2;

            Console.WriteLine(firstLastLine);
            for (int row = 1; row <= height; row++)
            {
                if (row <= height / 2)
                {
                    LineFormat(middleLine, background, outter, inner, middle);
                    outter -= 2;
                    inner += 2;
                }
                else
                {
                    outter += 2;
                    inner -= 2;
                    LineFormat(middleLine, background, outter, inner, middle);
                }
            }

            Console.WriteLine(firstLastLine);
        }

        private static void LineFormat(string middleLine, char background, int outter, int inner, int middle)
        {
            Console.WriteLine(
                middleLine,
                new string(background, outter),
                new string(background, inner),
                new string(background, middle));
        }
    }
}
