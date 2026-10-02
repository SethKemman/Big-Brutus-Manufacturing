using System;
using System.Reflection;
using System.Security.Cryptography;
using static Big_Brutus_Manufacturing.Program;

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
            baseOptions.Add("Campus Diagnose");
            baseOptions.Add("Bereken totaal energieverbruik");
            baseOptions.Add("Zie meldingen");
            baseOptions.Add("Wipe Logboek");
            this.menuOptions = baseOptions;
            RenderScreen();
            
        }

        public List<string> MenuOptions()
        {
           currentMenu = "Menu";
           return baseOptions; //Return baseoptions if there are no options
            
        }

        private void CampusDiagnose()
        {
            foreach (Building building in Globals.campus.Buildings)
            {
                foreach (Zone zone in building.Zones) {
                    foreach (HardwareComponent hardwareComponent in zone.HardwareComponents) {
                        hardwareComponent.VoerDiagnoseUit();
                        }
                }
            }
        }

        private double BerekenTotaalEnergieVerbruik()
        {
            double result = 0;
            foreach (Building building in Globals.campus.Buildings)
            {
                foreach (Zone zone in building.Zones)
                {
                    foreach (HardwareComponent hardwareComponent in zone.HardwareComponents)
                    {
                        result += hardwareComponent.PowerUsage;
                    }
                }
            }
            return result;
        }


        public void RenderScreen()
        {
            //basic rendering
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;


            //rendering of selectable options
            menuOptions = MenuOptions();

            foreach (var option in menuOptions)
            {
                if (option == menuOptions[selectedOption])
                {
                    Console.ForegroundColor = _highlightColor;
                    Console.WriteLine($"[{(selectedOption + 1)}] {(option)}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"[{(menuOptions.IndexOf(option) +1)}] {option}");
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
                    switch(currentMenu)
                    {
                        case "Campus Diagnose":
                            CampusDiagnose();
                            Console.WriteLine("Succes");
                            Thread.Sleep(2000);
                            break;

                        case "Bereken totaal energieverbruik":
                           double totaal = BerekenTotaalEnergieVerbruik();
                            Console.WriteLine($"{totaal / 1000} kWh");
                            Thread.Sleep(2000);
                            break;

                        case "Zie meldingen":
                            foreach (Meting meting in Globals.MetingLogbook.Logs)
                            {
                                
                                if (meting.Level == Level.Warning)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{meting.Level}: {meting.Content} @ {meting.time}");
                                }
                                else if (meting.Level == Level.Critical)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{meting.Level}: {meting.Content} @ {meting.time}");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"{meting.Level}: {meting.Content} @ {meting.time}");
                                }
                            }
                            Thread.Sleep(2000);
                            break;
                        case "Wipe Logboek":
                            Globals.MetingLogbook.Wipe();
                            break;
                        default:
                            return;

                    }
                    RenderScreen();
                    break;

                case ConsoleKey.Backspace:
                    
                    RenderScreen();
                    break;
                
                default:
                    RenderScreen(); break;

            }
            
        }
    }
}