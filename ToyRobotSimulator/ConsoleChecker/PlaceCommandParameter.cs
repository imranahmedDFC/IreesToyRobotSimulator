using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.ConsoleChecker
{
    public class PlaceCommandParameter
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
