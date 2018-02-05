using System;
using X_O_Game;

namespace UnitTestProject
{
    public class GameEngine
    {
        public GameStatus Status { get; set; }
        public Player PlayerO { get; set; }
        public Player PlayerX { get; set; }
        public GameBoard GameBoard { get; set; }

        public GameEngine()
        {
            PlayerO = new Player();
            PlayerX = new Player();
            GameBoard = new GameBoard();
        }

        public void NewGame()
        {
            Status = GameStatus.NEW_GAME;
            PlayerO.Score = 0;
            PlayerX.Score = 0;
            GameBoard.Init();
        }
    }
}