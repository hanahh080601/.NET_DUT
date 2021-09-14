#include "connect.h"

connects::connects()
{
	this->SQLEnvHandle = NULL;
	this->SQLConnectionHandle = NULL;
	this->SQLStatementHandle = NULL;
	this->retCode = 0;
}

connects::~connects()
{
}

void connects::on()
{
	do {
		//Important!!
		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &SQLEnvHandle))
			// Allocates the environment	
			break;


		if (SQL_SUCCESS != SQLSetEnvAttr(SQLEnvHandle, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0))
			// Sets attributes that govern aspects of environments
			break;

		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_DBC, SQLEnvHandle, &SQLConnectionHandle))
			// Allocates the connection
			break;

		//if (SQL_SUCCESS != SQLSetConnectAttr(SQLConnectionHandle, SQL_LOGIN_TIMEOUT, (SQLPOINTER)5, 0))
			// Sets attributes that govern aspects of connections
			//break;
		//
		SQLWCHAR retConString[1024]{}; // Conection string
		switch (SQLDriverConnect(SQLConnectionHandle, NULL, (SQLWCHAR*)"DRIVER={SQL Server}; Server=DESKTOP-1QK42IB\\SQLEXPRESS;Database=SV;Trusted_Connection=True; MultipleActiveResultSets = True", SQL_NTS, retConString, 1024, NULL, SQL_DRIVER_NOPROMPT)) {
			// Establishes connections to a driver and a data source
		case SQL_SUCCESS:
			break;
		case SQL_SUCCESS_WITH_INFO:
			break;
		case SQL_NO_DATA_FOUND:
			//this->showSQLError(SQL_HANDLE_DBC, SQLConnectionHandle);
			retCode = -1;
			break;
		case SQL_INVALID_HANDLE:
			//this->showSQLError(SQL_HANDLE_DBC, SQLConnectionHandle);
			retCode = -1;
			break;
		case SQL_ERROR:
			//this->showSQLError(SQL_HANDLE_DBC, SQLConnectionHandle);
			retCode = -1;
			break;
		default:
			break;
		}

		if (retCode == -1)
			break;

		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, SQLConnectionHandle, &SQLStatementHandle))
			// Allocates the statement
			break;

	} while (FALSE);
}

void connects::dis()
{
	SQLFreeHandle(SQL_HANDLE_STMT, SQLStatementHandle);
	SQLDisconnect(SQLConnectionHandle);
	SQLFreeHandle(SQL_HANDLE_DBC, SQLConnectionHandle);
	SQLFreeHandle(SQL_HANDLE_ENV, SQLEnvHandle);
}

void connects::Xuat(const char* sv0)
{
	const char* SQLQuery = sv0;


	if (SQL_SUCCESS != SQLExecDirect(this->SQLStatementHandle, (SQLWCHAR*)SQLQuery, SQL_NTS)) {
		// Executes a preparable statement
		//this->showSQLError(SQL_HANDLE_STMT, this->SQLStatementHandle);
	}
	else {
		char MSV[100]{};
		char Ho[100]{};
		char Ten[100]{};
		char NgaySinh[100]{};
		char CMND[100]{};
		char Diachi[100]{};
		bool gioitinh = false;


		while (SQLFetch(this->SQLStatementHandle) == SQL_SUCCESS)
		{
			SQLGetData(this->SQLStatementHandle, 1, SQL_C_DEFAULT, &MSV, sizeof(MSV), NULL);
			SQLGetData(this->SQLStatementHandle, 2, SQL_C_DEFAULT, &Ho, sizeof(Ho), NULL);
			SQLGetData(this->SQLStatementHandle, 3, SQL_C_DEFAULT, &Ten, sizeof(Ten), NULL);
			SQLGetData(this->SQLStatementHandle, 4, SQL_C_DEFAULT, &NgaySinh, sizeof(NgaySinh), NULL);
			SQLGetData(this->SQLStatementHandle, 5, SQL_C_DEFAULT, &CMND, sizeof(CMND), NULL);
			SQLGetData(this->SQLStatementHandle, 6, SQL_C_DEFAULT, &Diachi, sizeof(Diachi), NULL);
			SQLGetData(this->SQLStatementHandle, 7, SQL_C_DEFAULT, &gioitinh, sizeof(gioitinh), NULL);
			cout << MSV << "__" << Ho << " " << Ten << "__" << NgaySinh << "__" << CMND << "__" << Diachi << "__" << gioitinh << endl;
		}
	}
}

void connects::Nhap(const char* sv0)
{
	const char* SQLQuery = sv0;
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, SQLConnectionHandle, &SQLStatementHandle))
		int t = 0;


	if (SQL_SUCCESS != SQLExecDirect(SQLStatementHandle, (SQLWCHAR*)SQLQuery, SQL_NTS)) {
		// Executes a preparable statement
		//showSQLError(SQL_HANDLE_STMT, SQLStatementHandle);

	}
	else {
		cout << "Them Thanh Cong!" << endl;
	}
}

void connects::Update(const char*sv0)
{
	const char* SQLQuery = sv0;
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, SQLConnectionHandle, &SQLStatementHandle))
		int t = 0;


	if (SQL_SUCCESS != SQLExecDirect(SQLStatementHandle, (SQLWCHAR*)SQLQuery, SQL_NTS)) {
		// Executes a preparable statement
		//showSQLError(SQL_HANDLE_STMT, SQLStatementHandle);

	}
	else {
		cout << "Update Thanh Cong!" << endl;
	}
}
