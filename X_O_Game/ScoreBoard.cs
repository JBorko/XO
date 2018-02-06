using System;

namespace X_O_Game
{
    public class ScoreBoard
    {
        public int NumOfGamesPlayed { get; set; }
        public Array GameScores = Array.CreateInstance(typeof(Player), 100);

        public ScoreBoard()
        {
            NumOfGamesPlayed = 0;
        }

        public Player GetGameWinner(int index)
        {
            return GameScores.GetValue(index) as Player;
        }
    }
}