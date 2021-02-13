#include"MainGame.h"
#include<windows.h>
#include"Exception.h"

//Fuction to create a random number from 0 to 36 
int MainGame::getRandNo() {
	srand(time(NULL));
	randNo = rand() % 36;
	return(randNo);
}

//Define onePlayer for mode one Player
void MainGame::onePlayer(int level) {
	int totalNum_timeLimit = 10000;//Time limitation for inputing number of number is 10s
	int others_timeLimit = 8000;//Time limitation for inputing what number and how much is 8s
	int payOut = 0;//Amount of money players get per dollar if they win
	double earningMoney;// Money players win or lose per number
	double loseORwin_oneRound;//Money players win or lose per round 
	double bettedMoney; //Money that is added after numbers is betted
	int totalNum;
	cout << "**************LET'S GO******************";
	//Easy level
	if (level == 1) {
		payOut = 35;
		bal = 70.0;
		cout << "\nLevel Easy		Pay out: 35 to 1";
	}
	//Normal level
	if (level == 2) {
		payOut = 34;
		bal = 50.0;
		cout << "\nLevel Normal		Pay out: 34 to 1";
	}
	//Hard level
	if (level == 3) {
		payOut = 33;
		bal = 30.0;
		cout << "\nLevel Hard		Pay out: 33 to 1";
	}

	//While loop is excuted until player's balance run out of or hit winning money $150
	while (0 < bal&&bal < 150) {
		loseORwin_oneRound = 0.0;
		randNo = getRandNo();//Call funxtion of random number
		cout << "\nBalance = " << "$" << bal << endl;
		cout << "\nHow many number do you want to bet? ";
		//call numberTimer fuction that calculate processing time and get numbers for the number of number that player wanna bet
		numberTimer();
		//while loop control the number of number 
		while (numbers < 0 || numbers>37) {
			cout << "There are only 37 numbers from 0 to 36.\nHow many number do you want to bet again?";
			numberTimer();
		}
		totalNum = numbers;
		if (inputTime > totalNum_timeLimit) {
			cout << "You do not input on time => The bets is not approved!" << endl;
		}
		else {
			bettedMoney = 0.0;
			for (int count = 1; count <= totalNum; count++) {
				earningMoney = 0.0;
				//Ask player enter number which they want to bet
				cout << "Number " << count << ": ";
				//call numberTimer fuction that calculate processing time and get numbers that player wanna bet
				numberTimer();
				//while loop control numbers from 0 to 36
				while (numbers < 0 || numbers>37) {
					cout << "There are only 37 numbers from 0 to 36.\nNumber " << count << ": ";
					numberTimer();
				}
				if (inputTime <= others_timeLimit) {
					//Ask player enter money which they want to bet
					cout << "How much? ";
					//call moneyTimer function hat calculate processing time and get money that player wanna bet on each number
					moneyTimer();

					//while loop to control money 
					while (money<0 || money >(bal - bettedMoney)) {
						if (money < 0) {
							//Epception when user input a negative money
							try {
								if (money < 0) {
									throw myex;
								}
							}
							catch (negativeMoneyException& e) {
								cout << e.what();
							}
							cout << "\nHow much again? ";
							moneyTimer();
						}
						else {
							cout << "Not enough money! You have $" << bal - bettedMoney << " only" << endl;
							cout << "How much again? ";
							moneyTimer();
						}
					}
					if (moneyInputTime <= others_timeLimit) {
						bettedMoney += money;
						if (numbers == randNo) {
							earningMoney = money * payOut;
						}
						else
							earningMoney = -money;
					}
					else {
						cout << "You do not input on time => The bets is not approved!" << endl;
					}
					//Money players win or lose each round
					loseORwin_oneRound = loseORwin_oneRound + earningMoney;
				}
				else {
					cout << "You do not input on time => The bets is not approved!" << endl;
				}

			}//end for loop
			 //Show the final number
			cout << "\n\nNumber is " << randNo << endl;
			//Result each round
			if (loseORwin_oneRound > 0) {
				cout << "You win " << "$" << loseORwin_oneRound << endl;
			}
			else {
				cout << "You lose " << "$" << -loseORwin_oneRound << endl;
			}
		}

		//Update new Balance
		bal = bal + loseORwin_oneRound;
		//Make a gap 10s for next round
		if (0 < bal&&bal < 150) {
			cout << "\nWait for next round ";
			for (int i = 0; i <= 9; i++) {
				cout << "*";
				Sleep(1000);
			}
		}
		cout << endl;
	}
	//Final result
	if (bal <= 0) {
		cout << "Balance: " << "$" << bal;
		cout << "\nOUT OF MONEY\n  YOU LOSE";
	}
	else {
		cout << "Balance: " << "$" << bal;
		cout << "\nCONGRATS! YOU'VE HIT $150\n    YOU ARE A WINNER";
	}

}


//Two players function
void MainGame::twoPlayers(int level) {
	int totalNum_timeLimit = 10000;//Time limitation for inputing number of number is 10s
	int others_timeLimit = 8000;//Time limitation for inputing what number and how much is 8s
	int payOut = 0;//Amount of money players get per dollar if they win
	double earningMoney[2];// Money players win or lose per number
	double loseORwin_oneRound_p[2];//Money players win or lose per round 
	double bettedMoney; //Money that is added after numbers is betted
	cout << "**************LET'S GO******************";
	//Easy level
	if (level == 1) {
		payOut = 35;
		bal = 70.0;
		cout << "\nLevel Easy		Pay out: 35 to 1";
	}
	if (level == 2) {
		payOut = 34;
		bal = 50.0;
		cout << "\nLevel Normal		Pay out: 34 to 1";
	}
	if (level == 3) {
		payOut = 33;
		bal = 30.0;
		cout << "\nLevel Hard		Pay out: 33 to 1";
	}
	double balance[2] = { bal,bal };
	int totalNum;
	//While loop is excuted until player's balance run out of or hit winning money $150
	while (balance[0] > 0 && balance[0] < 150 && balance[1]>0 && balance[1] < 150) {
		randNo = getRandNo();//Call funxtion of random number
		for (int i = 0; i <= 1; i++) {
			earningMoney[i] = 0.0;
			loseORwin_oneRound_p[i] = 0.0;
			cout << "\nPLAYER " << i + 1;
			cout << "\nBalance = " << balance[i] << "$" << endl;
			cout << "\nHow many number do you want to bet? ";
			//call numberTimer fuction
			numberTimer();
			while (numbers < 0 || numbers>37) {
				cout << "There are only 37 numbers from 0 to 36.\nHow many number do you want to bet again?";
				numberTimer();
			}
			totalNum = numbers;
			if (inputTime > totalNum_timeLimit) {
				cout << "You do not input on time => You missed this round!" << endl;
			}
			else {
				loseORwin_oneRound_p[i] = 0.0;
				bettedMoney = 0.0;
				for (int count = 1; count <= totalNum; count++) {
					earningMoney[i] = 0.0;
					//Ask player enter number which they want to bet
					cout << "Number " << count << ": ";
					numberTimer();
					while (numbers < 0 || numbers>36) {
						cout << "There are only 37 numbers from 0 to 36.\nHow many number do you want to bet again?";
						numberTimer();
					}
					if (inputTime <= others_timeLimit) {
						//Ask player enter money which they want to bet
						cout << "How much? ";
						//call moneyTimer function
						moneyTimer();
						while (money<0 || money >(balance[i] - bettedMoney)) {
							if (money < 0) {
								//Epception when user input a negative money
								try {
									if (money < 0) {
										throw myex;
									}
								}
								catch (negativeMoneyException& e) {
									cout << e.what();
								}
								cout << "\nHow much again? ";
								moneyTimer();
							}
							else {
								cout << "Not enough money! You have $" << balance[i] - bettedMoney << " only" << endl;
								cout << "How much again? ";
								moneyTimer();
							}
						}
						if (moneyInputTime <= others_timeLimit) {
							bettedMoney += money;
							if (numbers == randNo) {
								earningMoney[i] = money * payOut;
							}
							else
								earningMoney[i] = -money;
						}
						else {
							cout << "You do not input on time => The bets is not approved!" << endl;
						}
						//Money players win or lose each round
						loseORwin_oneRound_p[i] = loseORwin_oneRound_p[i] + earningMoney[i];
					}
					else {
						cout << "You do not input on time => The bets is not approved!" << endl;
					}

				}//end for loop
			}
			cout << "____________________________________" << endl;
		}
		//Show the final number
		cout << "\n\nNumber is " << randNo << endl;
		//Result each round
		if (loseORwin_oneRound_p[0] > 0) {
			cout << "Player 1 wins: " << "$" << loseORwin_oneRound_p[0] << endl;
			if (loseORwin_oneRound_p[1] > 0) {
				cout << "Player 2 wins: " << "$" << loseORwin_oneRound_p[1] << endl;
				cout << "You both win this round! " << endl;
			}
			else if (loseORwin_oneRound_p[1] < 0) {
				cout << "Player 2 loses: " << "$" << -loseORwin_oneRound_p[1] << endl;
			}
			else
				cout << "Player 2 tied: " << "$" << loseORwin_oneRound_p[1] << endl;
		}
		else if (loseORwin_oneRound_p[0] < 0) {
			cout << "Player 1 loses: " << "$" << -loseORwin_oneRound_p[0] << endl;
			if (loseORwin_oneRound_p[1] < 0) {
				cout << "Player 2 loses: " << "$" << -loseORwin_oneRound_p[1] << endl;
				cout << "You both lose this round" << endl;
			}
			else if (loseORwin_oneRound_p[1] > 0) {
				cout << "Player 2 wins: " << "$" << loseORwin_oneRound_p[1] << endl;
			}
			else
				cout << "Player 2 tied: " << "$" << loseORwin_oneRound_p[1] << endl;

		}
		else if (loseORwin_oneRound_p[0] == 0) {
			if (loseORwin_oneRound_p[1] > 0) {
				cout << "Player 1 tied: " << "$" << loseORwin_oneRound_p[0] << endl;
				cout << "Player 2 wins: " << "$" << loseORwin_oneRound_p[1] << endl;

			}
			else if (loseORwin_oneRound_p[1] < 0) {
				cout << "Player 1 tied: " << "$" << loseORwin_oneRound_p[0] << endl;
				cout << "Player 2 loses: " << "$" << -loseORwin_oneRound_p[1] << endl;
			}
			else
				cout << "You both are tied " << endl;
		}





		//Update new Balance
		//Update new Balance
		balance[0] = balance[0] + loseORwin_oneRound_p[0];
		balance[1] = balance[1] + loseORwin_oneRound_p[1];
		//Make a gap 10s for next round
		if (balance[0] > 0 && balance[0] < 150 && balance[1]>0 && balance[1] < 150) {
			cout << "\nWait for next round ";
			for (int i = 0; i <= 9; i++) {
				cout << "*";
				Sleep(1000);
			}
			//Clear screen
			cin.sync();
			system("cls");
		}
		cout << endl;
	}
	//Final result
	if (balance[0] <= 0 && balance[1] <= 0) {
		cout << "Balance 1: " << "$" << balance[0] << endl;
		cout << "Balance 2: " << "$" << balance[1] << endl;
		cout << "\nOUT OF MONEY\nYOU BOTH LOSE";
	}
	else if ((balance[0] > 0 && balance[1] <= 0) || (balance[0] >= 150 && balance[1] < 150)) {
		cout << "Balance 1: " << "$" << balance[0] << endl;
		cout << "Balance 2: " << "$" << balance[1] << endl;
		cout << "Player 1 wins!";
	}
	else if ((balance[1] > 0 && balance[0] <= 0) || (balance[1] >= 150 && balance[0] < 150)) {
		cout << "Balance 1: " << "$" << balance[0] << endl;
		cout << "Balance 2: " << "$" << balance[1] << endl;
		cout << "Player 2 wins!";
	}
	else {
		cout << "Balance 1: " << "$" << balance[0] << endl;
		cout << "Balance 2: " << "$" << balance[1] << endl;
		cout << "\nCONGRATS! YOU BOTH HAVEVE HIT $150\n   YOU BOTH ARE WINNERS";
	}

}


//number function that calculate processing input number time and get numbers
//Reference http://www.cplusplus.com/forum/beginner/12216/
void MainGame::numberTimer() {
	unsigned t0 = clock();
	cin >> numbers;
	inputTime = clock() - t0;
}

//number function that calculate processing input money time and get numbers
void MainGame::moneyTimer() {
	unsigned t0 = clock();
	cin >> money;
	moneyInputTime = clock() - t0;
}
