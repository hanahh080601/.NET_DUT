#pragma once
#include "DatabaseAccess.h"
#include "Seat.h"
class SeatAccess :
	public DatabaseAccess
{
	Decoration decoration;
public:
	void Select(Seat*&, int, int); // đổ dữ liệu full seat về
	void Show(int); // show seat row vs number vs loại seat
	int Count(int, int); // đếm hàng ghế theo phòng
	bool Insert(); // thêm seat 
	bool Update(int, int, int); // chỉnh sửa seatType của seat
	bool Delete(); // xóa seat
	int Search(int, int);
	Seat getSeat(int, int);
	int LastID();
};