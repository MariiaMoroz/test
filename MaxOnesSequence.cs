using System;
using System.IO;
using System.Text;

namespace MaxOnesSequence
{
	class MainMethod
	{
		public static void Main()
		{
			const string INPUTFilename = "\\INPUT";
			const string OUTPUTFilename = "\\OUTPUT";
			const string EXTENSION = ".txt";
			const int MAXSIZE = 100;
			string sequence = null;
			while (sequence == null)
			{
				if (File.Exists(Directory.GetCurrentDirectory() + INPUTFilename + EXTENSION))
				{
					using (StreamReader stream = new StreamReader(Directory.GetCurrentDirectory() 
						+ INPUTFilename + EXTENSION))
					{
						sequence = stream.ReadLine();
					}
				}
				else
				{
					using (File.Create(Directory.GetCurrentDirectory() + INPUTFilename + EXTENSION)) { }
					Console.WriteLine("Write zeros and ones:");
					string input = Console.ReadLine();
					string result = "";
					if (input.Length > MAXSIZE)
					{
						for (int i = 0; i < MAXSIZE; i++)
							result += input[i] == '0' ? '0' : '1';
					}
					else foreach(char c in input)
						{
							result += c == '0' ? '0' : '1';
						}
					WriteFile(result, INPUTFilename, EXTENSION);
				}
			}
			WriteFile(MaxOnesSequence(sequence).ToString(), OUTPUTFilename, EXTENSION);
			Console.ReadKey();
		}

		public static void WriteFile(string text, string filename, string extension)
		{
			using (StreamWriter swriter = new StreamWriter(Directory.GetCurrentDirectory() + filename
							+ extension, true, Encoding.Default))
			{
				swriter.WriteLine(text);
			}
		}
			

		public static int MaxOnesSequence(string sequence)
		{
			int returnValue = 0;
			int temp = 0;
			foreach(char character in sequence)
			{
				if(character != '0')
				{
					temp++;
				}
				else if(temp > returnValue)
				{
					returnValue = temp;
					temp = 0;
				}
				else { temp = 0; }
			}
			return returnValue;
		}
	}
}
