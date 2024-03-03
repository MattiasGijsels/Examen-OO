using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLI_EXAMEN.Commands
{
    public class HelpCommand:ICommand
    {   
        public string[] Alias { get; }

        public HelpCommand()
        {
            Alias = ["help", "halp", "save_me"];
        }
        public void SetParameters(Dictionary<string, string> parameters)
        { }
        public void Execute()
        {
            List<ICommand> AllCommands = new List<ICommand>();
            AllCommands = ListBuilder.GetClassList();//haal de lijst op van de listbuilder class
            Console.WriteLine();
            Console.WriteLine("List of Commands:");
            Console.WriteLine("-------------------");
            foreach (var command in AllCommands)
            {
                IList<string> strings = command.Alias;
                string joined = string.Join(",", strings);
                Console.WriteLine();
                Console.WriteLine(joined);
            }
            Console.WriteLine();
        }  
    }
}
