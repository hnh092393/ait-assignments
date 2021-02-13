//Intro.h
#pragma once

#include <string>

using namespace std;

// Class CDisplay is to show welcomescreen and instruction
class CDisplay {
public:
	void welcomeScreen(); //Member function to show welcome screen
	void instruction();// Member function to show instruction
private:
	string line;//variable is used to show txt file
};