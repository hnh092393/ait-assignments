#include"Intro.h"
#include"Control.h"


//Main function 
void main() {
	CDisplay display;
	Control cont;
	int option;
	char nextGame;

	//Display main screen
	display.welcomeScreen();

	//Choose an option
	cin >> option;
	//while loop control option until exit option selected
	while (option != 1 && option != 2 && option != 3 && option != 4 && option != 5) {
		cout << "Wrong number! Enter option number only.";
		cin >> option;
	}
	while (option == 1 || option == 2 || option == 3 || option == 4 || option == 5) {
		//Clear the screen
		cin.ignore();
		cin.sync();
		system("cls");//

		if (option == 1) {
			cont.optControl(option, display);
			//Clear the screen
			cin.ignore();
			cin.sync();
			system("cls");//

			display.welcomeScreen();
			cin >> option;
			//while loop control option until exit option selected
			while (option != 1 && option != 2 && option != 3 && option != 4 && option != 5) {
				cout << "Wrong number! Enter option number only.";
				cin >> option;
			}
		}
		else if (option == 2 || option == 3) {
			cont.optControl(option, display);
			cin >> option;
			//while loop control option until exit option selected
			while (option != 1 && option != 2 && option != 3 && option != 4 && option != 5) {
				cout << "Wrong number! Enter option number only.";
				cin >> option;
			}
		}
		else if (option == 4) {
			cont.optControl(option, display);
			cout << "\n\nPress y to play agian or any other keys to quit." << endl;
			cout << "Player agian! ";
			cin >> nextGame;
			//Clear the screen
			cin.ignore();
			cin.sync();
			system("cls");//
			if (nextGame != 'y' && nextGame != 'Y')
				exit(1);//exit immediately
			else {
				display.welcomeScreen();
				cin >> option;
				//while loop control option until exit option selected
				while (option != 1 && option != 2 && option != 3 && option != 4 && option != 5) {
					cout << "Wrong number! Enter number option only.";
					cin >> option;
				}
			}
		}
		else {
			exit(1);//exit immediately
		}

	}


	system("pause");
}