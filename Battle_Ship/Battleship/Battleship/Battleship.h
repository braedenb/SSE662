#pragma once
#ifdef BATTLESHIP_EXPORTS
#define BATTLESHIP_API _declspec(dllexport)
#else
#define BATTLESHIP_API _declspec(dllimport)
#endif
#include <string>
using std::string;

// This class is exported from the Battleship.dll
class BATTLESHIP_API Battleship
{
	public:
		bool Board1[8][8];
		bool Board2[8][8];
		string Message;

	public:
		void InitializeBoards();
		void SetupBoards();
		void PrintBoards(int n);
		void Fire(int player, int row, int col);
		void CheckWin();
};