using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X_O_Game;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    { 

        [TestMethod]
        public void TestScoresAreZeroAtBeginningOfGame()
        {
            GameEngine _gameEngine = new GameEngine();
            _gameEngine.NewGame();
            Assert.IsTrue(_gameEngine.PlayerX.Score == 0);
            Assert.IsTrue(_gameEngine.PlayerO.Score == 0);
            Assert.IsTrue(_gameEngine.Status == GameStatus.NEW_GAME);
        }

        [TestMethod]
        public void TestThatGameBoardIsEmptyAtBeginning()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.NewGame();
            int j = 0;
            for (int i = 0; i < gameEngine.GameBoard.Fields.GetLength(0); i++)
            {
                for (; j < gameEngine.GameBoard.Fields.GetLength(1); j++)
                {
                    Assert.AreEqual((gameEngine.GameBoard.Fields.GetValue(i,j) as Field).State, FieldState.EMPTY);
                }
            }
        }
    }
}
