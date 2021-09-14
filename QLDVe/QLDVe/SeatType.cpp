#include "SeatType.h"

SeatType::SeatType()
{
	this->seat_type_id = 0;
	this->seat_price = 45000;
	strcpy_s(this->seat_type, 15, "");
}

SeatType::SeatType(char* seatType, int seatTypeID, int seatPrice)
	:seat_type_id(seatTypeID), seat_price(seatPrice)
{
	strcpy_s(this->seat_type, 15, seatType);
}

SeatType::~SeatType()
{}

int SeatType::getSeatTypeID()
{
	return this->seat_type_id;
}

int SeatType::getSeatPrice()
{
	return this->seat_price;
}

char* SeatType::getSeatTypeName()
{
	return this->seat_type;
}
void SeatType::setSeatType() {
	Decoration d;
	d.setColor(12);
	cout << "Seat Type:";
	d.setColor(14);
	cin.ignore();
	cin.getline(this->seat_type, 15);
	d.setColor(12);
	cout << "Seat Price :";
	d.setColor(14);
	cin >> this->seat_price;
}
string SeatType::insertQuery()
{
	string t_query;
	string t_seatTypeName(this->seat_type);
	string t_seatPrice = to_string(this->seat_price);
	t_query = t_seatTypeName + "','" + t_seatPrice + "')";
	return t_query;
}

void SeatType::Show()
{
	Decoration d;
	d.setColor(14);
	cout << left << setw(15) << this->seat_type;
	cout << right << setw(10) << long(this->seat_price);
	cout << endl;
}