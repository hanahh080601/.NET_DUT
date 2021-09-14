#pragma once
#include <iostream>
using namespace std;
#include <iomanip>
#include <windows.h>
#include <conio.h>
#include <string>
#include "RoomAccess.h"
#include "Room.h"
#include "Decoration.h"
class Seat
{
	Decoration decoration;
private:
	int seat_id;
	int seatType_id;
	int room_id;
	char seat_row[5];
	char seat_number[5];
	int seat_status;
public:
	Seat();
	Seat(char*, char*, int = 0, int = 0, int = 0, int = 0);
	~Seat();
	int getSeatID();
	int getStatus();
	char* getSeatRow();
	char* getSeatNumber();
	int getSeatType();
	string insertQuery();
	void setSeat();
	void Show();
};