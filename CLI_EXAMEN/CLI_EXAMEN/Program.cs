using System.Drawing;
using System.Text;
using CLI_EXAMEN.Commands;
namespace CLI_EXAMEN

{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Please give your command");
                Console.Write(">");
                string rawInput = Console.ReadLine() ?? "";
                ProcessCommand processcommand = new ProcessCommand(rawInput);
            }
        }
    }
}
