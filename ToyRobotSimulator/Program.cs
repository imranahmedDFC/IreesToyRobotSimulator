using System;
using ToyRobotSimulator.ConsoleChecker;
using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.Toy.Interface;
using ToyRobotSimulator.Board.Interface;

namespace ToyRobotSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string description =
                @"
                  **************************************
                  **                                  **
                  **        TOY ROBOT SIMULATOR       **
                  **                                  **
                  **************************************
                 
                     Welcome! 

                  1: Place the toy on a 5 x 5 grid
                     using the following command: 

                     PLACE X,Y,F (Where X and Y are integers and F 
                     must be either NORTH, SOUTH, EAST or WEST)

                  2: When the toy is placed, have at go at using
                     the following commands.
                
                     REPORT – Shows the current status of the toy. 
                     LEFT   – turns the toy 90 degrees left.
                     RIGHT  – turns the toy 90 degrees right.
                     MOVE   – Moves the toy 1 unit in the facing direction.
                     EXIT   – Closes the toy Simulator.
                ";

            IToyBoard squareBoard = new Board.ToyBoard(5, 5);
            IInputParser inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var simulator = new Behaviours.Behaviour(robot, squareBoard, inputParser);

            var stopApplication = false;
            Console.WriteLine(description);
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.ToUpper().Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
