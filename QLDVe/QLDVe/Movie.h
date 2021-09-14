#pragma once
#include <iostream>
using namespace std;
#include <iomanip>
#include <windows.h>
#include <conio.h>
#include <string>
#include "Decoration.h"
class Movie
{
private:
	int movie_id;
	char movie_name[50];
	char movie_description[160];
	char movie_release[15];
	int movie_length;
	char movie_genre[50];
	Decoration decoration;
public:
	Movie();
	Movie(int, char*, char*, char*, int, char*);
	~Movie();
	int getMovieID();
	char* getMovieName();
	char* getMovieDescription();
	char* getMovieRelease();
	int getMovieLength();
	char* getMovieGenre();
	void setMovie();
	string insertQuery();
	void Show();
};
