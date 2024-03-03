using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_EXAMEN.Commands
{
    public class ColorCommand : ICommand
    {
        public string[] Alias { get; }
        private string change;
        private ConsoleColor currentCursorColor;
        private ConsoleColor backgroundColor;
        private ConsoleColor foregroundColor;

        public void Execute()
        {
            if (change == "background") 
            {
                SetBackgroundColor();
            }
            else if (change == "foreground")
            {
                SetForegroundColor();
            }
        }
        public void SetParameters(Dictionary<string, string> parameters) 
        {
            try 
            {
                if (parameters != null)
                {
                    this.change = parameters["change"];//haalt value van filename uit parameters dictionary
                }
            } 
            catch(Exception)
            {
                Console.WriteLine("Please fill in the correct parameter which is change");
            }

        }
        public ColorCommand()
        {
            Alias = ["color", "colour", "kleur", "consolekleur"];
            currentCursorColor = ConsoleColor.Green;
            backgroundColor = ConsoleColor.Black;
            foregroundColor = ConsoleColor.White;
        }
        public void SetBackgroundColor()
        {
            Console.Write("Enter the new background color: ");
            string color = Console.ReadLine() ?? "";
            if (Enum.TryParse<ConsoleColor>(color, true, out ConsoleColor newColor) && newColor != this.foregroundColor)
            {
                Console.BackgroundColor = newColor;
                backgroundColor = newColor;
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"The color '{color}' is not valid ");
            }
        }
        public void  SetForegroundColor()
        {
            Console.Write("Enter the new forground color: ");
            string color = Console.ReadLine() ?? "";
            if (Enum.TryParse<ConsoleColor>(color, true, out ConsoleColor newColor) && newColor != backgroundColor)
            {
                Console.ForegroundColor = newColor;
                foregroundColor= newColor;
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"The color '{color}' is not valid ");
            }
        }
    }
}
