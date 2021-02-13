#pragma once
#include <iostream>
#include <ctime>
#include"Control.h"
#include <cstdlib>
#include <ctime>

//Maingame class
class MainGame {
public:
	int getRandNo();//member function to get a random number
	void numberTimer();//member function to count processing time and get number input
	void moneyTimer();//member function to count processing time and get money input
	void onePlayer(int);//lgic function for mode 1 player 
	void twoPlayers(int);//Lofic function for mode 2 player
private:
	double bal = 0;
	int randNo;
	int numbers;
	int money;
	unsigned inputTime;
	unsigned moneyInputTime;
};