#pragma once
#include "Movie.h"
#include "Date.h"
#include "DatabaseAccess.h"

class MovieAccess :
    public DatabaseAccess
{
    string search_key;
    Decoration decoration;
public:
    MovieAccess();
    ~MovieAccess();
    void Select(Movie*&, int);
    int CountRow(int);
    bool Insert();
    int Search(int); // search theo id_number
    bool Update(int, int);
    bool Delete();
    Movie getMovie(int);
    char* getMovieName(int);
    void Show(int);
    int LastID();
};
