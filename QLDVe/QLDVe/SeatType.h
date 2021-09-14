#pragma once
#include <iostream>
using namespace std;
#include <iomanip>
#include <windows.h>
#include <conio.h>
#include <string>
#include "Decoration.h"
class SeatType
{
public:
    int seat_type_id;
    char seat_type[15];
    int seat_price;
    Decoration decoration;
public:
    SeatType();
    SeatType(char*, int = 0, int = 0);
    ~SeatType();
    int getSeatTypeID();
    char* getSeatTypeName();
    void setSeatType();
    int getSeatPrice();
    string insertQuery();
    void Show(); // xem seatType ( ko cần thiết lắm )
};