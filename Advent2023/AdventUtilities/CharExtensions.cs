namespace AdventUtilities
{
	public static class CharExtensions
	{
		public static int ToAscii(this char letter)
		{
			return (int) letter;
		}

		public static ValueTuple<int, int> FindValue(this char[,] grid, char searchValue, bool caseSensitive = false)
		{
			for (int i = 0; i < grid.GetUpperBound(0); i++)
			{
				for (int j = 0; j < grid.GetUpperBound(1); j++)
				{
					char gridValue = grid[i, j];
					if (caseSensitive)
					{
						if (gridValue == searchValue)
						{
							return new ValueTuple<int, int>(i, j);
						}
					}
					else
					{
						if (char.ToLower(gridValue) == char.ToLower(searchValue))
						{
							return new ValueTuple<int, int>(i, j);
						}
					}
				}
			}

			return new (-1,-1);
		}
	}
}
