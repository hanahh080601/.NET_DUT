#include "Date.h"
Date::Date()
{
}
Date::~Date()
{
}
string Date::getToDay() {
    time_t now = time(0);
    tm d;
    localtime_s(&d, &now);
    string day = to_string(d.tm_mday);
    string mon = to_string(d.tm_mon + 1);
    string year = to_string(d.tm_year + 1900);
    return "'" + year + "-" + mon + "-" + day + "'";
}
string Date::getMonth()
{
    time_t now = time(0);
    tm d;
    localtime_s(&d, &now);
    string mon = to_string(d.tm_mon + 1);
    return  mon;
}