#include "Booking.h"

Booking::Booking(int bookingID, int accountID, int scheduleID, int seatID)
{
	this->booking_id = bookingID;
	this->account_id = accountID;
	this->schedule_id = scheduleID;
	this->seat_id = seatID;
}

Booking::~Booking()
{}

int Booking::getBookingID()
{
	return this->booking_id;
}

int Booking::getAccountID()
{
	return this->account_id;
}

int Booking::getScheduleID()
{
	return this->schedule_id;
}

int Booking::getSeatID()
{
	return this->seat_id;
}

void Booking::setBooking(int id, int schedule, int seat)
{
	this->account_id = id;
	this->schedule_id = schedule;
	this->seat_id = seat;
}
string Booking::insertQuery()
{
	string t_query;
	string t_account_id = to_string(this->account_id);
	string t_schedule_id = to_string(this->schedule_id);
	string t_seat_id = to_string(this->seat_id);
	t_query = t_account_id + "','" + t_schedule_id + "','" + t_seat_id + "')";
	return t_query;
}

void Booking::Show()
{
	Decoration d;
	d.setColor(12);
	cout << "\tCustomer: ";
	d.setColor(15);
	cout << this->account_id;
	d.setColor(12);
	cout << "\t\tSchedule: ";
	d.setColor(15);
	cout << this->schedule_id << "   ";
	d.setColor(12);
	cout << "\t\tSeat: ";
	d.setColor(15);
	cout << this->seat_id << endl;
}
