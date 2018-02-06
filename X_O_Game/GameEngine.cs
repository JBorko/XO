using System;
using X_O_Game;

namespace X_O_Game
{
    public class GameEngine
    {
        public GameStatus Status { get; set; }
        public Player PlayerO { get; set; }
        public Player PlayerX { get; set; }
        public GameBoard GameBoard { get; set; }
        public ScoreBoard ScoreBoard { get; set; }
        public Player CurrentPlayer { get; set; }

        public GameEngine()
        {
            this.PlayerO = new Player();
            this.PlayerX = new Player();
            this.GameBoard = new GameBoard();
            this.ScoreBoard = new ScoreBoard();
            ResetGame();
        }

        public void ResetGame()
        {
            Status = GameStatus.RESETED;
            PlayerO.Score = 0;
            PlayerX.Score = 0;
            GameBoardInit();
            this.ScoreBoard.NumOfGamesPlayed = 0;
            CurrentPlayer = PlayerO;
        }

        public void NewGame()
        {
            this.ScoreBoard.NumOfGamesPlayed++;
            Status = GameStatus.NEW_GAME;
            GameBoardInit();
        }

        private void GameBoardInit()
        {
            GameBoard.Init();
            Array Fields = GameBoard.Fields;
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    (Fields.GetValue(i, j) as Field).StatusChanged += Field_StatusChanged;
                }
            }
        }

        private void Field_StatusChanged(object sender, StatusChangedArgs e)
        {
            if (e.CurrentState == FieldState.O)
            {
                // Search for O-xes
                if (CheckIsScoredWin(FieldState.O))
                {
                    PlayerO.Score++;
                    ScoreBoard.GameScores.SetValue(PlayerO, ScoreBoard.NumOfGamesPlayed + 1);
                    NewGame();
                    return;
                }
                else
                {
                    // PlayerX's turn
                    CurrentPlayer = PlayerX;
                    return;
                }
            }
            else
            {
                // Search for X-es
                // Search for O-xes
                if (CheckIsScoredWin(FieldState.X))
                {
                    PlayerX.Score++;
                    ScoreBoard.GameScores.SetValue(PlayerX, ScoreBoard.NumOfGamesPlayed + 1);
                    NewGame();
                    return;
                }
                else
                {
                    // PlayerO's turn
                    CurrentPlayer = PlayerO;
                    return;
                }
            }
        }

        private bool CheckIsScoredWin(FieldState state)
        {
            Array Fields = GameBoard.Fields;
            // Search for O
            if ((Fields.GetValue(0, 0) as Field).State == state &&
                (Fields.GetValue(0, 1) as Field).State == state &&
                (Fields.GetValue(0, 2) as Field).State == state)
            {
                // PlayerO is winner
                return true;
            }
            else if ((Fields.GetValue(1, 0) as Field).State == state &&
                (Fields.GetValue(1, 1) as Field).State == state &&
                (Fields.GetValue(1, 2) as Field).State == state)
            {
                return true;
            }

            else if ((Fields.GetValue(2, 0) as Field).State == state &&
                (Fields.GetValue(2, 1) as Field).State == state &&
                (Fields.GetValue(2, 2) as Field).State == state)
            {
                return true;
            }
            else if ((Fields.GetValue(0, 0) as Field).State == state &&
                (Fields.GetValue(1, 0) as Field).State == state &&
                (Fields.GetValue(2, 0) as Field).State == state)
            {
                return true;
            }
            else if ((Fields.GetValue(0, 1) as Field).State == state &&
                (Fields.GetValue(1, 1) as Field).State == state &&
                (Fields.GetValue(2, 1) as Field).State == state)
            {
                return true;
            }
            else if ((Fields.GetValue(0, 2) as Field).State == state &&
                (Fields.GetValue(1, 2) as Field).State == state &&
                (Fields.GetValue(2, 2) as Field).State == state)
            {
                return true;
            }
            else if ((Fields.GetValue(0, 0) as Field).State == state &&
                (Fields.GetValue(1, 1) as Field).State == state &&
                (Fields.GetValue(2, 2) as Field).State == state)
            {
                return true;
            }
            else if ((Fields.GetValue(2, 0) as Field).State == state &&
                (Fields.GetValue(1, 1) as Field).State == state &&
                (Fields.GetValue(0, 2) as Field).State == state)
            {
                return true;
            }

            if(Status != GameStatus.IN_PROGRESS)
                Status = GameStatus.IN_PROGRESS;
            return false;
        }
    }
}