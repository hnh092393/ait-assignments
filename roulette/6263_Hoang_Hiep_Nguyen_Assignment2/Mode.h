#pragma once
//mode choosing function

class Mode {
public:
	//constructor set default mode to 1
	Mode() {
		mode = 1;
	}
	void modeChoosing(int);
	friend class Control;
private:
	int mode;
};