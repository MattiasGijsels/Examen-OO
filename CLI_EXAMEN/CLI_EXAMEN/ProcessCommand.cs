using CLI_EXAMEN.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI_EXAMEN
{
    public class ProcessCommand
    {
        List<ICommand> ListOfCommands; //common denomenator
        string alias;
        Dictionary<string, string> parameters;
        public void LoadCommand()
        {
            ListOfCommands = ListBuilder.GetClassList();
        }
        public ProcessCommand(string rawInput) //constructor
        {
            LoadCommand();
            ProcessInput(rawInput);
            ExecuteCommand();
        }
        public void ProcessInput(string rawInput)
        {
            if (!string.IsNullOrEmpty(rawInput))
            {
                string[] commands = rawInput.Split(' ');
                if (commands?.Length > 0)
                {
                    this.alias = commands[0];
                    if (commands.Length > 1) //checked aantal elementen in deze array om te detecteren of er parameters zijn voor het commando
                    {
                        var dictionary = new Dictionary<string, string>();
                        for (int i = 1; i < commands.Length; i = i+2)// Loop door de elementen in de array 'commands', te beginnen vanaf het tweede element
                        {                    
                            if (commands[i].StartsWith("-")) //Controleer of het huidige element begint met een streepje(dit geeft de propertyname aan)
                            {
                                string propertyName = commands[i].Substring(1); // verwijder de dash// 1++
                                string propertyValue = commands[i + 1]; //Haal propertyname op, dit is het volgende element in de array
                                dictionary.Add(propertyName.ToLower(), propertyValue.ToLower());
                                // voegt de  combo propertyname and propertyvalue toe aan de dictionary
                            }
                            else
                            {
                                // Indien dit nie het geval is geeft hem de volgende errormessage
                                Console.WriteLine($"Couldn't process your command: {commands[i]}. Please try again");
                            }
                        }
                        this.parameters = dictionary;   
                    }
                }
            } 
        }
        public void ExecuteCommand()
        {
            {
                ICommand foundCommand = null;
                foreach (var command in ListOfCommands) // command = tijdelijke variable in deze functie
                {
                    foreach (string alias in command.Alias) // alias hier is tijdelijke variable 
                    {
                        if (this.alias.ToLower() == alias.ToLower()) // this.alias = userinput (cfr 35), alias grijpt terug naar ICommand Interface die geimplementeerd wordt door clear command
                        {
                            foundCommand = command;
                            break;
                        }
                    }
                }

                if (foundCommand != null)
                {
                    foundCommand.SetParameters(this.parameters);
                    foundCommand.Execute();
                }
                else
                {
                    Console.WriteLine($"Command '{alias}' not found. Please try again with another command");
                }

            }
        }
    }
}
 