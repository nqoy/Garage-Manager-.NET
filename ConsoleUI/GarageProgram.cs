namespace Ex03.ConsoleUI
{
    using System;
    using Console_UI;

    public class GarageProgram
    {
        private static bool s_IsProgramOn = true;

        public static bool IsProgramOn
        {
            get
            {
                return s_IsProgramOn;
            }

            set
            {
                s_IsProgramOn = value;
            }
        }

        public static void Run()
        {
            string userInput, inputErrorMassage;

            do
            {
                UserInterface.ClearScreen();
                UserInterface.PrintMenu();
                do
                {
                    userInput = Console.ReadLine();
                    inputErrorMassage = InputRulescheck.CheckUserMenuChoice(userInput, 0, 7);
                    if (inputErrorMassage.Length > 0)
                    {
                        if (inputErrorMassage == "0")
                        {
                            break;
                        }

                        UserInterface.PrintMassage(inputErrorMassage);
                    }
                }
                while (inputErrorMassage.Length > 0);
                UserInterface.ClearScreen();
                GarageManagerLogic.ActiveMenuChoice(userInput);
            }
            while (s_IsProgramOn);
            UserInterface.PrintExitSentence();
        }
    }
}
