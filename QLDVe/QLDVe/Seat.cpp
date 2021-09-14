#include "Seat.h"

Seat::Seat()
{
	this->seat_id = 0;
	this->seatType_id = 0;
	this->room_id = 0;
	strcpy_s(this->seat_row, 5, "");
	strcpy_s(this->seat_number, 5, "");
	this->seat_status = 0;
}

Seat::Seat(char* row, char* number, int ID, int seatTypeID, int roomID, int status)
	:seat_id(ID), seatType_id(seatTypeID), room_id(roomID), seat_status(status)
{
	strcpy_s(this->seat_row, 5, row);
	strcpy_s(this->seat_number, 5, number);
}

Seat::~Seat()
{}

int Seat::getSeatID()
{
	return this->seat_id;
}

int Seat::getStatus()
{
	return this->seat_status;
}

char* Seat::getSeatRow()
{
	return this->seat_row;
}
char* Seat::getSeatNumber()
{
	return this->seat_number;
}
int Seat::getSeatType()
{
	return this->seatType_id;
}
void Seat::setSeat()
{
	Decoration d;
	d.setColor(12);
	cout << "Seat Type ID : ";
	cout << " 1.Normal - 2.Couple - 3. VIP : ";
	d.setColor(14);
	cin >> this->seatType_id;
	d.setColor(12);
	cout << "Room ID: ";
	d.setColor(14);
	cin >> this->room_id;
	d.setColor(12);
	cout << "Seat Row : ";
	d.setColor(14);
	cin.ignore();
	cin.getline(this->seat_row, 5);
	d.setColor(12);
	cout << "Seat Number : ";
	d.setColor(14);
	cin.getline(this->seat_number, 5);
	this->seat_status = 0;
}
string Seat::insertQuery()
{
	string t_query;
	string t_seat_id = to_string(seat_id);
	string t_seatType_id = to_string(seatType_id);
	string t_room_id = to_string(room_id);
	string t_seatStatus = to_string(seat_status);
	string t_seat_row(seat_row);
	string t_seat_number(seat_number);
	cout << "seat number : " << t_seat_number;
	t_query = t_seatType_id + "','" + t_room_id + "','" + t_seat_row + "','" + t_seat_number + "','" + t_seatStatus + "')";
	cout << "t_query" << t_query;
	return t_query;
}

void Seat::Show()
{
	RoomAccess room;
	Room* ptr = new Room[room.Count()];
	room.Select(ptr);
	cout << left << setw(4) << this->seat_id;
	cout << left << setw(4) << this->seatType_id;
	cout << left << setw(4) << ptr[room.Search(this->room_id)].getRoomName();
	cout << left << setw(4) << this->seat_row;
	cout << left << setw(4) << this->seat_number;
	cout << right << setw(4) << this->seat_status << endl;
}
