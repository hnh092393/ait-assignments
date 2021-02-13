#include<iostream>
#include"Mode.h"

//Define modeChoosing number to get a mode
void Mode::modeChoosing(int mode) {
	std::cout << "1: One Player                      2: Two Players";
	std::cout << "\nChoose a mode by pressing 1 for One Player or 2 for Two Players" << std::endl;
	std::cin >> mode;
	//While loop: promp player choose a mode until entering a right number
	while (mode != 1 && mode != 2) {
		std::cout << "Wrong number!Please enter only 1 or 2 to choose a mode.";
		std::cin >> mode;
	}
	//this pointer
	this->mode = mode;
}