#include "stdafx.h"
#include "CppUnitTest.h"
#include "..\..\Battleship\Battleship\Battleship.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace BattleshipTest
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(InitializeTest)
		{
			// Create a 10x10 board for each player that has no pieces on it.
			InitializeBoards();

			for (int i=0; i<Board1.length; i++)
			{
				for (int j = 0; j < Board1[0].length; j++)
				{
					Assert::AreEqual(false, Board1[i][j], L"Board 1 is not initialized properly.");
					Assert::AreEqual(false, Board2[i][j], L"Board 2 is not initialized properly.");
				}
			}
		}

		TEST_METHOD(SetupTest)
		{
			// Assign pieces to each player's board.
			SetupBoards();

			int player1PiecesUsed = 0;
			int player2PiecesUsed = 0;
			for (int i = 0; i<Board1.length; i++)
			{
				for (int j = 0; j < Board1[0].length; j++)
				{
					if (Board1[i][j])
						player1PiecesUsed++;
					if (Board2[i][j])
						player2PiecesUsed++;
				}
			}

			Assert::AreEqual(17, player1PiecesUsed, L"Board 1 is not setup properly.");
			Assert::AreEqual(17, player2PiecesUsed, L"Board 2 is not setup properly.");
		}

		TEST_METHOD(FireTest)
		{
			InitializeBoards();
			
			// Player 1 fires at row 1, column 1.
			Fire(1, 1, 1);
			
			Assert::AreEqual("Player 1 - MISS", Message, L"Player 1's shot hit when it should have missed.");

			// Player 2 has a peice at row 1, column 1.
			Board2[0][0] = true;

			// Player 1 fires at row 1, column 1.
			Fire(1, 1, 1);

			Assert::AreEqual("Player 1 - HIT", Message, L"Player 1's shot missed when it should have hit.");

			// Player 2 fires at row 1, column 1.
			Fire(2 1, 1);

			Assert::AreEqual("Player 2 - MISS", Message, L"Player 2's shot hit when it should have missed.");

			// Player 1 has a piece at row 1, column 1.
			Board1[0][0] = true;

			// Player 2 fires at row 1, column 1.
			Fire(2, 1, 1);

			Assert::AreEqual("Player 2 - HIT", Message, L"Player 2's shot missed when it should have hit.");
		}

		TEST_METHOD(CheckWinTest)
		{
			InitializeBoards();
			SetupBoards();

			// Each player has a piece at row 1, column 1.
			Board1[0][0] = true;
			Board2[0][0] = true;
			// Check if one of the players has won.
			CheckWin();

			Assert::AreEqual("", Message, L"A winner has been found while both players have pieces on their boards.");

			// Player 1 lost his piece at row 1, column 1.
			Board1[0][0] = false;
			CheckWin();

			Assert::AreEqual("Player 2 wins!", Message, L"Player 2 did not win even though he should have.");

			// Player 1 has a piece at row 1, column 1.
			Board1[0][0] = true;
			// Player 2 lost his piece at row 1, column 1.
			Board2[0][0] = false;
			CheckWin();

			Assert::AreEqual("Player 1 wins!", Message, L"Player 1 did not win even though he should have.");
		}
	};
}