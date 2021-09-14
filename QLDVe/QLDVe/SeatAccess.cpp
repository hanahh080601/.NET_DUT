#include "SeatAccess.h"
#include <iomanip>

void SeatAccess::Select(Seat*& seat, int choice, int room)
{
	// 1 : all seat , choice bằng 1 thì room bằng -1
	// 2 :seat của room 

	int i = 0;
	string c_query = "";
	switch (choice)
	{
	case 1:
		c_query = "select * from seat";
		break;
	case 2:
		c_query = "select * from seat where room_id = " + to_string(room);
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
		int seat_id;
		int seatType_id;
		int room_id;
		char seat_row[5];
		char seat_number[5];
		int seat_status;
		int i = 0;
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			SQLGetData(SQLStateHandle, 1, SQL_INTEGER, &seat_id, sizeof(seat_id), NULL);
			SQLGetData(SQLStateHandle, 2, SQL_INTEGER, &seatType_id, sizeof(seatType_id), NULL);
			SQLGetData(SQLStateHandle, 3, SQL_INTEGER, &room_id, sizeof(room_id), NULL);
			SQLGetData(SQLStateHandle, 4, SQL_CHAR, seat_row, sizeof(seat_row), NULL);
			SQLGetData(SQLStateHandle, 5, SQL_CHAR, seat_number, sizeof(seat_number), NULL);
			SQLGetData(SQLStateHandle, 6, SQL_INTEGER, &seat_status, sizeof(seat_status), NULL);

			Seat* temp = new Seat(seat_row, seat_number, seat_id, seatType_id, room_id, seat_status);
			*(seat + i) = *temp;
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
}

void SeatAccess::Show(int room)
{
	Decoration d;
	d.setColor(15);
	Seat* ptr = new Seat[this->Count(2, room)];
	this->Select(ptr, 2, room);
	d.setColor(10);
	cout << endl;
	cout << endl << "\t\t\t\t\t\t\t_______________SCREEN_______________" << endl;
	cout << endl;
	cout << "\t\t\t\t";
	int available = 0;
	for (int i = 0; i < this->Count(2, room); i++)
	{

		if ((i % this->Count(4, room)) == 0)
		{
			cout << endl;
			cout << "\t\t\t\t";
		}
		d.setColor(3);
		cout << setw(3) << i + 1;
		d.setColor(15);
		cout << ptr[i].getSeatRow() << ptr[i].getSeatNumber();
		if (ptr[i].getStatus() == 0)
		{
			if (ptr[i].getSeatType() == 2) {
				d.setColor(6);
			}
			else {

				d.setColor(14);
			}
			cout << " O \t";
			available++;
		}
		else
		{
			d.setColor(4);
			cout << " X \t";
		}
	}
	cout << "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" << available << "/" << this->Count(2, room);
	cout << endl;
}

int SeatAccess::Count(int choice, int roomID)
{

	// 1: đếm full seat
	// 2: đếm seat của room
	// 3: đếm số hàng
	// 4 : đếm số cột
	int i = 0;
	string c_query = "";
	switch (choice)
	{
	case 1:
		c_query = "select  * from seat ";
		break;
	case 2:
		c_query = "select  * from seat where room_id = " + to_string(roomID);

		break;
	case 3:
		c_query = "select distinct seat_row from seat where room_id = " + to_string(roomID);
		break;

	case 4:
		c_query = "select distinct seat_number from seat where room_id = " + to_string(roomID);
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
int SeatAccess::Search(int seatID, int roomID)
{
	Seat* ptr = new Seat[this->Count(3, roomID)];
	this->Select(ptr, 1, -1);
	for (int i = 0; i < (this->Count(3, roomID)); i++)
	{
		if (ptr[i].getSeatID() == seatID) return i;
	}
	return -1;
}
bool SeatAccess::Insert()
{
	string c_query = "insert into seat values ('";
	Seat seat;
	seat.setSeat();
	string t_ID = to_string(this->LastID() + 1);
	c_query += t_ID + "','";
	c_query += seat.insertQuery();
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		cout << c_query;
		cout << "Success !" << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
}
int SeatAccess::LastID() {
	Seat* ptr = new Seat[this->Count(1, -1)];
	this->Select(ptr, 1, -1);
	return ptr[this->Count(1, -1) - 1].getSeatID();
}
Seat SeatAccess::getSeat(int index, int room)
{
	Seat* ptr = new Seat[this->Count(2, room)];
	this->Select(ptr, 2, room);
	return ptr[index];
}
bool SeatAccess::Update(int id, int type, int room)
{
	//1. seatType_id;
	//2. room_id;
	//3. seat_row[5];
	//4. seat_number[5];
	Decoration d;
	string c_query = "update seat set";
	string seat_row;
	string seat_number;
	int room_id;
	int seat_type_id;
	string movie_genre;
	cin.ignore();
	switch (type)
	{
	case 1:
		d.setColor(12);
		cout << "Seat Type ID : ";
		cout << " 1.Normal - 2.Couple - 3. VIP : ";
		d.setColor(14);
		cin >> seat_type_id;
		c_query += " seat_type_id = '" + to_string(seat_type_id);
		break;
	case 2:
		d.setColor(12);
		cout << "Seat Row : ";
		d.setColor(14);
		getline(cin, seat_row);
		c_query += " seat_row = '" + seat_row;
		break;
	case 3:
		d.setColor(12);
		cout << "Seat Number : ";
		d.setColor(14);
		getline(cin, seat_number);
		c_query += " seat_number = '" + seat_number;
		break;
	case 4:
		c_query += " seat_status = '1";
		break;
	}
	if (type == 4) c_query += "'where seat_id = '" + to_string(id) + "'";
	else c_query += "'where seat_id = '" + to_string(id) + "' and room_id = '" + to_string(room) + "'";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << endl << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		return true;
	}
	SQLCancel(SQLStateHandle);
	return true;
}

bool SeatAccess::Delete()
{
	return 0;
}
