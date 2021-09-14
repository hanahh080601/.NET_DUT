#pragma once
#include <iostream>
#include "Decoration.h"
using namespace std;
#include <iomanip>
#include <windows.h>
#include <conio.h>
#include <string>
#include "AccountAccess.h"
class Account
{
private:
	int ID_number;
	char fullname[32];
	char username[32];
	char pwd[32];
	char email[32];
	char phone_number[50];
	int role;
	Decoration decoration;
public:
	Account();
	Account(int, char*, char*, char*, char*, char*, int);
	~Account();
	int getID();
	char* getFullname();
	char* getUsername();
	string getStrUsername();
	char* getPwd();
	char* getEmail();
	char* getPhone();
	int getRole();
	void setAccount();
	friend ostream& operator<<(ostream&, const Account);
	void Show();
};