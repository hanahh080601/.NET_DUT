#include "Function.h"
Function::Function() {
    this->search = 0;
}
Function::~Function() {
}
void Function::MenuAdmin()
{
    Decoration d;
    d.setColor(12);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tHANAFUO CINEMA" << endl;
    d.setColor(15);
    cout
        << "\t\t\t\t\t\t\t\t1. Movie" << endl
        << "\t\t\t\t\t\t\t\t2. Account " << endl
        << "\t\t\t\t\t\t\t\t3. Booking " << endl
        << "\t\t\t\t\t\t\t\t4. Schedule" << endl
        << "\t\t\t\t\t\t\t\t5. Room" << endl
        << "\t\t\t\t\t\t\t\t6. Seat " << endl
        << "\t\t\t\t\t\t\t\t7. Seat type" << endl
        << "\t\t\t\t\t\t\t\t8. Menu user" << endl
        << "\t\t\t\t\t\t\t\t9. Log out " << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    cin >> m;
    system("cls");
    switch (m)
    {
    case 1:
        this->MenuAdMovie();
        break;
    case 2:
        this->MenuAdAccount();
        break;
    case 3:
        this->MenuAdBooking();
        break;
    case 4:
        this->MenuAdSchedule();
        break;
    case 5:
        this->MenuAdRoom();
        break;
    case 6:
        this->MenuAdSeat();
        break;
    case 7:
        this->MenuAdSeatType();
        break;
    case 8:
        Menu();
        break;
    case 9:
        this->user_now = out;
        Authentication();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
        cin.ignore();
        break;
    }
}
void Function::Menu()
{
    Decoration d;
    d.setColor(12);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tHANAFUO CINEMA" << endl;
    d.setColor(15);
    cout << "\t\t\t\t\t\t\t\t1. Movie on today" << endl
        << "\t\t\t\t\t\t\t\t2. Movie now showing" << endl
        << "\t\t\t\t\t\t\t\t3. Movie coming soon" << endl
        << "\t\t\t\t\t\t\t\t4. Search movie " << endl
        << "\t\t\t\t\t\t\t\t5. View showtimes ( schedule )" << endl
        << "\t\t\t\t\t\t\t\t6. Book a ticket " << endl
        << "\t\t\t\t\t\t\t\t7. Log out " << endl;
    d.setColor(14);
    cout << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    cin >> m;
    switch (m)
    {
    case 1:
        this->MenuTodayMovie();
        break;
    case 2:
        this->MenuMovieShowing();
        break;

    case 3:
        this->MenuMovieComing();
        break;
    case 4:
        this->MenuSearchMovie();
        break;
    case 5:
        this->MenuSchedule();
        break;
    case 6:
        this->MenuBooking();
        break;
    case 7:
        this->user_now = out;
        Authentication();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
        cin.ignore();
        break;
    }
}
void Function::Authentication()
{
    Decoration d;
    d.setColor(12);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tDo you have account ? " << endl;
    d.setColor(7);
    cout << "\t\t\t\t\t\t\t\t1. Login " << endl
        << "\t\t\t\t\t\t\t\t2. Register " << endl;
    d.setColor(14);
    cout << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    cin >> m;
    d.setColor(12);
    switch (m)
    {
    case 1:
        system("cls");
        cout << "\t\t\t\t\t\t\t\tLogin:" << endl;
        Validate();
        break;
    case 2:
        system("cls");
        cout << "\t\t\t\t\t\t\t\tRegister:" << endl;
        this->user.setAccount();
        this->acc.Init();
        this->acc.Insert(user);
        system("cls");
        this->Authentication();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
        _getch();
        fflush(stdin);
        cin.ignore();
        this->Authentication();
        break;
    }
}
void Function::Validate()
{
    Decoration d;
    d.setColor(15);
Login:
    int validate = 0;
    char ch;
    while (!validate)
    {
        string username;
        d.setColor(15);
        cout << "\t\t\t\t\t\t\t\tUsername : ";
        cin >> username;
        this->acc.Init();
        int stt = this->acc.SearchName(username);
        if ((this->acc.SearchName(username)) == -1)
        {
            d.setColor(4);
            cout << "\t\t\t\t\t\t\t\tAccount not founded ! " << endl;
            cout << "\t\t\t\t\t\t\t\tPlease try again !" << endl;
            d.setColor(14);
            continue;
        }
        else
        {
            validate = 1;
            string pwd;
        Password:
            d.setColor(15);
            cout << "\t\t\t\t\t\t\t\tEnter password  : ";
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
                        if (!pwd.empty())
                        {
                            pwd.erase(pwd.size() - 1);
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
                                pwd += c;
                            }
                        }
                    }
                }
            }
            char* password = const_cast<char*>(pwd.c_str());
            if (this->acc.checkPwd(stt) == pwd)
            {
                d.setColor(10);
                cout << "\t\t\t\t\t\t\tLogin success! Press Enter to continute !" << endl;
                validate = 1;
                d.setColor(15);
                _getch();
                system("cls");
            }
            else
            {
                d.setColor(4);
                cout << "\t\t\t\t\t\t\t\tWrong password, please try again !" << endl;
                d.setColor(14);
                pwd = "";
                goto Password;
            }
        }
        this->user_now = this->acc.getAccount(stt);
        this->acc.Close();
    }
}
void Function::MenuTodayMovie()
{
    system("cls");
    Decoration d;
    d.setColor(11);
    this->mv.Init();
    cout << "\t\t\t\t\t\t\t\tMovie on today: " << endl;
    d.setColor(7);
    this->mv.Show(5);
    this->mv.Close();
}
void Function::MenuMovieShowing()
{
    system("cls");
    Decoration d;
    d.setColor(11);
    this->mv.Init();
    cout << "\t\t\t\t\t\t\t\tMovie is showing: " << endl;
    this->mv.Show(2);
    this->mv.Close();
}
void Function::MenuMovieComing()
{
    system("cls");
    Decoration d;
    d.setColor(11);
    this->mv.Init();
    cout << "\t\t\t\t\t\t\t\tMovie coming soon :" << endl;
    this->mv.Show(3);
    this->mv.Close();
}
void Function::MenuSearchMovie()
{
    system("cls");
    this->mv.Init();
    this->mv.Show(4);
    this->mv.Close();
}
void Function::MenuSchedule()
{
    Decoration d;
    d.setColor(11);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tSchedule ( Showtimes ) " << endl;
    d.setColor(15);
    cout
        << "\t\t\t\t\t\t\t\t1. All showtimes" << endl
        << "\t\t\t\t\t\t\t\t2. Movie on today" << endl
        << "\t\t\t\t\t\t\t\t3. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    cin >> m;
    this->schedule.Init();
    switch (m)
    {
    case 1:
        this->schedule.Show(1);
        break;
    case 2:
        this->schedule.Show(3);
        break;
    case 3:
        Menu();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
        cin.ignore();
        break;
    }
    this->schedule.Close();
}
void Function::MenuBooking()
{
    this->schedule.Init();
    this->schedule.Show(1);
    Decoration d;
    int schedule_stt;
    d.setColor(15);
    cout << "\t\t\t\t\t\t\t\tPick showtime :";
    cin >> schedule_stt;
    int id_schedule = this->schedule.getSchedule(schedule_stt - 1).getScheduleID();
    int room_id = this->schedule.getSchedule(schedule_stt - 1).getRoomID();
    this->seat.Init();
    d.setColor(11);
    cout << "\t\t\t\t\t\t\t\tRoom seating map: ";
    this->seat.Show(room_id);
    int seat_stt = 0;
    d.setColor(14);
    cout << "\t\t\t\t\t\t\tX - seat is reserved , O - seat is available " << endl;
    cout << "\t\t\t\t\t\t\tWhite - seat is normal , Yellow - seat is VIP " << endl;
    d.setColor(15);
    cout << "\t\t\t\t\t\t\t\tPick seat : ";
    cin >> seat_stt;
    int seat_id = this->seat.getSeat(seat_stt - 1, room_id).getSeatID();
    while (this->seat.getSeat(seat_stt - 1, room_id).getStatus() == 1)
    {
        cout << "\t\t\t\t\t\t\t\tSorry, this seat is reserved! " << endl;
        cout << "\t\t\t\t\t\t\tX - seat is reserved , O - seat is available " << endl;
        cout << "\t\t\t\t\t\t\tWhite - seat is normal , Yellow - seat is VIP " << endl;
        cout << "\t\t\t\t\t\t\t\tPick seat again : ";
        cin >> seat_stt;
        seat_id = this->seat.getSeat(seat_stt - 1, room_id).getSeatID();
    }
    this->new_booking.setBooking(this->getUserNow().getID(), id_schedule, seat_id);
    this->booking.Init();
    this->booking.Insert(new_booking);
    this->seat.Close();
    this->schedule.Close();
    this->booking.Close();
}
void Function::MenuAdAccount()
{
    Decoration d;
    d.setColor(11);
    int stt_acc;
    system("cls");
    cout << "\t\t\t\t\t\t\t\tManage account" << endl;
    d.setColor(15);
    cout << "\t\t\t\t\t\t\t\t1. All account" << endl
        << "\t\t\t\t\t\t\t\t2. New account " << endl
        << "\t\t\t\t\t\t\t\t3. Update account " << endl
        << "\t\t\t\t\t\t\t\t4. Delete account" << endl
        << "\t\t\t\t\t\t\t\t5. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    cin >> m;
    this->acc.Init();
    switch (m)
    {
    case 1:
        this->acc.Show();
        break;
    case 2:
        this->user.setAccount();
        this->acc.Insert(user);
        this->acc.Show();
        break;
    case 3:
        this->acc.Update();
        break;
    case 4:
        this->acc.Show();
        d.setColor(14);
        cout << "\t\t\t\t\t\t\t\tEnter stt account to delete: ";
        d.setColor(15);
        cin >> stt_acc;
        this->acc.Delete(stt_acc - 1);
        break;
    case 5:
        MenuAdmin();
        break;
    default:
        d.setColor(3);
        cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option! " << endl;
        cin.ignore();
        break;
    }
    this->acc.Close();
}
void Function::MenuAdRoom() {
    Decoration d;
    d.setColor(11);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tManage room" << endl;
    d.setColor(15);
    cout
        << "\t\t\t\t\t\t\t\t1. Show all room" << endl
        << "\t\t\t\t\t\t\t\t2. Show one room" << endl
        << "\t\t\t\t\t\t\t\t3. New room " << endl
        << "\t\t\t\t\t\t\t\t4. Update room " << endl
        << "\t\t\t\t\t\t\t\t5. Delete room" << endl
        << "\t\t\t\t\t\t\t\t6. Back to menu before" << endl
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    int room;
    cin >> m;
    this->room.Init();
    switch (m)
    {
    case 1:
        this->room.Show(1, 0);
        break;
    case 2:
        cout << "\t\t\t\t\t\t\t\tEnter room to show: ";
        cin >> room;
        this->room.Show(2, room);
        break;
    case 3:
        this->room.Insert();
        this->room.Show(1, 0);
        break;
    case 4:
        cout << "\t\t\t\t\t\t\t\tEnter room to update: ";
        cin >> room;
        this->room.Update(room);
        break;
    case 5:
        this->room.Delete();
        break;
    case 6:
        MenuAdmin();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
        cin.ignore();
        break;
    }
    this->room.Close();
}
void Function::MenuAdSeat() {
    Decoration d;
    d.setColor(12);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tSEAT" << endl;
    d.setColor(15);
    cout
        << "\t\t\t\t\t\t\t\t1. Show Seat of Room" << endl
        << "\t\t\t\t\t\t\t\t2. New Seat " << endl
        << "\t\t\t\t\t\t\t\t3. Update Seat " << endl
        << "\t\t\t\t\t\t\t\t4. Delete Seat" << endl
        << "\t\t\t\t\t\t\t\t5. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    int room;
    int stt_seat;
    cin >> m;
    this->seat.Init();
    d.setColor(11);
    switch (m)
    {
    case 1:
        cout << "\t\t\t\t\t\t\t\tEnter room to show map of seats: ";
        cin >> room;
        this->seat.Show(room);
        break;
    case 2:
        this->seat.Insert();
        this->seat.Show(1);
        break;
    case 3:
        cout << "\t\t\t\t\t\t\t\tEnter room to update seat";
        cin >> room;
        this->MenuUpdateSeat(room);
        break;
    case 4:
        this->seat.Delete();
        break;
    case 5:
        MenuAdmin();
        break;
    default:
        d.setColor(3);
        cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
        cin.ignore();
        break;
    }
    this->seat.Close();
}
void Function::MenuUpdateSeat(int room)
{
    system("cls");
    Decoration d;
    char key = 'y';
    int seat;
    do {
        this->seat.Show(room);
        d.setColor(11);
        cout << "\t\t\t\t\t\t\t\tEnter order number of seat to update: ";
        cin >> seat;
        d.setColor(11);
        cout << "\t\t\t\t\t\t\t\tUpdate seat" << endl;
        d.setColor(15);
        cout
            << "\t\t\t\t\t\t\t\t1. Seat type" << endl
            << "\t\t\t\t\t\t\t\t2. Seat row" << endl
            << "\t\t\t\t\t\t\t\t3. Seat number" << endl
            << "\t\t\t\t\t\t\t\t4. Back to menu before" << endl;
        d.setColor(14);
        cout
            << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
        int m;
        cin >> m;
        switch (m)
        {
        case 1:
            this->seat.Update(this->seat.getSeat(seat - 1, room).getSeatID(), 1, room);
            break;
        case 2:
            this->seat.Update(this->seat.getSeat(seat - 1, room).getSeatID(), 2, room);
            break;
        case 3:
            this->seat.Update(this->seat.getSeat(seat - 1, room).getSeatID(), 3, room);
            break;
        case 4:
            MenuAdSeat();
            break;
        default:
            d.setColor(12);
            cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
            cin.ignore();
            break;
        }
        this->seat.Show(room);
        cout << "\t\t\t\t\t\t\t\tDo you want to be continute? y/n ";
        cin >> key;

    } while (key != 'n');
    MenuAdmin();
}
void Function::MenuAdMovie() {
    system("cls");
    Decoration d;
    d.setColor(12);
    cout << "\t\t\t\t\t\t\t\tMovie" << endl;
    d.setColor(15);
    cout
        << "\t\t\t\t\t\t\t\t1. Show all Movie" << endl
        << "\t\t\t\t\t\t\t\t2. Show today Movie" << endl
        << "\t\t\t\t\t\t\t\t3. Show showing Movie" << endl
        << "\t\t\t\t\t\t\t\t4. Show coming Movie" << endl
        << "\t\t\t\t\t\t\t\t5. New movie " << endl
        << "\t\t\t\t\t\t\t\t6. Update movie " << endl
        << "\t\t\t\t\t\t\t\t7. Delete movie" << endl
        << "\t\t\t\t\t\t\t\t8. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    int stt_mv;
    cin >> m;
    switch (m)
    {
    case 1:
        this->mv.Init();
        this->mv.Show(1);
        this->mv.Close();
        break;
    case 2:
        this->mv.Init();
        this->mv.Show(5);
        this->mv.Close();
        break;
    case 3:
        this->mv.Init();
        this->mv.Show(2);
        this->mv.Close();
        break;
    case 4:
        this->mv.Init();
        this->mv.Show(3);
        this->mv.Close();
        break;
    case 5:
        this->mv.Init();
        this->mv.Insert();
        this->mv.Show(1);
        this->mv.Close();
        break;
    case 6:
        this->mv.Init();
        this->mv.Show(1);
        cout << "\t\t\t\t\t\t\t\tEnter order number of movie to update : ";
        cin >> stt_mv;
        this->MenuUpdateMovie(stt_mv - 1);
        break;
    case 7:
        this->mv.Delete();
        break;
    case 8:
        MenuAdmin();
        break;

    default:
        cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
        cin.ignore();
        break;
    }
}
void Function::MenuUpdateMovie(int stt)
{
    system("cls");
    Decoration d;
    char key = 'y';
    do {
        d.setColor(12);
        cout << "\t\t\t\t\t\t\t\tUpdate Movie" << endl;
        d.setColor(15);
        cout
            << "\t\t\t\t\t\t\t\t1. Movie name" << endl
            << "\t\t\t\t\t\t\t\t2. movie description" << endl
            << "\t\t\t\t\t\t\t\t3. movie release" << endl
            << "\t\t\t\t\t\t\t\t4. movie length" << endl
            << "\t\t\t\t\t\t\t\t5. movie genre " << endl
            << "\t\t\t\t\t\t\t\t6. Back to menu before " << endl;
        d.setColor(14);
        cout
            << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
        int m;
        cin >> m;
        this->mv.getMovie(stt).Show();
        switch (m)
        {
        case 1:
            this->mv.Update(this->mv.getMovie(stt).getMovieID(), 1);
            break;
        case 2:
            this->mv.Update(this->mv.getMovie(stt).getMovieID(), 2);
            break;
        case 3:
            this->mv.Update(this->mv.getMovie(stt).getMovieID(), 3);
            break;
        case 4:
            this->mv.Update(this->mv.getMovie(stt).getMovieID(), 4);
            break;
        case 5:
            this->mv.Update(this->mv.getMovie(stt).getMovieID(), 5);
            break;
        case 6:
            MenuAdMovie();
            break;
        default:
            d.setColor(11);
            cout << "\t\t\t\t\t\t\t\tSorry,there is no matching option " << endl;
            cin.ignore();
            break;
        }
        this->mv.getMovie(stt).Show();
        d.setColor(14);
        cout << "\t\t\t\t\t\t\t\tDo you want to be continue ? y/n";
        cin >> key;

    } while (key != 'n');
    MenuAdmin();
}
void Function::MenuAdSeatType() {
    system("cls");
    Decoration d;
    d.setColor(12);
    cout << "\t\t\t\t\t\t\t\tSEAT TYPE " << endl;
    d.setColor(15);
    cout
        << "\t\t\t\t\t\t\t\t1. Show seat type" << endl
        << "\t\t\t\t\t\t\t\t2. New Seat type" << endl
        << "\t\t\t\t\t\t\t\t3. Update Seat type" << endl
        << "\t\t\t\t\t\t\t\t4. Delete Seat type" << endl
        << "\t\t\t\t\t\t\t\t5. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    int stt;
    cin >> m;
    this->seat_type.Init();
    switch (m)
    {
    case 1:

        this->seat_type.Show();
        break;
    case 2:

        this->seat_type.Insert();
        this->seat_type.Show();
        break;
    case 3:
        this->MenuUpdateSeatType();
        break;
    case 4:
        this->seat.Delete();
        break;
    case 5:
        MenuAdmin();
        break;
    default:
        d.setColor(11);
        cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
        cin.ignore();
        break;
    }
    this->seat.Close();
}
void Function::MenuUpdateSeatType()
{
    system("cls");
    Decoration d;
    char key = 'y';
    int stt;
    do {
        this->seat_type.Show();
        d.setColor(11);
        cout << "\t\t\t\t\t\t\t\tEnter order number of seat type to update: ";
        cin >> stt;
        d.setColor(12);
        cout << "\t\t\t\t\t\t\t\tUpdate seat type" << endl;
        d.setColor(15);
        cout
            << "\t\t\t\t\t\t\t\t1. Seat type name" << endl
            << "\t\t\t\t\t\t\t\t2. Seat price" << endl
            << "\t\t\t\t\t\t\t\t3. Back to menu before" << endl;
        d.setColor(14);
        cout
            << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
        int m;
        cin >> m;
        switch (m)
        {
        case 1:
            this->seat_type.Update(1, this->seat_type.getSeatType(stt - 1).getSeatTypeID());
            break;
        case 2:
            this->seat_type.Update(2, this->seat_type.getSeatType(stt - 1).getSeatTypeID());
            break;
        case 3:
            MenuAdSeatType();
            break;
        default:
            d.setColor(11);
            cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
            cin.ignore();
            break;
        }
        this->seat_type.Show();
        cout << "\t\t\t\t\t\t\t\tDo you want to be continue ? y/n";
        cin >> key;

    } while (key != 'n');
    MenuAdmin();
}
void Function::MenuAdBooking() {
    Decoration d;
    system("cls");
    d.setColor(12);

    cout << "\t\t\t\t\t\t\t\t Booking" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\t1. Show Booking" << endl
        << "\t\t\t\t\t\t\t\t2. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    Account out;
    cin >> m;
    this->booking.Init();
    d.setColor(11);
    switch (m)
    {
    case 1:
        this->booking.Show(1, 0);
        break;
    case 2:
        MenuAdmin();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
        cin.ignore();
        break;
    }
    this->booking.Close();
}
void Function::MenuUpdateSchedule(int stt)
{
    system("cls");
    Decoration d;
    char key = 'y';
    do {
        d.setColor(12);
        cout << "\t\t\t\t\t\t\t\tUpdate schedule" << endl;
        d.setColor(15);
        cout
            << "\t\t\t\t\t\t\t\t1. Movie ID" << endl
            << "\t\t\t\t\t\t\t\t2. Room ID" << endl
            << "\t\t\t\t\t\t\t\t3. Schedule date" << endl
            << "\t\t\t\t\t\t\t\t4. Schedule start" << endl
            << "\t\t\t\t\t\t\t\t5. Schedule end " << endl
            << "\t\t\t\t\t\t\t\t6. Back to menu before " << endl;
        d.setColor(14);
        cout
            << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
        int m;
        cin >> m;
        this->schedule.Init();
        this->mv.Init();
        this->schedule.getSchedule(stt).Show(this->mv);
        switch (m)
        {
        case 1:

            this->schedule.Update(this->schedule.getSchedule(stt).getScheduleID(), 1);
            this->schedule.Close();
            break;
        case 2:
            this->schedule.Update(this->schedule.getSchedule(stt).getScheduleID(), 2);
            this->schedule.Close();
            break;
        case 3:
            this->schedule.Update(this->schedule.getSchedule(stt).getScheduleID(), 3);
            this->schedule.Close();
            break;
        case 4:
            this->schedule.Update(this->schedule.getSchedule(stt).getScheduleID(), 4);
            this->schedule.Close();
            break;
        case 5:
            this->schedule.Update(this->schedule.getSchedule(stt).getScheduleID(), 5);
            this->schedule.Close();
            break;
        case 6:
            MenuAdSchedule();
            break;
        default:
            cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
            cin.ignore();
            break;
        }
        this->schedule.getSchedule(stt).Show(this->mv);
        this->schedule.Close();
        this->mv.Close();
        cout << "\t\t\t\t\t\t\t\tDo you want to be continue ? y/n";
        cin >> key;

    } while (key != 'n');
    MenuAdmin();
}


void Function::MenuAdSchedule() {
    Decoration d;
    d.setColor(12);
    system("cls");
    cout << "\t\t\t\t\t\t\t\tSCHEDULE" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\t1. Show shedule" << endl
        << "\t\t\t\t\t\t\t\t2. New schedule " << endl
        << "\t\t\t\t\t\t\t\t3. Delete schedule" << endl
        << "\t\t\t\t\t\t\t\t4. Back to menu before" << endl;
    d.setColor(14);
    cout
        << "\t\t\t\t\t\t\t\tPRESS THE NUMBER : ";
    int m;
    int stt_sc;
    Account out;
    int movieID;
    cin >> m;
    this->schedule.Init();
    d.setColor(11);
    switch (m)
    {
    case 1:
        this->schedule.Show(1);
        break;
    case 2:
        this->schedule.Insert();
        break;
        /*case 3:
            this->schedule.Show(1);
            cout << "\t\t\t\t\t\t\tEnter order number of schedule to update : ";
            cin >> stt_sc;
            this->MenuUpdateSchedule(stt_sc - 1);
            break;*/
    case 3:
        this->schedule.Show(1);
        cout << "\t\t\t\t\t\t\tEnter order number of schedule: ";
        cin >> stt_sc;
        this->schedule.Delete(stt_sc - 1);
        break;
    case 4:
        MenuAdmin();
        break;
    default:
        cout << "\t\t\t\t\t\t\t\tSorry, there is no matching option !" << endl;
        cin.ignore();
        break;
    }
    this->schedule.Close();
}
Account Function::getUserNow()
{
    return this->user_now;
}
void Function::Information() {
    cout << "\t\t\t\t\t\t-------------------------------------------------------------------------" << endl;
    cout << "\t\t\t\t\t\t|\t\t\t PBL2 PROJECT\t\t\t\t\t|" << endl;
    cout << "\t\t\t\t\t\t|\t\t Project : Movie booking management \t\t\t|" << endl;
    cout << "\t\t\t\t\t\t|\t\t Teacher : Phan Chi Tung & Phan Thanh Tao \t\t|" << endl;
    cout << "\t\t\t\t\t\t|\t\t Student : Tran Thi Phuong & Le Hoang Ngoc Han \t\t|" << endl;
    cout << "\t\t\t\t\t\t|\t\t Class   : 19TCLC_DT4 \t\t\t\t\t|" << endl;
    cout << "\t\t\t\t\t\t|\t\t Group   : 19.Nh14A \t\t\t\t\t|" << endl;
    cout << "\t\t\t\t\t\t-------------------------------------------------------------------------" << endl;
}