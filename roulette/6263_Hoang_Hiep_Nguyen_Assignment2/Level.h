#pragma once
#include<iostream>
#include"Control.h"
//Level Choosing function

class Level {
public:
	//constructor set default level to 1
	Level() {
		level = 1;
	}
	void lvlChoosing(int);//member function to get a level from user
	friend class Control;
private:
	int level;
};