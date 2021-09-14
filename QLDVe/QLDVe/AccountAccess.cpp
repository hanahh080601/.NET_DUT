#include "AccountAccess.h"
#include "Account.h"
#include <iomanip>
void AccountAccess::Select(Account*& acc)
{
	Decoration d;
	if (SQL_SUCCESS != SQLExecDirect(SQLStateHandle, (SQLWCHAR*)L"SELECT * FROM account", SQL_NTS))
	{
		d.setColor(4);
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !" << endl;
		Close();
	}
	else
	{
		SQLINTEGER PtrSQLVersion;
		int ID_number;
		char fullname[32];
		char username[32];
		char pwd[32];
		char email[32];
		char phone_number[50];
		int role;
		int i = 0;
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			SQLGetData(SQLStateHandle, 1, SQL_INTEGER, &ID_number, sizeof(ID_number), NULL);
			SQLGetData(SQLStateHandle, 2, SQL_CHAR, fullname, sizeof(fullname), NULL);
			SQLGetData(SQLStateHandle, 3, SQL_CHAR, username, sizeof(username), NULL);
			SQLGetData(SQLStateHandle, 4, SQL_CHAR, pwd, sizeof(pwd), NULL);
			SQLGetData(SQLStateHandle, 5, SQL_CHAR, email, sizeof(email), NULL);
			SQLGetData(SQLStateHandle, 6, SQL_CHAR, phone_number, sizeof(phone_number), NULL);
			SQLGetData(SQLStateHandle, 7, SQL_INTEGER, &role, sizeof(role), NULL);
			Account* temp = new Account(ID_number, fullname, username, pwd, email, phone_number, role);
			*(acc + i) = *temp;
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
}
int AccountAccess::CountRow()
{
	int i = 0;
	Decoration d;
	if (SQL_SUCCESS != SQLExecDirect(SQLStateHandle, (SQLWCHAR*)L"SELECT * FROM account", SQL_NTS))
	{
		d.setColor(14);
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !" << endl;
		Close();
	}
	else
	{
		while (SQLFetch(SQLStateHandle) == SQL_SUCCESS)
		{
			i++;
		}
	}
	SQLCancel(SQLStateHandle);
	return i;
}
int AccountAccess::Search(int id)
{
	Account* ptr = new Account[this->CountRow()];
	this->Select(ptr);
	for (int i = 0; i < this->CountRow(); i++)
	{
		if (ptr[i].getID() == id) return i;
	}
	return -1;
}
int AccountAccess::SearchName(string name)
{
	Account* ptr = new Account[this->CountRow()];
	this->Select(ptr);
	for (int i = 0; i < this->CountRow(); i++)
	{
		if (ptr[i].getStrUsername() == name) return i;

	}
	return -1;
}
char* AccountAccess::checkPwd(int index)
{
	Account* ptr = new Account[this->CountRow()];
	this->Select(ptr);
	return ptr[index].getPwd();
}
int AccountAccess::LastID() {
	Account* ptr = new Account[this->CountRow()];
	this->Select(ptr);
	return ptr[this->CountRow() - 1].getID();
}
void AccountAccess::Show()
{
	Decoration d;
	d.setColor(12);
	Account* ptr = new Account[this->CountRow()];
	this->Select(ptr);
	cout << "\t";
	cout << left << setw(8) << "STT";
	cout << left << setw(30) << "Fullname";
	cout << left << setw(30) << "Username";
	cout << left << setw(40) << "Email";
	cout << left << setw(24) << "Phonenumber";
	cout << right << setw(4) << "Role" << endl;
	for (int i = 0; i < this->CountRow(); i++)
	{
		d.setColor(11);
		cout << "\t" << i + 1 << ".\t";
		ptr[i].Show();
	}
	cout << endl << endl;
}
bool AccountAccess::Insert(Account acc)
{
	Decoration d;
	string c_query = "insert into account values ('";
	string t_ID = to_string(this->LastID() + 1);
	string t_fullname(acc.getFullname());
	string t_username(acc.getUsername());
	string t_pwd(acc.getPwd());
	string t_phone(acc.getPhone());
	string t_email(acc.getEmail());
	string t_role = to_string(acc.getRole());
	if (this->SearchName(t_username) != -1)
	{
		cout << "\t\t\t\t\t\t\t\tUser name is exist ! Enter to continue";
		_getch();
		return 0;
	}
	c_query += t_ID + "','" + t_fullname + "','" + t_username + "','" + t_pwd + "','" + t_phone + "','" + t_email + "','" + t_role + "')";
	const char* q = c_query.c_str();
	if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
	{
		d.setColor(4);
		cout << "\t\t\t\t\t\t\t\tAn error occurred, please try again !!" << endl;
		Close();
	}
	else
	{
		d.setColor(10);
		cout << "\t\t\t\t\t\t\t\tSuccess !" << endl;
		return true;
	}
	SQLCancel(SQLStateHandle);
	return false;
}
bool AccountAccess::Update()
{
	return 1;
}
bool AccountAccess::Delete(int stt)
{
	Decoration d;
	string id = to_string(this->getAccount(stt).getID());
	string c_query = "delete from account where ID_number = '" + id + "'";
	const char* q = c_query.c_str();
	d.setColor(12);
	cout << q;
	cout << "\t\t\t\t\t\t\t\tAre you sure  ? (Y/N): ";
	d.setColor(15);
	char ans;
	cin >> ans;
	switch (ans)
	{
	case 'Y':
	case 'y':
		if (SQL_SUCCESS != SQLExecDirectA(SQLStateHandle, (SQLCHAR*)q, SQL_NTS))
		{
			d.setColor(4);
			cout << "\t\t\t\t\t\t\t\tSomething wrong, please try again !" << endl;
			Close();
			return false;
		}
		else
		{
			d.setColor(10);
			cout << "\t\t\t\t\t\t\t\tDelete success!!" << endl;
			return true;
		}
	default:
		break;
	}
	return true;
}
Account AccountAccess::getAccount(int index)
{
	Account* ptr = new Account[this->CountRow()];
	this->Select(ptr);
	return ptr[index];
}