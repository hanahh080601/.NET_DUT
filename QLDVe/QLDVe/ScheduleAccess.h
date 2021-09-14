#pragma once
#include "Schedule.h"
#include "Date.h"
#include "DatabaseAccess.h"
#include "RoomAccess.h"
#include "MovieAccess.h"
class ScheduleAccess : public DatabaseAccess
{
    Decoration decoration;
public:
    void Select(Schedule*&, int, int);
    int Count(int);
    bool Insert();
    int Search(int); // search theo id_number
    bool Update(int, int);
    bool Delete(int);
    void Show(int);
    Schedule getSchedule(int);
    char* getRoomName(int);
    int LastID();
};
