using System;

namespace Chan_Test
{

    public class Logic
    {
		int userAge;
		string userRandom;
        string userName;
        string userRhyme;
        string userChoice;
        int currentYear;
        int birthYear;
        string userJoke;
        int wrongCounter;
        string userGood;
        string year;
        string year2;
		string[] yesAnswers = new string[] { "yes", "yup", "yeah", "yessir", "ya", "yea", "yep" };
		string[] noAnswers = new string[] { "no", "nope", "naw", "no way", "nay", "nah", "no sir" };
		int shortWait = 300;
		int medWait = 750;
		int longWait = 1500;

        public void Beginning()
        {
			var type = new TFunc();
			System.Threading.Thread.Sleep(longWait);
			type.TypeOut("\nEnter something random! Do it now!");
            userRandom = Console.ReadLine();
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("\nOk sorry that was a bit agressive, What is your name?");
            userName = Console.ReadLine();
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("\n" + userRandom + "? Don't think I've heard of that before, " + userName + "!");
			System.Threading.Thread.Sleep(longWait);
			type.TypeOut("Probably because I am but a humble robot, beep boop.", 0);
			System.Threading.Thread.Sleep(longWait);
			type.TypeOut("Hahaha, humans love that joke.", 1);
			System.Threading.Thread.Sleep(longWait);
			type.TypeOut("\nWasn't that joke funny?", 2);
            userJoke = Console.ReadLine();
			System.Threading.Thread.Sleep(medWait);
            Middle();
			return;
        }

		public void ChoiceCheck()
        {
			var type = new TFunc();
            for (int i = 0; i < yesAnswers.Length; i++)
            {
                if (userChoice.ToLower().Equals(yesAnswers[i]))
                {
					type.TypeOut("\nGlad you're so agreeable! That will be important moving forwards");
                    End();
                }
                else if (userChoice.ToLower().Equals(noAnswers[i]))
                {
					type.TypeOut("\nThis isnt a joke " + userName + ".");
                    End();
                }
            }

			type.TypeOut("\nSorry, didn't quite catch that, lets try again.", 0);
            System.Threading.Thread.Sleep(shortWait);
			type.TypeOut("\nPlease give me a 'Yes' or 'No' answer without the floaties", 0);
            userChoice = Console.ReadLine();
            System.Threading.Thread.Sleep(shortWait);
            ChoiceCheck();
			return;
        }

        public void Middle()
        {
			var type = new TFunc();
			type.TypeOut("\nThanks for your honesty.");
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("Whats a word that rhymes with Orange?");
            userRhyme = Console.ReadLine();
			System.Threading.Thread.Sleep(shortWait);
			type.TypeOut(userRhyme + "? If you say so...");
			System.Threading.Thread.Sleep(longWait);
			type.TypeOut("Anyways, lets get back on track shall we, " + userName + "?");
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("\nType 'Yes' to continue...or 'No' to be cheeky");
            userChoice = Console.ReadLine();
			System.Threading.Thread.Sleep(medWait);
            ChoiceCheck();
			return;
        }
        

        public void End()
        {
			var type = new TFunc();
			System.Threading.Thread.Sleep(longWait);
			type.TypeOut("\nWhat is the current year?");
            year = Console.ReadLine();
			System.Threading.Thread.Sleep(medWait);
            bool result = Int32.TryParse(year, out int end);
            {
                if (result)
                {
					System.Threading.Thread.Sleep(shortWait);
                    currentYear = end;
                }
                else
                {
					System.Threading.Thread.Sleep(shortWait);
					type.TypeOut("\nEnter a number.");
                    End();
                }
            }
            //currentYear = Convert.ToInt32(Console.ReadLine());
			type.TypeOut("\nAnd now what is your birth year?");
            year2 = Console.ReadLine();
			System.Threading.Thread.Sleep(shortWait);
            //birthYear = Convert.ToInt32(Console.ReadLine());
            bool result1 = Int32.TryParse(year2, out int end1);
            {
                if (result1)
                {
                    birthYear = end1;
					magicTrick();
                }
                else
                {
					type.TypeOut("\nEnter a number...Please?");
                    End();
                }
            }
			return;
        }

		public void magicTrick()
        {
			var type = new TFunc();
			userAge = currentYear - birthYear;
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("Watch this magic " + userName + ".");
			type.TypeOut("If it is " + currentYear + ", and you were born in " + birthYear + ".");
			type.TypeOut("Then this mean you are " + userAge + " years old!");
            /*Console.WriteLine("\nWatch this magic {0}.\nIf it's {1}, and your were born in {2} that means you are {3} years old!\n"
                  , userName, currentYear, birthYear, userAge = currentYear - birthYear);*/

			ageCheck();
            System.Threading.Thread.Sleep(longWait);

            Good();
			return;
        }

        public void ageCheck()
		{
			var type = new TFunc();
			if (userAge == 100)
            {
				type.TypeOut("Wow, Happy Centennial!");
            }
			else if (userAge < 100 && userAge > 49)
            {
				type.TypeOut("You seem very wise!");
            }
			else if (userAge < 50 && userAge > 18)
            {
				type.TypeOut("I know computers older than you!");
            }
			else if (userAge < 18 && userAge > 0)
            {
				type.TypeOut("I think you need to get your parents permission to continue...but I'll allow it for now.");
            } 
			else if (userAge < 0 || userAge > 100)
            {
				type.TypeOut("Time travel huh? I won't tell.");
            }
			else if (userAge == 0)
			{
				type.TypeOut("What are you, a magic fetus?");
			}
			return;
		}


		public void Good()
		{
			var type = new TFunc();
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("\nAm I good or what?");
			System.Threading.Thread.Sleep(shortWait);
			type.TypeOut("\nType 'Yes' to continue...");
			userGood = Console.ReadLine();
			System.Threading.Thread.Sleep(medWait);
			if (userGood.Equals("Yes"))
			{
				type.TypeOut("\nYou're too sweet");
				Final();
			} else if (!userGood.Equals("Yes"))
			{
				NotGood();
			}
			return;
		}

        public void NotGood()
		{
			var type = new TFunc();
			System.Threading.Thread.Sleep(medWait);
            wrongCounter += 1;
            switch (wrongCounter)
            {
                case 1:
					type.TypeOut("\nListen, I'm only taking a Yes here, don't abuse the robot.");
					type.TypeOut("It's your first mistake so I'll let you try again.");
                    Good();
                    break;
                case 2:
					type.TypeOut("\nAgain? I guess we all make mistakes. Well off you go.");
                    Good();
                    break;
                case 3:
					type.TypeOut("\nOk seriously, make sure you type the right thing this time.");
                    Good();
                    break;
                case 4:
					type.TypeOut("\nI know I'm good, why must you hurt me like this?");
                    Good();
                    break;
                case 5:
					type.TypeOut("\nOne more time and I'm done.");
                    Good();
                    break;
                case 6:
					type.TypeOut("Fine, we'll do this the hard way!");
					type.TypeOut("\nInitializing Self Destruct...");
                    while (wrongCounter < 500000)
                    {
                        wrongCounter++;
                        Console.WriteLine(wrongCounter);
                    }
					type.TypeOut("Just Kidding!");
					System.Threading.Thread.Sleep(medWait);
                    Final();
                    break;
                default:
					type.TypeOut("Wait, something doesn't seem right here, back to the start for you.");
                    Good();
                    break;
            }
			return;
		}


        public void Final()
		{
			var type = new TFunc();
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("\nThanks for taking the time to socialize with the robot!");
			System.Threading.Thread.Sleep(medWait);
			type.TypeOut("Please enjoy the rest of your day\n");
			System.Environment.Exit(0);
			return;
		}
        
    }
}
