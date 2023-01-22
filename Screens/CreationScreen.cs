using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    abstract class CreationScreen : Screen
    {
        protected CreationScreen(App app) : base(app)
        {
        }

        public static void requiredSuffix()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"*");
            Console.ForegroundColor = color;
        }

        public string StringField(string fieldName, bool isRequired)
        {
            string input = InputField(fieldName, isRequired);

            if (isRequired && (input == null || input == ""))
            {
                // Clear the last line upon making an error
                ClearLine();

                StringField(fieldName, isRequired);
            }
            return input;
        }

        //TODO: Lots of code repeated. Try refactoring (parts of) this
        //UPDATE: InputField is poorly named but removes some code duplication.

        public int IntField(string fieldName, bool isRequired)
        {
            string input = InputField(fieldName, isRequired);
            int number = 0; // Default value to stop the compiler from complaining

            if (isRequired && (input == null || input == ""))
            {
                //TODO: Previous input isn't cleared but can be written over. The previous input seemingly does not exist but is shown on screen.
                //It doesn't affect the functioning of the app but it looks bad.
                ClearLine();

                IntField(fieldName, isRequired);
            }
            else
            {
                try
                {
                    return number = short.Parse(input);
                }
                catch
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    IntField(fieldName, isRequired);
                }
            }
            return number;
        }

        //TODO: Add this to a utility class of some kind.
        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public static string InputField(string fieldName, bool isRequired)
        {
            Console.Write($"{fieldName}");
            if (isRequired) requiredSuffix();
            Console.Write(":");

            string input = Console.ReadLine();
            return input;
        }
    }
}
