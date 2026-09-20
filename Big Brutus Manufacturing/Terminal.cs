using System;
using System.Reflection;
using System.Security.Cryptography;

namespace Big_Brutus_Manufacturing
{
    public class Terminal
    {
        private ConsoleColor _highlightColor = ConsoleColor.Blue;

        public List<string> menuOptions = new List<string>();

        private string currentMenu = "Main Menu";

        private List<string> baseOptions = new List<string>();


        private List<string> history = new List<string>();

        private int selectedOption = 0;

        public Terminal() {
            baseOptions.Add("Campus");
            baseOptions.Add("Building");
            baseOptions.Add("Zone");
            this.menuOptions = baseOptions;
            history.Add("Menu");
            RenderScreen();
            
        }

        private string MenuHistory()
        {
            string longstring = "";
            foreach (string element in history)
            {
                longstring = longstring + ">" + element;
            }
            return longstring;
        }

        public List<string> MenuOptions()
        {
            string[] classes = { "Building", "Campus", "HardwareComponent", "Zone" };

            List<string> options = new List<string>();

            if (classes.Contains(currentMenu))
            {
                Type type = Type.GetType($"Big_Brutus_Manufacturing.{currentMenu}");

                MethodInfo[] myArrayMethodInfo = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly); //https://learn.microsoft.com/en-us/dotnet/api/system.type.getmethods?view=net-10.0

                foreach (MethodInfo myMethod in myArrayMethodInfo)
                {
                    options.Add(myMethod.Name);
                }
                return options;
            }
            else
                currentMenu = "Menu";
                return baseOptions; //Return baseoptions if there are no options
            
        }


        public void RenderScreen()
        {
            //basic rendering
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{MenuHistory()}");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;


            //rendering of selectable options
            menuOptions = MenuOptions();

            foreach (var option in menuOptions)
            {
                if (option == menuOptions[selectedOption])
                {
                    Console.ForegroundColor = _highlightColor;
                    Console.WriteLine($"[{(selectedOption + 1)}]{(option)}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"[{(menuOptions.IndexOf(option) +1)}]{option}");
                    Console.WriteLine("");
                }
                
            }


            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if ((selectedOption + 1) == menuOptions.Count)
                    {

                        RenderScreen();

                    }
                    else
                    {
                        selectedOption++;
                    }
                    RenderScreen();
                    break;

                case ConsoleKey.UpArrow:
                    if (selectedOption == 0) { RenderScreen(); }
                    else
                    {
                        selectedOption--;
                    }
                    RenderScreen();
                    break;

                case ConsoleKey.Enter:
                    currentMenu = menuOptions[selectedOption];
                    history.Add(currentMenu);
                    RenderScreen();
                    break;

                case ConsoleKey.Backspace:
                    if (history.Any() & history.Count > 1) 
                    {
                        history.Remove(history.Last());
                        currentMenu = history.Last();
                       
                    }
                    
                    RenderScreen();
                    break;
                
                default:
                    RenderScreen(); break;

            }
            
        }
    }
}