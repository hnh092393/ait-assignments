#include"Level.h"
//Define lvlChoosing function
void Level::lvlChoosing(int level) {
	cout << "1: Easy                 2: Normal                  3:Hard";
	cout << "\nChoose a level by pressing 1 for Easy or 2 for Normal or 3 for Hard level" << endl;
	cin >> level;
	//While loop: promp player choose a level until entering a right number
	while (level != 1 && level != 2 && level != 3) {
		cout << "Wrong number!Please enter only 1 or 2 or 3 to choose a level.";
		cin >> level;
	}
	//This pointer
	this->level = level;
}