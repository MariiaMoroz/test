using System;

namespace DividerList
{
	class DividerList
	{
		public static void Main()
		{
			bool flag = true;
			while (flag)
			{
				Console.WriteLine("Write number:");
				if (int.TryParse(Console.ReadLine(), out int number))
				{
					Console.WriteLine("Divider List:");
					Console.WriteLine(GetDividers(number));
					flag = false;
				}
			}
			Console.ReadKey();
		}

		public static string GetDividers(int number)
		{
			string result = null;
			for (int i = 1; i <= number; i++)
			{
				if (number % i == 0) result += i + " ";
			}
			return result;
		}
	}
}
