#pragma once
#ifndef BATTLESHIP_H
#define BATTLESHIP_H
#include <string>
using std::string;

class Battleship
{
public:
	bool Board1[8][8];
	bool Board2[8][8];

	string Message;

	int check[128];
	int target, hit = 0, i;
	int airpone, airptwo, airpthree, airpfour, airpfive;
	int destroypone, destroyptwo, destroypthree, destroypfour;
	int battlepone, battleptwo, battlepthree;
	int subpone, subptwo, subpthree;
	int patrolpone, patrolptwo;

	char rowone[50] = "11 12 13 14 15 16 17 18\n";
	char rowtwo[50] = "21 22 23 24 25 26 27 28\n";
	char rowthree[50] = "31 32 33 34 35 36 37 38\n";
	char rowfour[50] = "41 42 43 44 45 46 47 48\n";
	char rowfive[50] = "51 52 53 54 55 56 57 58\n";
	char rowsix[50] = "61 62 63 64 65 66 67 68\n";
	char rowseven[50] = "71 72 73 74 75 76 77 78\n";
	char roweight[50] = "81 82 83 84 85 86 87 88\n";
	char e;

	int airponetwo, airptwotwo, airpthreetwo, airpfourtwo, airpfivetwo;
	int destroyponetwo, destroyptwotwo, destroypthreetwo, destroypfourtwo;
	int battleponetwo, battleptwotwo, battlepthreetwo;
	int subponetwo, subptwotwo, subpthreetwo;
	int patrolponetwo, patrolptwotwo;

	char rowonetwo[50] = "11 12 13 14 15 16 17 18\n";
	char rowtwotwo[50] = "21 22 23 24 25 26 27 28\n";
	char rowthreetwo[50] = "31 32 33 34 35 36 37 38\n";
	char rowfourtwo[50] = "41 42 43 44 45 46 47 48\n";
	char rowfivetwo[50] = "51 52 53 54 55 56 57 58\n";
	char rowsixtwo[50] = "61 62 63 64 65 66 67 68\n";
	char rowseventwo[50] = "71 72 73 74 75 76 77 78\n";
	char roweighttwo[50] = "81 82 83 84 85 86 87 88\n";

public:
	void checkShips();
	void quitGame();
	void targeting();
	void InitializeBoards();
	void SetupBoards();
	void PrintBoards(int n);
	void Fire(int player, int row, int col);
	void CheckWin();
};

#endif