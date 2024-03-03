using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI_EXAMEN.Commands
{
    public class CopyCommand:ICommand
    {
        public string[] Alias { get; }
        private string source;
        private string target;

        public CopyCommand()
        {
            Alias = ["copy", "transfer", "kopie"];
        }
        public void Execute()
        {
            try 
            {
             File.Copy(source, target, true);
             Console.WriteLine("Mission accomplished");
            } 
            catch(Exception ex)
            { 
            Console.WriteLine(ex.Message);
            }
        }
        public void SetParameters(Dictionary<string,string> parameters) 
        {
 
             if (parameters != null)
             {
                this.source = parameters["source"];//haalt value van source uit parameters dictionary
                this.target = parameters["target"];//haalt value van target uit parameters dictionary
             }
            else
            {
                Console.WriteLine("Please fill in the correct path(s) according to following example: ");
                Console.WriteLine("copy -source C:\\Users\\matti\\TEST_CONSOLE\\tests.txt -target C:\\Users\\matti\\TEST_CONSOLE_DESTINATION\\testsucceeded.txt ");
            }
        }
    }
}
