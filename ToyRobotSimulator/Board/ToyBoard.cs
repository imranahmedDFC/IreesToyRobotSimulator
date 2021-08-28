using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToyRobotSimulator.Toy;
using ToyRobotSimulator.Board.Interface;

namespace ToyRobotSimulator.Board
{
    public class ToyBoard : IToyBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public ToyBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        // Check whether the position specified is inside the boundaries of the square board.
        public bool IsValidPosition(Position position)
        {
            return position.X < Columns && position.X >= 0 &&
                   position.Y < Rows && position.Y >= 0;
        }
    }
}
