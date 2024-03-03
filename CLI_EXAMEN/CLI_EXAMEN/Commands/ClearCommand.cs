using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_EXAMEN.Commands
{
        public class ClearCommand : ICommand
        {
            public string[] Alias { get; } // Het daadwerkelijke commando (bijv. "clear")

            public ClearCommand()
            {
                Alias = ["clear", "clear", "clean"];
            }
            public void SetParameters(Dictionary<string, string> parameters)
            { }
            public void Execute()
            {
                Console.Clear();
            }
        }
    
}
