#pragma once
#include <iostream>
using namespace std;
#include <iomanip>
#include <windows.h>
#include <conio.h>
#include <string>
#include "Decoration.h"
class Room
{
private:
	int room_id;
	char room_name[5];
	Decoration decoration;
public:
	Room();
	Room(char*, int = 0);
	~Room();
	int getRoomID();
	char* getRoomName();
	void setRoom();
	string insertQuery();
	void Show();
};
