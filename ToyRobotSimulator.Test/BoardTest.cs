using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.Board;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class BoardTest
    {
        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [TestMethod]
        public void TestInvalidBoardPosition()
        {
            // arrange
            Board.ToyBoard squareBoard = new Board.ToyBoard(5, 5);
            Position position = new Position(6, 6);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test valid positon 
        /// </summary>
        [TestMethod]
        public void TestValidBoardPosition()
        {
            // arrange
            Board.ToyBoard squareBoard = new Board.ToyBoard(5, 5);
            Position position = new Position(1, 4);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsTrue(result);
        }
    }
}
