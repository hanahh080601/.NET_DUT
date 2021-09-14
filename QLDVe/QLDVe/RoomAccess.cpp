#include "RoomAccess.h"
#include "SeatAccess.h"
#include  <iomanip>

void RoomAccess::Select(Room*& room)
{
	int i = 0;
	string c_query;
	c_query = "select * from room";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		SQLINTEGER PtrSQLVersion;
		int room_id;
		char room_name[5];
		int i = 0;
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			SQLGetData(SQLStateHandle, 1, SQL_INTEGER, &room_id, sizeof(room_id), NULL);
			SQLGetData(SQLStateHandle, 2, SQL_CHAR, room_name, sizeof(room_name), NULL);
			Room* temp = new Room(room_name, room_id);
			*(room + i) = *temp;
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
}

int RoomAccess::Count()
{
	int i = 0;
	string c_query;
	c_query = "select * from room";
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

void RoomAccess::Show(int choice, int id)
{
	// 1 - 0: show hết các phòng
	// 2 - id: show seat theo phòng
	Room* ptr = new Room[this->Count()];
	SeatAccess seat_access;
	seat_access.Init();
	switch (choice)
	{
	case 1:
		this->Select(ptr);
		for (int i = 0; i < this->Count(); i++)
		{
			cout << "\t\t\t\t\t\t\t\t" << i + 1 << ".\t";
			ptr[i].Show();
		}
		if (this->Count() == 0)
		{
			cout << endl << "\t\t\t\t\t\t\t\tSorry,no room founded!" << endl;
		}
		break;
	case 2:
		seat_access.Show(id);
		seat_access.Close();
		break;
	}

}

bool RoomAccess::Insert()
{
	string c_query = "insert into room values ('";
	Room room;
	room.setRoom();
	string t_ID = to_string(this->LastID() + 1);
	c_query += t_ID + "','";
	c_query += room.insertQuery();
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		cout << "\t\t\t\t\t\t\t\tSuccess!! " << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
}

bool RoomAccess::Update(int id)
{
	string c_query = "update room set";
	string room_name;
	cout << "\t\t\t\t\t\t\t\tEnter room name :";
	cin.ignore();
	getline(cin, room_name);
	c_query += " room_name = '" + room_name;
	c_query += "'where room_id = '" + to_string(id) + "'";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		cout << endl << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		cout << endl << "\t\t\t\t\t\t\t\tSuccess!! " << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
	return true;
}

bool RoomAccess::Delete()
{
	return 0;
}

int RoomAccess::Search(int id)
{
	Room* ptr = new Room[this->Count()];
	this->Select(ptr);
	for (int i = 0; i < this->Count(); i++)
	{
		if (ptr[i].getRoomID() == id) return i;
	}
	return -1;
}

Room RoomAccess::getRoom(int index)
{
	Room* ptr = new Room[this->Count()];
	this->Select(ptr);
	return ptr[index];
}

int RoomAccess::LastID()
{
	Room* ptr = new Room[this->Count()];
	this->Select(ptr);
	return ptr[this->Count() - 1].getRoomID();
}