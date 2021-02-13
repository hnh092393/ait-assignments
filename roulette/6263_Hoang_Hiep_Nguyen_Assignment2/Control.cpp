#include"MainGame.h"

//define optControl function
void Control::optControl(int choice, CDisplay dis) {
	if (choice == 1) {
		dis.instruction();
		cout << "Enter to go back ";
	}
	else if (choice == 2) {
		mod.modeChoosing(mod.mode);
		//Clear the screen
		cin.ignore();
		cin.sync();
		system("cls");

		dis.welcomeScreen();
	}
	else if (choice == 3) {

		lev.lvlChoosing(lev.level);
		//Clear the screen
		cin.ignore();
		cin.sync();
		system("cls");

		dis.welcomeScreen();
	}
	else if (choice == 4) {
		MainGame MGame;
		if (mod.mode == 1) {
			MGame.onePlayer(lev.level);
		}
		if (mod.mode == 2) {
			MGame.twoPlayers(lev.level);
		}
	}
}