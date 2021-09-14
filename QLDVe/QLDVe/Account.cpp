#include "Account.h"


Account::Account()
{
    ID_number = 0;
    strcpy_s(fullname, 32, "");
    strcpy_s(username, 32, "");
    strcpy_s(pwd, 32, "");
    strcpy_s(email, 32, "");
    strcpy_s(phone_number, 50, "");
    role = 0;
}
Account::Account(int ID, char* fullname, char* username, char* pwd, char* email, char* phone, int role)
    :ID_number(ID), role(role)
{
    strcpy_s(this->fullname, 32, fullname);
    strcpy_s(this->username, 32, username);
    strcpy_s(this->pwd, 32, pwd);
    strcpy_s(this->email, 32, email);
    strcpy_s(this->phone_number, 50, phone);
}
Account::~Account()
{
}
int Account::getID()
{
    return this->ID_number;
}
char* Account::getUsername()
{
    return this->username;
}
string Account::getStrUsername() {
    char* User = this->username;
    for (int i = strlen(User) - 1; i >= 0; i--) {
        if (User[i] != ' ') {
            User[i + 1] = '\0';
            break;
        }
    }
    string temp(User);
    return temp;
}
char* Account::getFullname()
{
    return this->fullname;
}
char* Account::getEmail()
{
    return this->email;
}
char* Account::getPhone()
{
    return this->phone_number;
}
char* Account::getPwd()
{
    char* pwd = this->pwd;
    for (int i = strlen(pwd) - 1; i >= 0; i--) {
        if (pwd[i] != ' ') {
            pwd[i + 1] = '\0';
            break;
        }
    }
    return pwd;
}
int Account::getRole()
{
    return this->role;
}
void Account::setAccount()
{
    Decoration d;
    char ch;
    bool validate = false;
    d.setColor(12);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tFullname : ";
    cin.ignore();
    d.setColor(15);
    cin.getline(fullname, 32);

Username:
    d.setColor(12);
    cout << "\t\t\t\t\t\t\t\tUsername : ";
    d.setColor(15);
    cin.getline(username, 32);
    for (int i = 0; i < strlen(this->username); i++)
    {
        if (this->username[i] == ' ')
        {
            d.setColor(14);
            cout << "\t\t\t\t\t\tSpace not recommend in username ! Enter another username " << endl;
            goto Username;
        }
    }
Email:
    int validate_email = 0;
    d.setColor(12);
    cout << "\t\t\t\t\t\t\t\tEmail : ";
    d.setColor(15);
    cin.getline(email, 32);
    for (int i = 0; i < strlen(this->email); i++)
    {
        if (this->email[i] == '@')
        {
            validate_email = 1;
            break;
        }
    }
    if (validate_email == 0)
    {
        d.setColor(14);
        cout << "\t\t\t\t\t\tEmail is in wrong form  ! Enter email again " << endl;
        goto Email;
    }
    d.setColor(12);
    cout << "\t\t\t\t\t\t\t\tPhone number : ";
    d.setColor(15);
    cin.getline(phone_number, 50);
    d.setColor(12);
    cout << "\t\t\t\t\t\t\t\tPassword : ";
    d.setColor(15);
    string pass;
    for (char c; c = _getch(); )
    {
        if (c == 13 || c == '\r') // enter 
        {
            cout << "\n";
            break;
        }
        else
        {
            if (c == 8) // backspace
            {
                if (!pass.empty())
                {
                    pass.erase(pass.size() - 1);
                    cout << "\b \b";
                }
            }
            else {
                if (c == -32) // phim mui ten
                {
                    _getch();
                }
                else {
                    if (isprint(c))
                    {
                        cout << '*';
                        pass += c;
                    }
                }
            }
        }
    }
    char* temp = const_cast<char*>(pass.c_str());
    strcpy_s(this->pwd, temp);
}
ostream& operator<<(ostream& o, const Account acc)
{
    o << left << setw(20) << acc.fullname;
    o << left << setw(17) << acc.username;
    o << left << setw(11) << acc.phone_number;
    o << right << setw(23) << acc.email << endl;
    return o;
}
void Account::Show()
{
    Decoration d;
    d.setColor(14);
    cout << left << setw(20) << this->fullname;
    cout << left << setw(17) << this->username;
    cout << left << setw(11) << this->phone_number;
    cout << left << setw(23) << this->email;
    cout << right << setw(2) << this->role << endl;
}