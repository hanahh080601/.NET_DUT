#pragma once
#include "DatabaseAccess.h"
class Account;
class AccountAccess :
    public DatabaseAccess
{
public:
    void Select(Account*&); // *:mảng các account &:tham chiếu từng trường trong account 
    int CountRow();
    bool Insert(Account);
    int Search(int); // search theo id_number
    int LastID();
    bool Update();
    bool Delete(int);
    void Show();
    int SearchName(string);
    char* checkPwd(int);
    Account getAccount(int);

};