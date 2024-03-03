using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_EXAMEN
{
    public interface ICommand
    {
        string[] Alias { get; } // Het daadwerkelijke commando (bijv. "clear")
        void Execute(); // Uitvoeren van het commando met de opgegeven parameters
        void SetParameters(Dictionary<string, string> parameters);
    }
}
