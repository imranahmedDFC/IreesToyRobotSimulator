using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.ConsoleChecker.Interface
{
    public interface IInputParser
    {
        Command ParseCommand(string[] rawInput);

        // This extracts the parameters from the user's input.        
        PlaceCommandParameter ParseCommandParameter(string[] input);
    }
}
