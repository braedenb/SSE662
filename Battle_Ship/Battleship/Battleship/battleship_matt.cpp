// roytest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <iostream>
#include <sstream>
#include <string>
using namespace std;

void InitializeBoards();
void PrintBoard(int n);
void SetupBoards();
void setShip(int n, string ship);
bool validShipPlacement(int n, int pos);
void playGame();
void fire();
void countHits();
void printHits(int n);
bool validTarget(int pos);

string board1[8][8], board2[8][8];
bool board1hit[8][8], board2hit[8][8];
int hits1, hits2;

int main()
{
	InitializeBoards();
	PrintBoard(1);
	PrintBoard(2);
	SetupBoards();
	playGame();
	string end;
	cin >> end;
    return 0;
}

void InitializeBoards() {
	hits1 = 0;
	hits2 = 0;
	for (int i = 0; i<8; i++) {
		for (int j = 0; j<8; j++) {
			board1[i][j] = to_string(10*(i+1) + (j+1));
			board2[i][j] = to_string(10*(i+1) + (j+1));
			board1hit[i][j] = false;
			board2hit[i][j] = false;
		}
	}
}

void PrintBoard(int n) {
	cout << "Player " << n << "'s Board:" << endl;
	if (n == 1) {
		for (int i = 0; i<8; i++) {
			for (int j = 0; j < 8; j++)
				cout << board1[i][j] << " ";
			cout << endl;
		}
	}
	else if (n == 2) {
		for (int i = 0; i<8; i++) {
			for (int j = 0; j<8; j++)
				cout << board2[i][j] << " ";
			cout << endl;
		}
	}
	cout << endl;
}

void SetupBoards() {
	for (int n = 1; n < 3; n++) {
		cout << "Player " << n << ", enter your ships' positions:" << endl;
		cout << "Battle ship (3 spaces)" << endl;
		for (int i = 0; i < 3; i++) {
			setShip(n, "BA");
		}
		cout << "Patrol boat (2 spaces)" << endl;
		for (int i = 0; i < 2; i++) {
			setShip(n, "PA");
		}
		cout << "Submarine (3 spaces)" << endl;
		for (int i = 0; i < 3; i++) {
			setShip(n, "SU");
		}
		cout << "Destroyer (4 spaces)" << endl;
		for (int i = 0; i < 4; i++) {
			setShip(n, "DA");
		}
		cout << "Aircraft carrier (5 spaces)" << endl;
		for (int i = 0; i < 5; i++) {
			setShip(n, "AC");
		}
		cout << endl << "Here is your board:" << endl << endl;
		PrintBoard(n);
	}
}

void setShip(int n, string ship) {
	cout << "Position : ";
	int pos;
	cin >> pos;
	while (!validShipPlacement(n, pos)) {
		cout << "Invalid position, try again : ";
		cin >> pos;
	}
	int i = pos / 10;
	int j = pos - (i*10);
	if (n == 1)
		board1[i-1][j-1] = ship;
	if (n == 2)
		board2[i-1][j-1] = ship;
}

bool validShipPlacement(int n, int pos) {
	if (validTarget(pos)) {
		int i = pos / 10;
		int j = pos - (i * 10);
		if (n == 1) {
			if (board1[i - 1][j - 1] == to_string(10 * i + j))
				return true;
			else
				return false;
		}
		if (n == 2) {
			if (board2[i - 1][j - 1] == to_string(10 * i + j))
				return true;
			else
				return false;
		}
	}
	else return false;
}

void playGame() {
	while (hits1 < 17 && hits2 < 17) {
		fire();
		countHits();
	}
	if (hits1 == 17)
		cout << "Player 2 wins!" << endl;
	if (hits2 == 17)
		cout << "Player 1 wins!" << endl;
}

void fire() {
	//Player 1 fire on Player 2's board
	//Pick target
	cout << "Player 1, enter your target : ";
	int pos;
	cin >> pos;
	while (!validTarget(pos)) {
		cout << "Invalid target, try again : ";
		cin >> pos;
	}
	//Fire
	int i = pos / 10;
	int j = pos - (i * 10);
	if (board2[i - 1][j - 1] != to_string(10 * i + j)) {
		board2hit[i - 1][j - 1] = true;
		cout << "Target hit!" << endl;
	}
	else
		cout << "Miss!" << endl;
	printHits(1);

	//Player 2 fire on Player 1's board
	//Pick target
	cout << "Player 2, enter your target : ";
	cin >> pos;
	while (!validTarget(pos)) {
		cout << "Invalid target, enter new target : ";
		cin >> pos;
	}
	//Fire
	i = pos / 10;
	j = pos - (i * 10);
	if (board1[i - 1][j - 1] != to_string(10 * i + j)) {
		board1hit[i - 1][j - 1] = true;
		cout << "Target hit!" << endl;
	}
	else
		cout << "Miss!" << endl;
	printHits(2);
}

bool validTarget(int pos) {
	if ((pos > 10 && pos < 19) || (pos > 20 && pos < 29) || (pos > 30 && pos < 39) || (pos > 40 && pos < 49)
		|| (pos > 50 && pos < 59) || (pos > 60 && pos < 69) || (pos > 70 && pos < 79) || (pos > 80 && pos < 89)) {
		return true;
	}
	else return false;
}

void countHits() {
	//Total hits on each board
	hits1 = 0;
	hits2 = 0;
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			if (board1hit[i][j])
				hits1++;
			if (board2hit[i][j])
				hits2++;
		}
	}
}

void printHits(int n) {
	countHits();
	cout << "Targets hit : " << endl;

	//Hits on board 2 by player 1
	if (n == 1) {
		for (int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
				if (board2hit[i][j])
					cout << i + 1 << j + 1 << endl;
		cout << hits2 << " total hits" << endl;
	}

	//Hits on board 1 by player 2
	if (n == 2) {
		for (int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
				if (board1hit[i][j])
					cout << i + 1 << j + 1 << endl;
		cout << hits1 << " total hits" << endl;
	}
}

