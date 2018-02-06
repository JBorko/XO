using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X_O_Game;

namespace UnitTestProject
{
    [TestClass]
    public class FunctionalTests
    {
        [TestMethod]
        public void TestRessetingTheGame()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.ResetGame();

            Assert.IsTrue(gameEngine.PlayerX.Score == 0);
            Assert.IsTrue(gameEngine.PlayerO.Score == 0);
            Assert.IsTrue(gameEngine.Status == GameStatus.RESETED);
            Assert.IsTrue(gameEngine.ScoreBoard.NumOfGamesPlayed == 0);

            for (int i = 0; i < gameEngine.GameBoard.Fields.GetLength(0); i++)
            {
                for (int j = 0; j < gameEngine.GameBoard.Fields.GetLength(1); j++)
                {
                    Assert.AreEqual((gameEngine.GameBoard.Fields.GetValue(i, j) as Field).State, FieldState.EMPTY);
                }
            }
        }
        //[TestMethod]
        //public void TestThatPlayerOIsTheWinner()
        //{
        //    GameEngine gameEngine = new GameEngine();
        //    gameEngine.ResetGame();

        //    Array fields = gameEngine.GameBoard.Fields;
        //    Assert.AreEqual(gameEngine.PlayerO, gameEngine.CurrentPlayer);
        //    (fields.GetValue(0, 0) as Field).State = FieldState.O;
        //    Assert.AreEqual(gameEngine.PlayerX, gameEngine.CurrentPlayer);
        //    (fields.GetValue(0, 1) as Field).State = FieldState.O;
        //    (fields.GetValue(0, 2) as Field).State = FieldState.O;
        //    Assert.Equals(gameEngine.Status, GameStatus.NEW_GAME);
        //    Assert.Equals(gameEngine.ScoreBoard.GetGameWinner(gameEngine.ScoreBoard.NumOfGamesPlayed - 1), gameEngine.PlayerO);
        //    Assert.IsTrue(gameEngine.ScoreBoard.NumOfGamesPlayed == 1);
        //}
    }

}
