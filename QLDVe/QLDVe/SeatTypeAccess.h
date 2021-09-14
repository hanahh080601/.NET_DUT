#pragma once
#include "SeatType.h"
#include "DatabaseAccess.h"
class SeatTypeAccess :
    public DatabaseAccess
{
    Decoration decoration;
public:
    void Select(SeatType*&);
    int Count();
    bool Insert();
    bool Update(int, int);
    int LastID();
    bool Delete();
    void Show();
    SeatType getSeatType(int);
};