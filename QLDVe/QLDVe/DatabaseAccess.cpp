#include "DatabaseAccess.h"
bool DatabaseAccess::Init()
{
	Decoration d;
	//set SQLHandle = NULL
	SQLStateHandle = NULL;
	SQLConnectionHandle = NULL;
	//Allocates Handle
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &SQLEnvironmentHandle))
		Close();
	if (SQL_SUCCESS != SQLSetEnvAttr(SQLEnvironmentHandle, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0))
		Close();
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_DBC, SQLEnvironmentHandle, &SQLConnectionHandle))
		Close();
	d.setColor(14);
	cout << "\t\t\t\t\t\t\tPlease wait for a second, program is processing..." << endl;
	/*Data Source = DESKTOP - S2SLR6P; Initial Catalog = QlyDatVePhim; Persist Security Info = True; User ID = sa*/
	switch (SQLDriverConnect(SQLConnectionHandle, NULL, (SQLWCHAR*)L"DRIVER={SQL Server}; Server=DESKTOP-1QK42IB\\SQLEXPRESS;Database=DALT2;Trusted_Connection=True;",
		SQL_NTS,
		retConString,
		1024,
		NULL,
		SQL_DRIVER_NOPROMPT)) {

	case SQL_SUCCESS:
		/*cout << "Ket noi thanh cong!!" << endl;*/
		break;

	case SQL_SUCCESS_WITH_INFO:
		/*	cout << "Ket noi thanh cong!!" << endl;*/
		break;

	case SQL_INVALID_HANDLE:
		d.setColor(4);
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
		break;

	case SQL_ERROR:
		d.setColor(4);
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
		break;
	default:
		break;
	}
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, SQLConnectionHandle, &SQLStateHandle))
		Close();
	d.setColor(15);
	return true;
}

void DatabaseAccess::Close()
{
	SQLFreeHandle(SQL_HANDLE_STMT, SQLStateHandle);
	SQLDisconnect(SQLConnectionHandle);
	SQLFreeHandle(SQL_HANDLE_DBC, SQLConnectionHandle);
	SQLFreeHandle(SQL_HANDLE_ENV, SQLEnvironmentHandle);
}
void DatabaseAccess::Select()
{}
void DatabaseAccess::Show()
{}
bool  DatabaseAccess::Update()
{
	return 1;
}
bool DatabaseAccess::Delete()
{
	return 1;
}
bool DatabaseAccess::Insert()
{
	return 1;
}