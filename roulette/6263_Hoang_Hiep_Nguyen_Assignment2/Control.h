#pragma once
#include "Intro.h"
#include "Mode.h"
#include "Level.h"
#include "MainGame.h"


//Control class
class Control {
public:
	void optControl(int, CDisplay);//member function to control option of user
	friend class MainGame;

private:
	Level lev;
	Mode mod;
};