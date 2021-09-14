#include"sv.h"
#include <iostream>
#include<conio.h>
int main()
{
	sv sv0;
	do {
		cout << "1.Xuat" << endl;
		cout << "2.Nhap" << endl;
		cout << "3.Thoat" << endl;
		int u = _getch();
		if (u == '1') {
			sv0.Xuat();
		}
		if (u == '2') {
			sv0.Nhap();
		}
		if (u == '3') {
			break;
		}
	} while (true);
}
