#include "sv.h"

sv::sv()
{
	this->connect.on();
}

sv::~sv()
{
	this->connect.dis();
}

void sv::Xuat()
{
	const char* a = "SELECT * FROM SV";
	this->connect.Xuat(a);
}

void sv::Nhap()
{
	string x, msv, ho, ten, ngaysinh, cmnd, diachi;
	bool gioitinh;

	cout << "Nhap masinhvien:";
	cin >> msv;
	cout << "Nhap Ho:";
	cin >> ho;
	cout << "Nhap ten:";
	cin >> ten;
	cout << "Ngay Sinh(Nam/Thang/Ngay):";
	cin >> ngaysinh;
	cout << "CMND:";
	cin >> cmnd;
	cout << "Dia Chi";
	cin >> diachi;
	cout << "Gioi Tinh:";
	cin >> gioitinh;
	string gt;
	if (gioitinh = 1) {
		gt = "1";
	}
	else {
		gt = "0";
	}
	x = "INSERT INTO SV VALUES('" + msv + "','" + ho + "','" + ten + "','" + ngaysinh + "','" + cmnd + "','" + diachi + "','" + gt + "')";
	this->connect.Nhap(x.c_str());
}
