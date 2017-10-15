#include "stdafx.h"
#include "CppUnitTest.h"
#include "..\..\Battleship\Battleship\Battleship.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace BattleshipTest
{
	TEST_CLASS(UnitTest1)
	{
	public:
		TEST_METHOD(InitializeBoardsTest)
		{
			Battleship battleship;
			// Create a 10x10 board for each player that has no pieces on it.
			battleship.InitializeBoards();

			for (int i = 0; i < sizeof battleship.Board1[0]; i++)
			{
				for (int j = 0; j < sizeof battleship.Board1[0]; j++)
				{
					Assert::AreEqual(false, battleship.Board1[i][j], L"Board 1 is not initialized properly.");
					Assert::AreEqual(false, battleship.Board2[i][j], L"Board 2 is not initialized properly.");
				}
			}
		}

		TEST_METHOD(SetupBoardsTest)
		{
			Battleship battleship;
			battleship.InitializeBoards();
			// Assign pieces to each player's board.
			battleship.SetupBoards();

			int player1PiecesUsed = 0;
			int player2PiecesUsed = 0;
			for (int i = 0; i < sizeof battleship.Board1[0]; i++)
			{
				for (int j = 0; j < sizeof battleship.Board1[0]; j++)
				{
					if (battleship.Board1[i][j])
						player1PiecesUsed++;
					if (battleship.Board2[i][j])
						player2PiecesUsed++;
				}
			}

			Assert::AreEqual(17, player1PiecesUsed, L"Board 1 is not setup properly.");
			Assert::AreEqual(17, player2PiecesUsed, L"Board 2 is not setup properly.");
		}

		TEST_METHOD(FireTest)
		{
			Battleship battleship;
			battleship.InitializeBoards();
			
			// Player 1 fires at row 1, column 1.
			battleship.Fire(1, 1, 1);
			
			string p1Miss = "Player 1 - MISS";
			Assert::AreEqual(p1Miss, battleship.Message, L"Player 1's shot hit when it should have missed.");

			// Player 2 has a peice at row 1, column 1.
			battleship.Board2[0][0] = true;

			// Player 1 fires at row 1, column 1.
			battleship.Fire(1, 1, 1);

			string p1Hit = "Player 1 - HIT";
			Assert::AreEqual(p1Hit, battleship.Message, L"Player 1's shot missed when it should have hit.");

			// Player 2 fires at row 1, column 1.
			battleship.Fire(2, 1, 1);

			string p2Miss = "Player 2 - MISS";
			Assert::AreEqual(p2Miss, battleship.Message, L"Player 2's shot hit when it should have missed.");

			// Player 1 has a piece at row 1, column 1.
			battleship.Board1[0][0] = true;

			// Player 2 fires at row 1, column 1.
			battleship.Fire(2, 1, 1);

			string p2Hit = "Player 2 - HIT";
			Assert::AreEqual(p2Hit, battleship.Message, L"Player 2's shot missed when it should have hit.");
		}

		TEST_METHOD(CheckWinTest)
		{
			Battleship battleship;
			battleship.InitializeBoards();
			battleship.SetupBoards();

			// Each player has a piece at row 1, column 1.
			battleship.Board1[0][0] = true;
			battleship.Board2[0][0] = true;
			// Check if one of the players has won.
			battleship.CheckWin();

			string noWinner = "";
			Assert::AreEqual(noWinner, battleship.Message, L"A winner has been found while both players have pieces on their boards.");

			// Player 1 lost his piece at row 1, column 1.
			battleship.Board1[0][0] = false;
			battleship.CheckWin();

			string p2Wins = "Player 2 wins!";
			Assert::AreEqual(p2Wins, battleship.Message, L"Player 2 did not win even though he should have.");

			// Player 1 has a piece at row 1, column 1.
			battleship.Board1[0][0] = true;
			// Player 2 lost his piece at row 1, column 1.
			battleship.Board2[0][0] = false;
			battleship.CheckWin();

			string p1Wins = "Player 1 wins!";
			Assert::AreEqual(p1Wins, battleship.Message, L"Player 1 did not win even though he should have.");
		}
	};
}
