namespace Ex03.ConsoleUI
{
    using System;
    using Ex03.GarageLogic;

    public class InputRulescheck
    {
        private static string s_InputErrorMassage;

        public static string CheckUserMenuChoice(string i_MenuChoiceInput, int i_choiceMinValue, int i_choiceMaxValue)
        {
            s_InputErrorMassage = CheckNumbersInput(i_MenuChoiceInput);
            int userDigitInput = -1;

            if (s_InputErrorMassage.Length == 0)
            {
                try
                {
                    userDigitInput = int.Parse(i_MenuChoiceInput);
                }
                catch (FormatException formatException)
                {
                    s_InputErrorMassage = $"{formatException.Message + Environment.NewLine}please enter integers only";
                }

                try
                {
                    if (userDigitInput < i_choiceMinValue || userDigitInput > i_choiceMaxValue)
                    {
                        throw new ValueOutOfRangeException(i_choiceMinValue, i_choiceMaxValue);
                    }
                    else if (userDigitInput == 0)
                    {
                        s_InputErrorMassage = i_MenuChoiceInput;
                    }
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    s_InputErrorMassage = valueOutOfRangeException.Message;
                }
            }

            return s_InputErrorMassage;
        }

        public static string CheckVehicleLicenceInput(string i_VehicleLicenceInput)
        {
            s_InputErrorMassage = string.Empty;
            if (i_VehicleLicenceInput.Length != 6)
            {
                s_InputErrorMassage = "Please enter 6 digits or letters";
            }

            return s_InputErrorMassage;
        }

        public static string CheckNumbersInput(string i_UserInput)
        {
            s_InputErrorMassage = string.Empty;
            try
            {
                if (float.Parse(i_UserInput) < 0)
                {
                    s_InputErrorMassage = $"Invailed negetive number";
                }
            }
            catch (FormatException formatException)
            {
                s_InputErrorMassage = $"{formatException.Message + Environment.NewLine}please enter digits only";
            }

            return s_InputErrorMassage;
        }

        public static string CheckYesOrNoInput(string i_UserInput)
        {
            s_InputErrorMassage = string.Empty;
            try
            {
                if (i_UserInput != "Y" && i_UserInput != "N")
                {
                    throw new ArgumentException("Wrong input please enter uppercase Y <Yes> or N <No>");
                }
            }
            catch (ArgumentException ex)
            {
                s_InputErrorMassage = ex.Message;
            }

            return s_InputErrorMassage;
        }

        public static string CheckInvaildInput(string i_UserInput)
        {
            string userTrimedInput = i_UserInput.Trim();

            s_InputErrorMassage = string.Empty;
            if (userTrimedInput.Length == 0)
            {
                s_InputErrorMassage = "Invaild input";
            }

            return s_InputErrorMassage;
        }
    }
}
