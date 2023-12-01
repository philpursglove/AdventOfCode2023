namespace AdventUtilities
{
    public static class StringExtensions
    {
        public static string[,] ToGrid<T>(this string[] strings)
        {
            string[,] grid = new string[strings.First().Length, strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    grid[i, j] = strings[i].Substring(j, 1);
                }
            }

            return grid;
        }

        public static int[,] ToIntGrid(this string[] strings)
        {
            int[,] grid = new int[strings.First().Length, strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    grid[i, j] = int.Parse(strings[i].Substring(j, 1));
                }
            }

            return grid;
        }

        public static char[,] ToCharGrid(this string[] strings)
        {
            int width = strings.First().Length, height = strings.Length;
            char[,] grid = new char[width, height];

            for (int y = 0; y < (height); y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[x, y] = (strings[y].Substring(x, 1)).ToCharArray()[0];
                }
            }

            return grid;
        }

        public static bool ContainsDigits(this string input)
        {
            return input.Any(char.IsDigit);
        }

        public static bool ContainsMixedCase(this string input)
        {
            return (input.Any(char.IsLower) && input.Any(char.IsUpper));
        }

        public static bool IsNumeric(this string str)
        {
            return str.All(char.IsNumber);
        }
    }
}
