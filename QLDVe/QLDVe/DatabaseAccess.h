#include <iostream>
#include <Windows.h>
#include <sql.h>
#include <sqlext.h>
#include <sqltypes.h>
#include <string>
#include "Decoration.h"
#pragma once

using namespace std;

class DatabaseAccess
{
protected:
#define SQL_RESULT_LEN 240
#define SQL_RETURN_CODE_LEN 1024
#define MAX_ROW_SHOW 10
	SQLHANDLE SQLConnectionHandle;
	SQLHANDLE SQLStateHandle;
	SQLHANDLE SQLEnvironmentHandle;
	SQLWCHAR retConString[SQL_RETURN_CODE_LEN];
public:
	bool Init();
	void Select();
	virtual bool Insert();
	virtual bool Delete();
	virtual bool Update();
	virtual void Show();
	void Close();
};
