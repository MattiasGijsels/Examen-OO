using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_EXAMEN.Commands
{
    public class ExitCommand : ICommand
    {
        public string[] Alias  { get; } // Het daadwerkelijke commando (bijv. "clear")

        public ExitCommand()
        {
          Alias =  ["exit", "quit", "byebye"];
        }
        public void SetParameters(Dictionary<string, string> parameters) 
        { }
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
