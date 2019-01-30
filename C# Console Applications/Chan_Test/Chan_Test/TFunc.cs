using System;
namespace Chan_Test
{
    public class TFunc
    {
        int typeFast = 20;
		int typeMed = 40;
		int typeSlow = 60;
		int typeBuffer = 300;


        public TFunc()
        {
        }

		public void TypeOutSame(string input, int speed)
        {
            switch (speed)
            {
                case 0:
                    speed = typeFast;
                    break;
                case 1:
                    speed = typeMed;
                    break;
                case 2:
                    speed = typeSlow;
                    break;
				case 3:
					speed = typeBuffer;
					break;
                default:
                    speed = typeMed;
                    break;
            }

            for (int i = 0; i < input.Length; i++)
            {
                System.Threading.Thread.Sleep(speed);
                Console.Write(input[i]);
            }
        }

		public void TypeOutSame(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
				System.Threading.Thread.Sleep(typeMed);
                Console.Write(input[i]);
            }
        }

		public void TypeOut(string input, int speed)
		{
            switch (speed)
			{
				case 0:
					speed = typeFast;
					break;
				case 1:
					speed = typeMed;
					break;
				case 2:
					speed = typeSlow;
					break;
				case 3:
                    speed = typeBuffer;
                    break;
				default:
					speed = typeMed;
					break;
			}

			for (int i = 0; i < input.Length; i++)
            {
				System.Threading.Thread.Sleep(speed);
				Console.Write(input[i]);
            }
			Console.WriteLine("");
		}

		public void TypeOut(string input)
        {

            for (int i = 0; i < input.Length; i++)
            {
				System.Threading.Thread.Sleep(typeMed);
                Console.Write(input[i]);
            }
            Console.WriteLine("");
        }
    }
}
