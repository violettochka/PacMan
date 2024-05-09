using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class EntitiesSettings
    {
        public ConsoleColor ColorForPacman(string color) 
        {
            var availibleColors = new Dictionary<string, ConsoleColor>()
            {
                { "white" , ConsoleColor.White},
                { "green" , ConsoleColor.Green}, 
                { "blue" , ConsoleColor.Cyan},
            };

            if(availibleColors.TryGetValue(color, out var matchColor))
            {
                return matchColor;
            }
            return ConsoleColor.Cyan;

        }
    }
}
