#include <iostream>
#include <Windows.h>
#include <sql.h>
#include <sqlext.h>
#include <sqltypes.h>
#include "Date.h"
#include "Function.h"
using namespace std;

int main()
{
    Decoration d;
    Function fc;
    d.setColor(11);
    fc.Information();
    _getch();
    system("cls");
    fc.Authentication();
    char key;
    d.setColor(12);

    cout << " \t\t\t\t\t\t\t\tWELCOME TO HANAFUO CINEMA!" << endl;
    do
    {
        system("cls");
        d.setColor(15);
        if (fc.getUserNow().getRole() == 1) {
            fc.MenuAdmin();
        }
        else {
            fc.Menu();
        }
        d.setColor(14);
        cout << "\t\t\t\t\t\t\t\tDo you want to be continute? y/n ";
        cin >> key;
        d.setColor(7);
    } while (key != 'n');
    return 0;
}