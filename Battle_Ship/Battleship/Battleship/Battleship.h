#pragma once
#ifdef BATTLESHIP_EXPORTS
#define BATTLESHIP_API _declspec(dllexport)
#else
#define BATTLESHIP_API _declspec(dllimport)
#endif

// This class is exported from the Battleship.dll
class BATTLESHIP_API Battleship {
public:
	// TODO: add your methods heree.
};