#include "Schedule.h"

Schedule::Schedule()
{
	this->schedule_id = 0;
	this->movie_id = 0;
	this->room_id = 0;
	strcpy_s(this->schedule_date, 20, " ");
	strcpy_s(this->schedule_start, 20, "");
	strcpy_s(this->schedule_end, 20, " ");
}

Schedule::Schedule(char* date, char* start, char* end, int scheduleID, int movieID, int roomID)
	:schedule_id(scheduleID), movie_id(movieID), room_id(roomID)
{
	strcpy_s(this->schedule_date, 20, date);
	strcpy_s(this->schedule_start, 20, start);
	strcpy_s(this->schedule_end, 20, end);
}

Schedule::~Schedule()
{}

int Schedule::getScheduleID()
{
	return this->schedule_id;
}
int Schedule::getRoomID()
{
	return this->room_id;
}
char* Schedule::getSDate()
{
	return this->schedule_date;
}

char* Schedule::getStart()
{
	return this->schedule_start;
}

char* Schedule::getEnd()
{
	return this->schedule_end;
}

int Schedule::getMovieID()
{
	return this->movie_id;
}
string Schedule::insertQuery()
{
	string t_query;
	string t_schedule_id = to_string(this->schedule_id);
	string t_movie_id = to_string(this->movie_id);
	string t_room_id = to_string(this->room_id);
	string t_schedule_date(this->schedule_date);
	string t_schedule_start(this->schedule_start);
	string t_schedule_end(this->schedule_end);
	t_query = t_movie_id + "','" + t_room_id + "','" + t_schedule_date + "','" + t_schedule_start + "','" + t_schedule_end + "')";
	return t_query;
}

void Schedule::Show(MovieAccess movie)
{
	for (int i = strlen(this->schedule_start) - 1; i >= 0; i--)
	{
		if (this->schedule_start[i] == 46)
		{
			this->schedule_start[i] = '\0';
			break;
		}
	}
	cout << left << setw(20) << movie.getMovieName(this->movie_id - 1);
	cout << left << setw(21) << this->schedule_date;
	cout << left << setw(20) << this->schedule_start;
	cout << endl;
}

void Schedule::setSchedule()
{
	Decoration d;
	d.setColor(11);
	cout << "\t\t\t\t\t\t\t\tMovie ID : ";
	d.setColor(14);
	cin >> this->movie_id;
	d.setColor(11);
	cout << "\t\t\t\t\t\t\t\tRoom ID: ";
	d.setColor(14);
	cin >> this->room_id;
	d.setColor(11);
	cout << "\t\t\t\t\t\t\t\tSchedule date (yyyy-mm-dd): ";
	d.setColor(14);
	cin.ignore();
	cin.getline(this->schedule_date, 20);
	d.setColor(11);
	cout << "\t\t\t\t\t\t\t\tSchedule start (hh:mm:ss): ";
	d.setColor(14);
	cin.getline(this->schedule_start, 20);
	d.setColor(11);
	cout << "\t\t\t\t\t\t\t\tSchedule end (hh:mm:ss): ";
	d.setColor(14);
	cin.getline(this->schedule_end, 20);
}
