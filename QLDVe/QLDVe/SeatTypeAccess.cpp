#include "SeatTypeAccess.h"
#include <iomanip>

void SeatTypeAccess::Select(SeatType*& seatType)
{
	int i = 0;
	string c_query;
	c_query = "select * from seatType";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		SQLINTEGER PtrSQLVersion;
		int seat_type_id;
		char seat_type[15];
		int seat_price;
		int i = 0;
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			SQLGetData(SQLStateHandle, 1, SQL_INTEGER, &seat_type_id, sizeof(seat_type_id), NULL);
			SQLGetData(SQLStateHandle, 2, SQL_CHAR, seat_type, sizeof(seat_type), NULL);
			SQLGetData(SQLStateHandle, 3, SQL_INTEGER, &seat_price, sizeof(seat_price), NULL);
			SeatType* temp = new SeatType(seat_type, seat_type_id, seat_price);
			*(seatType + i) = *temp;
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
}

int SeatTypeAccess::Count()
{
	int i = 0;
	string c_query;
	c_query = "select * from seatType";
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

bool SeatTypeAccess::Insert()
{
	Decoration d;
	string c_query = "insert into seatType values ('";
	string seat_type_id = to_string(this->LastID() + 1);
	c_query += seat_type_id + "','";
	SeatType seat_type;
	seat_type.setSeatType();
	c_query += seat_type.insertQuery();
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		d.setColor(10);
		cout << "\t\t\t\t\t\t\t\tSuccess!";
	}
	SQLCancel(SQLStateHandle);
	return 1;
}
int SeatTypeAccess::LastID() {
	SeatType* ptr = new SeatType[this->Count()];
	this->Select(ptr);
	return ptr[this->Count() - 1].getSeatTypeID();
}
bool SeatTypeAccess::Update(int choice, int id)
{

	//1. seat Type name;
	//2. seat type price;
	Decoration d;
	string c_query = "update seatType set";
	string seat_type;
	int seat_price;
	switch (choice)
	{
	case 1:
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\tSeat Type : ";
		cin.ignore();
		d.setColor(14);
		getline(cin, seat_type);
		c_query += " seat_type = '" + seat_type;
		break;
	case 2:
		d.setColor(12);
		cout << "\t\t\t\t\t\t\t\tSeat Price : ";
		d.setColor(14);
		cin >> seat_price;
		c_query += " seat_price = '" + to_string(seat_price);
		break;
	}
	c_query += "'where seat_type_id = '" + to_string(id) + "'";
	const char* q = c_query.c_str();
	cout << q;
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << endl << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		d.setColor(10);
		cout << endl << "\t\t\t\t\t\t\t\tSuccess !" << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
	return true;
}

bool SeatTypeAccess::Delete()
{
	return 0;
}

void SeatTypeAccess::Show()
{
	Decoration d;
	SeatType* ptr = new SeatType[this->Count()];
	this->Select(ptr);

	for (int i = 0; i < this->Count(); i++)
	{
		d.setColor(11);
		cout << "\t\t\t\t\t\t\t" << i + 1 << ".";
		d.setColor(14);
		ptr[i].Show();
	}
	if (this->Count() == 0)
	{
		d.setColor(3);
		cout << endl << "\t\t\t\t\t\t\t\tSorry,no seat type founded!" << endl;
	}
}
SeatType SeatTypeAccess::getSeatType(int index)
{
	SeatType* ptr = new SeatType[this->Count()];
	this->Select(ptr);
	return ptr[index];
}