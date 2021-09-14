#include "BookingAccess.h"
#include <iomanip>

void BookingAccess::Select(Booking*& bk)
{
	Decoration d;
	int i = 0;
	string c_query;
	c_query = "select * from booking";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		d.setColor(4);
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		SQLINTEGER PtrSQLVersion;
		int booking_id;
		int account_id;
		int schedule_id;
		int seat_id;
		int i = 0;
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			SQLGetData(SQLStateHandle, 1, SQL_INTEGER, &booking_id, sizeof(booking_id), NULL);
			SQLGetData(SQLStateHandle, 2, SQL_INTEGER, &account_id, sizeof(account_id), NULL);
			SQLGetData(SQLStateHandle, 3, SQL_INTEGER, &schedule_id, sizeof(schedule_id), NULL);
			SQLGetData(SQLStateHandle, 4, SQL_INTEGER, &seat_id, sizeof(seat_id), NULL);
			Booking* temp = new Booking(booking_id, account_id, schedule_id, seat_id);
			*(bk + i) = *temp;
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
}

int BookingAccess::Count()
{
	Decoration d;
	int i = 0;
	string c_query;
	c_query = "select * from booking";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		d.setColor(4);
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

int BookingAccess::Search(int account_id)
{
	Booking* ptr = new Booking[this->Count()];
	this->Select(ptr);
	for (int i = 0; i < this->Count(); i++)
	{
		if (ptr[i].getAccountID() == account_id) return i;
	}
	return -1;
}

void BookingAccess::Show(int choice, int id)
{
	Decoration d;
	Booking* ptr = new Booking[this->Count()];
	const char* q;
	SQLINTEGER PtrSQLVersion;
	char movie_name[40];
	char shedule_date[15];
	char shedule_start[10];
	char room_name[5];
	char seat_row[5];
	char seat_number[5];
	int seat_price;
	switch (choice)
	{
	case 1:
		this->Select(ptr);
		for (int i = 0; i < this->Count(); i++)
		{
			d.setColor(11);
			cout << "\t\t\t\t\t\t" << i + 1 << ".\t";
			ptr[i].Show();
		}
		if (this->Count() == 0)
		{
			d.setColor(3);
			cout << endl << "Sorry,no booking founded!" << endl;
		};
		break;
	case 2:
		string c_query = "select movie_name, schedule_date, schedule_start, room_name, seat_row, seat_number, seat_price from booking";
		c_query += " inner join seat on booking.seat_id = seat.seat_id";
		c_query += " inner join seatType on seat.seat_type_id = seatType.seat_type_id";
		c_query += " inner join schedule on booking.schedule_id =  schedule.schedule_id ";
		c_query += " inner join room on room.room_id=  schedule.room_id ";
		c_query += " inner join movie on movie.movie_id = schedule.movie_id ";
		c_query += " where booking_id = " + to_string(id);
		q = c_query.c_str();
		if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
		{
			cout << "Something wrong. Please try again !!" << endl;
			Close();
		}
		else
		{
			while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
			{
				SQLGetData(SQLStateHandle, 1, SQL_CHAR, movie_name, sizeof(movie_name), NULL);
				SQLGetData(SQLStateHandle, 2, SQL_CHAR, shedule_date, sizeof(shedule_date), NULL);
				SQLGetData(SQLStateHandle, 3, SQL_CHAR, shedule_start, sizeof(shedule_start), NULL);
				SQLGetData(SQLStateHandle, 4, SQL_CHAR, room_name, sizeof(room_name), NULL);
				SQLGetData(SQLStateHandle, 5, SQL_CHAR, seat_row, sizeof(seat_row), NULL);
				SQLGetData(SQLStateHandle, 6, SQL_CHAR, seat_number, sizeof(seat_number), NULL);
				SQLGetData(SQLStateHandle, 7, SQL_INTEGER, &seat_price, sizeof(seat_price), NULL);
				d.setColor(12);
				cout << endl << "\t\t\t\t\t\t\t\t____________TICKET____________ " << endl << endl;
				d.setColor(11);
				cout << "\t\t\t\t\t\t\t\tMovie : ";
				d.setColor(14);
				cout << movie_name << endl;
				d.setColor(11);
				cout << "\t\t\t\t\t\t\t\tDate : ";
				d.setColor(14);
				cout << shedule_date << endl;
				d.setColor(11);
				cout << "\t\t\t\t\t\t\t\tTime : ";
				d.setColor(14);
				cout << shedule_start << endl;
				d.setColor(11);
				cout << "\t\t\t\t\t\t\t\tRoom : ";
				d.setColor(14);
				cout << room_name << endl;
				d.setColor(11);
				cout << "\t\t\t\t\t\t\t\tSeat : ";
				d.setColor(14);
				cout << seat_row << seat_number << endl;
				d.setColor(11);
				cout << "\t\t\t\t\t\t\t\tPrice : ";
				d.setColor(14);
				cout << seat_price << endl << endl;
				d.setColor(12);
				cout << "\t\t\t\t\t\t\t\t__________Thanh you !__________" << endl << endl;
			}
		}
		SQLCancel(SQLStateHandle);
		break;
	};
}

bool BookingAccess::Update()
{
	return 0;
}
bool BookingAccess::Insert(Booking& booking)
{
	Decoration d;
	string c_query = "insert into booking values ('";
	int id = this->LastID() + 1;
	c_query += to_string(id) + "','";
	c_query += booking.insertQuery();
	const char* q = c_query.c_str();
	SeatAccess seat;
	seat.Init();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		d.setColor(4);
		cout << "Something wrong. Please try again !!" << endl;
		Close();
	}
	else
	{
		seat.Update(booking.getSeatID(), 4, 0);
		seat.Close();
		system("cls");
		d.setColor(10);
		cout << "\t\t\t\t\t\t\t\t Booking success ! " << endl;
		this->Show(2, id);
		return true;
	}
	SQLCancel(SQLStateHandle);
	return 1;
}
int BookingAccess::LastID()
{
	if (this->Count() == 0) return 0;
	else {
		Booking* ptr = new Booking[this->Count()];
		this->Select(ptr);
		return ptr[this->Count() - 1].getBookingID();
	}
}
bool BookingAccess::Delete()
{
	return 0;
}