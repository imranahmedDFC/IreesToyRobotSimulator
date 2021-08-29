using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.ConsoleChecker;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class ConsoleCheckerTest
    {
        /// <summary>
        /// Test valid place command
        /// </summary>
        [TestMethod]
        public void TestValidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = inputParser.ParseCommand(rawInput);

            // assert
            Assert.AreEqual(Command.Place, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACETOY".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate 
            { inputParser.ParseCommand(rawInput); });            
            Assert.AreEqual("The command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT", exception.Message);
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [TestMethod]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            var placeCommandParameter = inputParser.ParseCommandParameter(rawInput);

            // assert
            Assert.AreEqual(4, placeCommandParameter.Position.X);
            Assert.AreEqual(3, placeCommandParameter.Position.Y);
            Assert.AreEqual(Direction.West, placeCommandParameter.Direction);
        }

        /// <summary>
        /// Test a place command with an incomplete parameter
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate
            { var placeCommandParameter = inputParser.ParseCommandParameter(rawInput); });
            Assert.AreEqual("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F", exception.Message);
        }

        /// <summary>
        /// Test a place command with an invalid direction
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceDirection()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 2,4,SomeDirection".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.AreEqual("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST", exception.Message);
        }

        /// <summary>
        /// Test a place command with an invalid parameter format
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceParamsFormat()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 3,3,SOUTH,2".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.AreEqual("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F", exception.Message);
        }
    }
}
