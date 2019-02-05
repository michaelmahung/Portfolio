/*
This is the class file for the FBullCowGame.
While the header file is used to outline functionality
this .cpp file is where we are going to define what those
functions actually do.
*/

#pragma once
#include "FBullCowGame.h"
#include <map>
#define TMap std::map

using int32 = int;

//Default constructor. Used to instantiate a new game that is reused across plays
FBullCowGame::FBullCowGame() 
{ 
	Reset(); 
	return;
};

int32 FBullCowGame::GetCurrentTry() const { return MyCurrentTry; }
int32 FBullCowGame::GetHiddenWordLength() const { return MyHiddenWord.length(); }
bool FBullCowGame::IsGameWon() const { return bGameIsWon; }

//Uses a map to create a variety of max tries depending on the amount of letters in the word selected.
int32 FBullCowGame::GetMaxTries() const 
{ 
	TMap<int32, int32> WordLengthToMaxTries{ {2,3}, {3,4}, {4,7}, {5,10}, {6,16}, {7,20}, {8,25} }; //We can initialize our map with a set of variables using {}.
	return WordLengthToMaxTries[MyHiddenWord.length()]; //We then return the second integer value depending on the length of the word passed in.
}

void FBullCowGame::Reset()
{
	const FString HIDDEN_WORD = "planet"; //This MUST be an isogram
	MyHiddenWord = HIDDEN_WORD;

	MyCurrentTry = 1;
	bGameIsWon = false;
	return;
}

//Checks if the guess contains any uppercase letters
bool FBullCowGame::IsLowercase(FString guess) const
{
	for (auto Letter : guess)
	{
		if (!islower(Letter))
		{
			return false;
		}
	}

	return true;
}

//Checks if the guess has any repeating letters
bool FBullCowGame::isIsogram(FString guess) const
{
	if (guess.length() <= 1) { return true; }

	TMap<char, bool> LetterSeen;

	for (auto Letter : guess)
	{
		Letter = tolower(Letter); //can handle upper and lowercase letters
		
		if (LetterSeen[Letter]) {
			return false; //We do not have an isogram
		}
		else
		{
			LetterSeen[Letter] = true;
		}
	}

	//treat 0 and 1 letter words as isograms

	//Create a hash table to compare against with the alphabet.
	//For each letter in our guess
		//Check if the letter has already been added to our hash table
	//If it hasnt, loop again with the next letter
	//If it has, return false.

	//return true if all letters pass the test.

	return true; //for example in cases where /0 is entered
}

//Checks if a guess is valid and returns a status
EGuessStatus FBullCowGame::CheckGuessVaildity(FString guess) const
{
	if (!isIsogram(guess))
	{
		return EGuessStatus::Not_Isogram;
	}
	else if (!IsLowercase(guess))
	{
		return EGuessStatus::Not_Lowercase;
	}
	else if (guess.length() != GetHiddenWordLength())
	{
		return EGuessStatus::Wrong_Length;
	}
	else

	{
		return EGuessStatus::OK;
	}
}

//Receives a VALID guess, increments turn and returns count
FBullCowCount FBullCowGame::SubmitValidGuess(FString guess)
{
	MyCurrentTry++;
	FBullCowCount BullCowCount;

	int32 WordLength = MyHiddenWord.length();

	//loop through all letters in the guess
	for (int32 i = 0; i < WordLength; i++)
	{
		for (int32 j = 0; j < WordLength; j++)
		{
			if (guess[j] == MyHiddenWord[i])
			{
				if (i == j)
				{
					BullCowCount.Bulls++;
				}
				else
				{
					BullCowCount.Cows++;
				}
			}
		}
	}

	if (BullCowCount.Bulls == WordLength)
	{
		bGameIsWon = true;
	}
	else
	{
		bGameIsWon = false;
	}

	return BullCowCount;
}
