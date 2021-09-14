#include "Movie.h"
Movie::Movie()
{
}
Movie::Movie(int id, char* name, char* description, char* release, int length, char* genre)
	:movie_id(id), movie_length(length)
{
	strcpy_s(this->movie_name, 50, name);
	strcpy_s(this->movie_description, 160, description);
	strcpy_s(this->movie_release, 15, release);
	strcpy_s(this->movie_genre, 50, genre);

}
Movie::~Movie() {
}
int Movie::getMovieID() {
	return this->movie_id;
}
char* Movie::getMovieName() {
	return this->movie_name;
}
char* Movie::getMovieDescription() {
	return this->movie_description;
}
char* Movie::getMovieRelease() {
	return this->movie_release;
}
int Movie::getMovieLength() {
	return this->movie_length;
}
char* Movie::getMovieGenre() {
	return this->movie_genre;
}
void Movie::setMovie()
{
	Decoration d;
	cin.ignore();
	d.setColor(12);
	cout << "\t\t\t\t\t\t\t\tMovie name: ";
	d.setColor(15);
	cin.getline(this->movie_name, 50);
	d.setColor(12);
	cout << "\t\t\t\t\t\t\t\tMovie description:";
	d.setColor(15);
	cin.getline(this->movie_description, 160);
	d.setColor(12);
	cout << "\t\t\t\t\t\t\t\tMovie release:";
	d.setColor(15);
	cin.getline(this->movie_release, 15);
	d.setColor(12);
	cout << "\t\t\t\t\t\t\t\tMovie length";
	d.setColor(15);
	cin >> movie_length;
	cin.ignore();
	d.setColor(12);
	cout << "\t\t\t\t\t\t\t\tMovie genre:";
	d.setColor(15);
	cin.getline(this->movie_genre, 50);
}
string Movie::insertQuery()
{
	string t_query;
	string t_movie_id = to_string(movie_id);
	string t_movie_name(movie_name);
	string t_movie_description(movie_description);
	string t_movie_release(movie_release);
	string t_movie_length = to_string(movie_length);
	string t_movie_genres(movie_genre);
	t_query = t_movie_name + "','" + t_movie_description + "','" + t_movie_length + "','" + t_movie_genres + "','" + t_movie_release + "')";
	return t_query;
}

void Movie::Show()
{
	char* MV = this->movie_name;
	for (int i = strlen(MV) - 1; i >= 0; i--) {
		if (MV[i] != ' ') {
			MV[i + 1] = '\0';
			break;
		}
	}
	string temp(MV);
	Decoration d;
	d.setColor(11);
	cout << "\t\t\t\t" << temp << "" << endl << endl;
	d.setColor(15);
	cout << "\t\t\t\tDescription: " << this->movie_description << endl;
	cout << "\t\t\t\tLength: " << this->movie_length << " phut " << endl;
	cout << "\t\t\t\tGenre: " << this->movie_genre << endl;
	cout << "\t\t\t\tRelease: " << this->movie_release << endl << endl;
}