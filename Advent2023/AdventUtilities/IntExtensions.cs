using System.Diagnostics;

namespace AdventUtilities
{
	public static class IntExtensions
	{
        [DebuggerStepThrough]
		public static bool Between(this int a, int lower, int upper)
		{
			if (lower > upper)
			{
				int temp = lower;
				lower = upper;
				upper = temp;
			}

			return (a >= lower) && (a <= upper);
		}

        public static List<int> GetWestValues(this int[,] grid, int x, int y)
        {
			List<int> values = new List<int>();

            for (int i = 0; i < y; i++)
            {
				values.Add(grid[x, i]);
            }

            return values;
        }

        public static List<int> GetEastValues(this int[,] grid, int x, int y)
        {
            List<int> values = new List<int>();

            for (int i = y + 1; i < grid.GetUpperBound(1) + 1; i++)
            {
                values.Add(grid[x, i]);
            }

            return values;
        }

        public static List<int> GetSouthValues(this int[,] grid, int x, int y)
        {
            List<int> values = new List<int>();

            for (int i = x + 1; i < grid.GetUpperBound(0) + 1; i++)
            {
                values.Add(grid[i, y]);
            }

            return values;
        }

        public static List<int> GetNorthValues(this int[,] grid, int x, int y)
        {
            List<int> values = new List<int>();

            for (int i = 0; i < x; i++)
            {
                values.Add(grid[i, y]);
            }

            return values;
        }
    }
}
