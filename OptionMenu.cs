﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class OptionMenu
    {

        private string[] _options;
        private int _selectedIndex;

        public OptionMenu(string[] options)
        {
            _options = options;
            _selectedIndex = 0;
        }

        private void DisplayOptions()
        {
            for(int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];
                string prefix;
                string suffix;


                if (i == _selectedIndex) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    prefix = ">";
                    suffix = "<";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    prefix = suffix = "-";
                }

                Console.WriteLine($"{currentOption}");
            }
            Console.ResetColor();
        
        
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            DisplayOptions();

            do
            {
                Console.SetCursorPosition(0, Console.CursorTop - this._options.Length);
                Console.Write("", Console.BufferWidth);

                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update _selectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow && this._selectedIndex > 0)
                {
                    this._selectedIndex -= 1;
                } 
                else if (keyPressed == ConsoleKey.DownArrow && this._selectedIndex < this._options.Length - 1)
                {
                    this._selectedIndex += 1;
                }
            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }
    }
}
