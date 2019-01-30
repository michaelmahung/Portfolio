using System;

namespace Chan_Test
{
    class Program
	{
		static void Main(string[] args)
		{
			var start = new Start();
			var type = new TFunc();
			type.TypeOutSame("Initializing Program");
			type.TypeOutSame("...", 3);
			start.Leggo();
		}
    }

	class Start
	{
		//string startString = "Initializing Program...\n";
		string choice;

		public void Leggo()
		{
			var type = new TFunc();
            var logic = new Logic();
			/*for (int i = 0; i < startString.Length; i++)
            {
                System.Threading.Thread.Sleep(typeWait);
                Console.Write(startString[i]);
            }*/

			type.TypeOut("\nPress 1, 2 or 3", 2);
			choice = Console.ReadLine();
			bool result1 = Int32.TryParse(choice, out int end1);
            {
                if (result1)
                {
                    int final = end1;

					switch (final)
					{
						case 1:
							type.TypeOut("\nOption 1 Selected.");
							logic.Beginning();
							break;
						case 2:
							type.TypeOut("\nOption 2 is not ready.");
							Leggo();
							break;
						case 3:
							type.TypeOut("\nOption 3 is not ready.");
							Leggo();
							break;
						default:
							type.TypeOut("\nAnswer must be between 1 and 3");
							Leggo();
							break;
					}
                }
                else
                {
					type.TypeOut("\nAnswer must be a number.");
					Leggo();
                }
            }
		}
	}

}
