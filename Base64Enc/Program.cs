using System;
using System.Linq;
using System.Text;

namespace Base64Enc
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Base64Enc");

			if (!args.Any() || args.Length < 2 || !"ed".Contains(args[0].ToLowerInvariant()))
			{
				ShowUsage();
				return;
			}

			try
			{
				var result = args[0].ToLowerInvariant() == "d" ? Base64Decode(args[1]) : Base64Encode(string.Join(" ", args.Skip(1)));
				Console.WriteLine($"\n---- START ----\n{result}\n----- END -----");
			}
			catch (Exception e)
			{
				Console.WriteLine($"Couldn't do that. This happened:\n{e.Message}");
			}
		}

		private static void ShowUsage()
		{
			Console.WriteLine("Usage:\n\tBase64Enc [e|d] string\n\te\tencode\n\td\tdecode");
		}

		private static string Base64Encode(string plainText)
		{
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(plainTextBytes);
		}

		private static string Base64Decode(string base64EncodedData)
		{
			var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}
