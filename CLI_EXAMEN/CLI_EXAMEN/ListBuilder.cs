using CLI_EXAMEN.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_EXAMEN
{
    public class ListBuilder
    {
        public static List<ICommand> GetClassList() 
        {
            HelpCommand helpCommand = new HelpCommand();
            CopyCommand copyCommand = new CopyCommand();
            ExitCommand exitCommand = new ExitCommand();
            ClearCommand clearCommand = new ClearCommand();
            ColorCommand colorCommand = new ColorCommand();
            List<ICommand> ListOfCommands = new List<ICommand>();
            ListOfCommands.Add(helpCommand);
            ListOfCommands.Add(copyCommand);
            ListOfCommands.Add(exitCommand);
            ListOfCommands.Add(clearCommand);
            ListOfCommands.Add(colorCommand);
            return ListOfCommands;
        }
    }
}
