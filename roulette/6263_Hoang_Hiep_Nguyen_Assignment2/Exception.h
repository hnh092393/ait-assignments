#pragma once
#include <iostream>
#include <string>

using namespace std;
//Exception
class negativeMoneyException : public exception {
public:
	virtual const char* what() const throw() {
		return "Tried to input a negative for money. Don't do it man!";
	}
}
myex;