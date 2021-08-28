using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.ConsoleChecker;
using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.Toy.Interface;
using ToyRobotSimulator.Board;
using ToyRobotSimulator.Board.Interface;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class BehaviourTest
    {
        /// <summary>
        /// Test a valid place command
        /// </summary> 
        [TestMethod]
        public void TestValidBehaviourPlace()
        {
            IToyBoard squareBoard = new Board.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(4, robot.Position.Y);
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [TestMethod]
        public void TestInvalidBehaviourPlace()
        {
            // arrange
            IToyBoard squareBoard = new Board.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(robot.Position);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [TestMethod]
        public void TestValidBehaviourMove()
        {
            // arrange
            IToyBoard squareBoard = new Board.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", simulator.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [TestMethod]
        public void TestInvalidBehaviourMove()
        {
            // arrange
            IToyBoard squareBoard = new Board.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 2,4,NORTH", simulator.GetReport());
        }

        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [TestMethod]
        public void TestValidBehaviourReport()
        {
            // arrange
            IToyBoard squareBoard = new Board.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
