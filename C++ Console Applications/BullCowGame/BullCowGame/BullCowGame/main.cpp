/* 
This is the console executable that makes use of the BullCow class
this acts as the view in a MVC pattern, and is responsible for all
user interaction. For game logic see the FBullCowGame class.
*/

#pragma once
#include <iostream>
#include <string>
#include "FBullCowGame.h"

//Used to make syntax Unreal friendly.
using FText = std::string;
using int32 = int;

void PrintIntro();
void PlayGame();
FText GetValidGuess();
void PrintGuess(FText guess);
void PrintGameSummary(bool);
bool AskToPlayAgain();
bool IsDone = false;

FBullCowGame BCGame;

//Main gameplay loop
int main()
{
	do
	{
		PrintIntro();
		PlayGame();
		AskToPlayAgain();
	} while (!IsDone);

	return 0;
}

void PlayGame()
{
	BCGame.Reset();
	int32 MaxTries = BCGame.GetMaxTries();

	//loop asking for guesses while the game is NOT won
	//and there are still tries remaining

	while (!BCGame.IsGameWon() && BCGame.GetCurrentTry() <= MaxTries)
	{
		FText Guess = GetValidGuess();
		PrintGuess(Guess);

		FBullCowCount BullCowCount = BCGame.SubmitValidGuess(Guess);

		std::cout << "Bulls = " << BullCowCount.Bulls;
		std::cout << ". Cows = " << BullCowCount.Cows << "\n\n";
	}

	PrintGameSummary(BCGame.IsGameWon());
}

//loop until user gives a valid guess
FText GetValidGuess()
{
	EGuessStatus Status = EGuessStatus::Invalid_Status;
	FText Guess = "";

	do 
	{
		int32 CurrentTry = BCGame.GetCurrentTry();

		std::cout << "Try " << CurrentTry <<" of " << BCGame.GetMaxTries() << " Enter your guess. \n";
		getline(std::cin, Guess);

		Status = BCGame.CheckGuessVaildity(Guess);

		switch (Status)
		{
		case EGuessStatus::Wrong_Length:
			std::cout << "*Please enter a " << BCGame.GetHiddenWordLength() << " letter word.*\n\n";
			break;
		case EGuessStatus::Not_Isogram:
			std::cout << "*Please enter a word without repeating letters.*\n\n";
			break;
		case EGuessStatus::Not_Lowercase:
			std::cout << "*Guess must be all lowercase letters.*\n\n";
			break;
		default:
			break;
		}
		std::cout << std::endl;
	} while (Status != EGuessStatus::OK); //Keep loopig until we get no errors

	return Guess;
}

void PrintIntro() {
	std::cout << R"(  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
|  ____          _  _         ___      ____                      |
| | __ )  _   _ | || | ___   ( _ )    / ___| ___ __      __ ___  |
| |  _ \ | | | || || |/ __|  / _ \/\ | |    / _ \\ \ /\ / // __| |
| | |_) || |_| || || |\__ \ | (_>  < | |___| (_) |\ V  V / \__ \ |
| |____/  \__,_||_||_||___/  \___/\/  \____|\___/  \_/\_/  |___/ |
|                                                                |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~                                                            
)";

	std::cout << "\nWelcome to Bulls and Cows, a fun word game.\n \n";
	std::cout << "Can you guess the " << BCGame.GetHiddenWordLength();
	std::cout << " letter isogram I am thinking of?\n \n";

	return;
}

void PrintGuess(FText guess)
{
	std::cout << "Your guess is: " << guess << "\n";
	return;
}

bool AskToPlayAgain()
{
	std::cout << "Do you want to play again with the same hidden word? (y/n) \n";
	FText Response = "";
	getline(std::cin, Response);


	char _response = Response[0];
	if (_response == 'y' || _response == 'Y')
	{
		std::cout << "\n";
		return true;
	}
	else if (_response == 'n' || _response == 'N')
	{
		IsDone = true;
		return false;
	}
	else
	{
		AskToPlayAgain();
		return NULL;
	}
}

//Print whether the player won or not
void PrintGameSummary(bool gameWon)
{
	if (gameWon)
	{
		std::cout << "***** Congratulations! You won! *****\n\n";
	}
	else
	{
		std::cout << "##### Unfortunate, you lose. ##### \n\n";
	}
}