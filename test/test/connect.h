#pragma once
#include <iostream>
#include <windows.h>
#include <sqlext.h>
#include <sqltypes.h>
#include <sql.h>
#include <iomanip>

using namespace std;
class connects
{
private:
	SQLHANDLE SQLEnvHandle;
	SQLHANDLE SQLConnectionHandle;
	SQLHANDLE SQLStatementHandle;
	SQLRETURN retCode;
public:
	connects();
	~connects();
	void on();
	void dis();
	void Xuat(const char*);
	void Nhap(const char*);
	void Update(const char*);
};


