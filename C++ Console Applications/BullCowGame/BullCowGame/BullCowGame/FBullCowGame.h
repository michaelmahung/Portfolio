/*
This is the header file for the FBullCowGame class.
The header file is responsible for defining the functionality of the class.
In this case, we are defining a struct to track the bull and cow count,
as well as an enum class that will be used for error checking.

The benefit of having a header file is that when we ship this project,
the items in the header may be available to view, but the actual implementation
will be hidden from the user.
*/

#pragma once
#include <string>

//Used to make syntax Unreal friendly.
using FString = std::string;
using int32 = int;

//Used to count the individual bulls and cows
struct FBullCowCount
{
	int32 Bulls = 0;
	int32 Cows = 0;
};

//Used to define different guess input errors
enum class EGuessStatus 
{
	Invalid_Status,
	OK,
	Not_Isogram,
	Wrong_Length,
	Not_Lowercase,
};

class FBullCowGame {
public:
	FBullCowGame(); //Constructor

	int32 GetMaxTries() const;
	int32 GetCurrentTry() const;
	int32 GetHiddenWordLength() const;
	bool IsGameWon() const;
	EGuessStatus CheckGuessVaildity(FString) const;

	void Reset();

	//counts bulls and cows, increases try# - assumes a valid guess
	FBullCowCount SubmitValidGuess(FString guess);

private:
	int32 MyCurrentTry;
	FString MyHiddenWord;
	bool bGameIsWon;

	bool isIsogram(FString) const;
	bool IsLowercase(FString) const;
};