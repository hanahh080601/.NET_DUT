#include "ScheduleAccess.h"
#include <iomanip>

void ScheduleAccess::Select(Schedule*& schedule, int choice, int id)
{
	// 1. 1 - 0: select all
	// 2. 2 - id phim: select theo id phim
	// 3. 3 - 0: select theo ngày hiện tại
	int i = 0;
	Date date;
	string c_query = "";
	//int stt;
	switch (choice)
	{
	case 1:
		c_query = "select * from schedule";
		break;
	case 2:
		/*cout << "Nhap stt phim : ";
		cin >> stt;
		id = mv.getMovie(stt-1).getMovieID();*/
		c_query = "select * from schedule where movie_id = " + to_string(id);
		break;
	case 3:
		c_query = "select * from schedule where schedule_date = " + date.getToDay();
		break;
	}
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		SQLINTEGER PtrSQLVersion;
		int schedule_id;
		int movie_id;
		int room_id;
		char schedule_date[20];
		char schedule_start[20];
		char schedule_end[20];
		int i = 0;
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			SQLGetData(SQLStateHandle, 1, SQL_INTEGER, &schedule_id, sizeof(schedule_id), NULL);
			SQLGetData(SQLStateHandle, 2, SQL_INTEGER, &movie_id, sizeof(movie_id), NULL);
			SQLGetData(SQLStateHandle, 3, SQL_INTEGER, &room_id, sizeof(room_id), NULL);
			SQLGetData(SQLStateHandle, 4, SQL_CHAR, schedule_date, sizeof(schedule_date), NULL);
			SQLGetData(SQLStateHandle, 5, SQL_CHAR, schedule_start, sizeof(schedule_start), NULL);
			SQLGetData(SQLStateHandle, 6, SQL_CHAR, schedule_end, sizeof(schedule_end), NULL);

			Schedule* temp = new Schedule(schedule_date, schedule_start, schedule_end, schedule_id, movie_id, room_id);
			*(schedule + i) = *temp;
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
}

int ScheduleAccess::Count(int choice)
{
	//1. đếm tất cả
	//2. đếm theo phim
	//3. đếm theo ngày chiếu hiện tại
	int i = 0;
	Date date;
	string c_query = "";
	switch (choice)
	{
	case 1:
		c_query = "select  * from schedule ";
		break;
	case 2:
		c_query = "select * from schedule inner join movie on schedule.movie_id = movie.movie_id";
		break;
	case 3:
		c_query = "select  * from schedule where schedule_date = " + date.getToDay();
		break;
	}
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
	return i;
}

bool ScheduleAccess::Insert()
{
	string c_query = "insert into schedule values ('";
	Schedule sc;
	sc.setSchedule();
	string t_ID = to_string(this->LastID() + 1);
	c_query += t_ID + "','";
	c_query += sc.insertQuery();
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		cout << c_query;
		cout << "\t\t\t\t\t\t\t\tSuccess!!" << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
}

int ScheduleAccess::LastID() {
	Schedule* ptr = new Schedule[this->Count(1)];
	this->Select(ptr, 1, 0);
	return ptr[this->Count(1) - 1].getScheduleID();
}

Schedule ScheduleAccess::getSchedule(int index)
{
	Schedule* ptr = new Schedule[this->Count(1)];
	this->Select(ptr, 1, 0);
	return ptr[index];
}

int ScheduleAccess::Search(int scheduleID)
{
	Schedule* ptr = new Schedule[this->Count(2)];
	this->Select(ptr, 1, 0);
	for (int i = 0; i < (this->Count(2)); i++)
	{
		if (ptr[i].getScheduleID() == scheduleID) return i;
	}
	return -1;
}

bool ScheduleAccess::Update(int id, int choice)
{
	// 1. update movie_id
	// 2. update room_id
	// 3. update s.date
	// 4. update s.start
	// 5. update s.end
	Decoration d;
	string c_query = "update schedule set";
	int movie_id;
	int room_id;
	string schedule_date;
	string schedule_start;
	string schedule_end;
	cin.ignore();
	switch (choice)
	{
	case 1:
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\tMovie ID : ";
		d.setColor(14);
		cin >> movie_id;
		c_query += " movie_id = '" + to_string(movie_id);
		break;
	case 2:
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\tRoom ID : ";
		d.setColor(14);
		cin >> room_id;
		c_query += " room_id = '" + to_string(room_id);
		break;
	case 3:
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\tSchedule Date (yyyy-mm-dd) : ";
		d.setColor(14);
		getline(cin, schedule_date);
		c_query += " schedule_date = '" + schedule_date;
		break;
	case 4:
		cout << "\t\t\t\t\t\t\t\tSchedule Start (hh:mm:ss) : ";
		d.setColor(14);
		getline(cin, schedule_start);
		c_query += " schedule_start = '" + schedule_start;
		break;
	case 5:
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\tSchedule End (hh:mm:ss) : ";
		d.setColor(14);
		getline(cin, schedule_end);
		c_query += " schedule_end = '" + schedule_end;
		break;
	}
	c_query += "' where schedule_id = '" + to_string(id) + "'";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << endl << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		d.setColor(10);
		cout << endl << "\t\t\t\t\t\t\t\tSuccess!!" << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
	return true;
}

void ScheduleAccess::Show(int choice)
{
	Decoration d;
	if (this->Count(choice) == 0)
	{
		d.setColor(3);
		cout << "\t\t\t\t\t\t\t\tNo schedule founded !";
		return;
	}
	else {
		Schedule* ptr = new Schedule[this->Count(choice)];
		this->Select(ptr, choice, 0);
		MovieAccess movie;
		movie.Init();
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\t SHOWTIMES" << endl;
		d.setColor(11);
		cout << "\t\t\t\t" << left << setw(10) << "STT: ";
		cout << left << setw(35) << "Movie: ";
		cout << left << setw(20) << "Date: ";
		cout << left << setw(20) << "Time start: " << endl;
		for (int i = 0; i < this->Count(choice); i++)
		{
			d.setColor(15);
			cout << "\t\t\t\t" << setw(10) << i + 1;
			ptr[i].Show(movie);
		}
		movie.Close();
	}
}

bool ScheduleAccess::Delete(int stt)
{
	Decoration d;
	string id = to_string(this->getSchedule(stt).getScheduleID());
	string c_query = "delete from schedule where schedule_id = '" + id + "'";
	const char* q = c_query.c_str();
	d.setColor(12);
	cout << "\t\t\t\t\t\t\t\tAre you sure  ? (Y/N): ";
	d.setColor(15);
	char ans;
	cin >> ans;
	switch (ans)
	{
	case 'Y':
	case 'y':
		if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
		{
			d.setColor(4);
			cout << "\t\t\t\t\t\t\t\tSomething wrong, please try again !" << endl;
			Close();
			return false;
		}
		else
		{
			d.setColor(10);
			cout << "\t\t\t\t\t\t\t\tDelete success!!" << endl;
			return true;
		}
	default:
		break;
	}
	return true;
}

char* ScheduleAccess::getRoomName(int id)
{
	RoomAccess room;
	Room* ptr = new Room[room.Count()];
	room.Select(ptr);
	return ptr[room.Search(id)].getRoomName();
}