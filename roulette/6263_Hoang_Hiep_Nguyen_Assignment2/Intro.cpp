#include"Intro.h"
#include<iostream>
#include <fstream>

//Define welcomeScreen function
void CDisplay::welcomeScreen() {
	ifstream myfile("welcome_screen.txt");//txt file is stored in project file
	if (myfile.is_open())
	{
		while (!myfile.eof())
		{
			getline(myfile, line);
			cout << line << endl;
		}
		myfile.close();
	}
	else
		cout << "Unable to open file.\n";
}

//Define instruction function
void CDisplay::instruction() {
	ifstream myfile("instruction.txt");//txt file is stored in project file
	if (myfile.is_open())
	{
		while (!myfile.eof())
		{
			getline(myfile, line);
			cout << line << endl;
		}
		myfile.close();
	}
	else
		cout << "Unable to open file.\n";
}
