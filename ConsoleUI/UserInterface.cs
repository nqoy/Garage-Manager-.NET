namespace Console_UI
{
    using System;
    using System.Text;
    using System.Threading;
    using Ex03.ConsoleUI;
    using Ex03.GarageLogic.Enums;

    public class UserInterface
    {
        private static StringBuilder s_MenuStringBuilder = new StringBuilder();
        private static string s_UserInput;
        private static string s_ErrorMassage;

        public static void PrintMenu()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Hello, Welcome to Garage Manager");
            s_MenuStringBuilder.AppendLine("Please choose an action by number:" + Environment.NewLine);
            s_MenuStringBuilder.AppendLine("1.Add a new vehicle to the garage");
            s_MenuStringBuilder.AppendLine("2.Show vehicle license numbers in the garage");
            s_MenuStringBuilder.AppendLine("3.Change a vehicle status");
            s_MenuStringBuilder.AppendLine("4.Inflate a vehicle wheels to max");
            s_MenuStringBuilder.AppendLine("5.Recharge an electric vehicle");
            s_MenuStringBuilder.AppendLine("6.Refuel a vehicle");
            s_MenuStringBuilder.AppendLine("7.Show a vehicle full details");
            s_MenuStringBuilder.AppendLine("0.Exit");
            Console.WriteLine(s_MenuStringBuilder);
        }

        public static string GetVehicleStatuschoiceInput()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please choose the status of the vehicle:");
            s_MenuStringBuilder.AppendLine("1.In Repair");
            s_MenuStringBuilder.AppendLine("2.Repaired");
            s_MenuStringBuilder.AppendLine("3.Paid");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 3);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            return s_UserInput;
        }

        public static void PrintMassage(string i_Massage)
        {
            Console.WriteLine(i_Massage);
        }

        public static string PrintUserChosenMenu(string i_UserMenuChoice)
        {
            s_MenuStringBuilder.Clear();
            if (i_UserMenuChoice.Equals("2"))
            {
                s_UserInput = getFilterchoiceInput();
            }
            else
            {
                s_UserInput = getVehicleLicenseInput();
            }

            return s_UserInput;
        }

        public static void PrintVehicleNotInGarageError()
        {
            Console.WriteLine("There is no existing Vehicle with that license number in the garage");
            Thread.Sleep(2000);
        }

        public static void PrintVehicleInGarageMassage()
        {
            Console.WriteLine($"There vehicle is alredy in the garage, changing status to: {enumVehicleGarageStatus.eVehicleGarageStatus.InRepair.ToString()}");
            Thread.Sleep(3000);
        }

        public static void PrintActionSuccess()
        {
            Console.WriteLine("Action done successfully");
            Thread.Sleep(2000);
        }

        public static void AddNewVehicleToGarage()
        {
            Console.Clear();
            Console.WriteLine("Please enter the model of Vehicle");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckInvaildInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.Model = s_UserInput;
            Console.Clear();

            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please enter type your Vehicle:");
            s_MenuStringBuilder.AppendLine("1.Car");
            s_MenuStringBuilder.AppendLine("2.Motorcycle");
            s_MenuStringBuilder.AppendLine("3.Truck");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 3);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            Console.Clear();

            switch (s_UserInput)
            {
                case "1":
                    GarageManagerLogic.VehicleDetails.VehicleType = (int)enumVehicleType.eVehicleType.Car;
                    addNewCar();
                    break;
                case "2":
                    GarageManagerLogic.VehicleDetails.VehicleType = (int)enumVehicleType.eVehicleType.Motorcycle;
                    addNewMotorcycle();
                    break;
                case "3":
                    GarageManagerLogic.VehicleDetails.VehicleType = (int)enumVehicleType.eVehicleType.Truck;
                    addNewTruck();
                    break;
            }

            Console.WriteLine("Please enter the wheels manufacturer:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckInvaildInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            GarageManagerLogic.VehicleDetails.WheelsManufacturer = s_UserInput;
            Console.Clear();

            Console.WriteLine("Please enter the Remaining Energy percent % in the engine:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 0, 100);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.RemainingEnergy = float.Parse(s_UserInput);
            Console.Clear();

            Console.WriteLine("Please enter your full name:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckInvaildInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.OwnerName = s_UserInput;
            Console.Clear();

            Console.WriteLine("Please enter your number:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckNumbersInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.OwnerPhoneNumber = s_UserInput;
            Console.Clear();

            GarageManagerLogic.VehicleDetails.Status = enumVehicleGarageStatus.eVehicleGarageStatus.InRepair.ToString();
        }

        public static string PrintAndGetTypeOfFuelInputchoice()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please choose the type of fuel for the vehicle");
            s_MenuStringBuilder.AppendLine("1.Soler");
            s_MenuStringBuilder.AppendLine("2.Octan95");
            s_MenuStringBuilder.AppendLine("3.Octan96");
            s_MenuStringBuilder.AppendLine("4.Octan98");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 4);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            return s_UserInput;
        }

        public static string GetSourceAmountInput()
        {
            Console.WriteLine("Please enter the amount to fill");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckNumbersInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            return s_UserInput;
        }

        public static void PrintAddingToGarageSentence()
        {
            Console.WriteLine("Proceeding to add vehicle to garage..." + Environment.NewLine);
            Thread.Sleep(2000);
        }

        public static void PrintExitSentence()
        {
            ClearScreen();
            Console.WriteLine("Goodbye");
            Thread.Sleep(2000);
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void PrintWaitingSentence()
        {
            Console.WriteLine(Environment.NewLine + "Press any key to continue");
            Console.ReadLine();
        }

        private static void addNewCar()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please enter the color of car:");
            s_MenuStringBuilder.AppendLine("1.Red");
            s_MenuStringBuilder.AppendLine("2.White");
            s_MenuStringBuilder.AppendLine("3.Black");
            s_MenuStringBuilder.AppendLine("4.Blue");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 4);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            switch (s_UserInput)
            {
                case "1":
                    GarageManagerLogic.VehicleDetails.CarColor = enumCarProperties.eCarColor.Red.ToString();
                    break;
                case "2":
                    GarageManagerLogic.VehicleDetails.CarColor = enumCarProperties.eCarColor.White.ToString();
                    break;
                case "3":
                    GarageManagerLogic.VehicleDetails.CarColor = enumCarProperties.eCarColor.Black.ToString();
                    break;
                case "4":
                    GarageManagerLogic.VehicleDetails.CarColor = enumCarProperties.eCarColor.Blue.ToString();
                    break;
            }

            Console.Clear();

            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please enter the number of door in the car:");
            s_MenuStringBuilder.AppendLine("1. 2 Doors");
            s_MenuStringBuilder.AppendLine("2. 3 Doors");
            s_MenuStringBuilder.AppendLine("3. 4 Doors");
            s_MenuStringBuilder.AppendLine("4. 5 Doors");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 4);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            switch (s_UserInput)
            {
                case "1":
                    GarageManagerLogic.VehicleDetails.NumberOfDoors = (int)enumCarProperties.eNumberOfDoors.Two;
                    break;
                case "2":
                    GarageManagerLogic.VehicleDetails.NumberOfDoors = (int)enumCarProperties.eNumberOfDoors.Three;
                    break;
                case "3":
                    GarageManagerLogic.VehicleDetails.NumberOfDoors = (int)enumCarProperties.eNumberOfDoors.Four;
                    break;
                case "4":
                    GarageManagerLogic.VehicleDetails.NumberOfDoors = (int)enumCarProperties.eNumberOfDoors.Five;
                    break;
            }

            Console.Clear();

            checkEngineType();

            Console.WriteLine("Please enter the air pressure of all wheels:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 0, 30);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.CurrentWheelsAirPressure = float.Parse(s_UserInput);
            Console.Clear();
        }

        private static void addNewMotorcycle()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please enter License Type:");
            s_MenuStringBuilder.AppendLine("1.B");
            s_MenuStringBuilder.AppendLine("2.AA");
            s_MenuStringBuilder.AppendLine("3.A2");
            s_MenuStringBuilder.AppendLine("4.A");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 4);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            switch (s_UserInput)
            {
                case "1":
                    GarageManagerLogic.VehicleDetails.LicenseType = enumMotorcycleLicense.eLicense.B.ToString();
                    break;
                case "2":
                    GarageManagerLogic.VehicleDetails.LicenseType = enumMotorcycleLicense.eLicense.AA.ToString();
                    break;
                case "3":
                    GarageManagerLogic.VehicleDetails.LicenseType = enumMotorcycleLicense.eLicense.A2.ToString();
                    break;
                case "4":
                    GarageManagerLogic.VehicleDetails.LicenseType = enumMotorcycleLicense.eLicense.A.ToString();
                    break;
            }

            Console.Clear();

            Console.WriteLine("Please enter Engine Volume (number):");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 0, 2000);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.EngineVolume = int.Parse(s_UserInput);
            Console.Clear();

            checkEngineType();

            Console.WriteLine("Please enter the air pressure of all wheels:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 0, 29);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.CurrentWheelsAirPressure = float.Parse(s_UserInput);
            Console.Clear();
        }

        private static void checkEngineType()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please enter type your engine:");
            s_MenuStringBuilder.AppendLine("1.Fuel engine");
            s_MenuStringBuilder.AppendLine("2.Electric engine");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 2);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            switch (s_UserInput)
            {
                case "1":
                    GarageManagerLogic.VehicleDetails.EngineType = enumEngineTypes.eEngineTypes.Fuel.ToString();
                    break;
                case "2":
                    GarageManagerLogic.VehicleDetails.EngineType = enumEngineTypes.eEngineTypes.Electric.ToString();
                    break;
            }

            Console.Clear();
        }

        private static void addNewTruck()
        {
            Console.WriteLine("Please enter Cargo Capacity:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 0, 1000);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.CargoCapacity = float.Parse(s_UserInput);
            Console.Clear();

            Console.WriteLine("Can a truck transport refrigerated contents? [Y/N]");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckYesOrNoInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            if (s_UserInput == "Y")
            {
                s_UserInput = "true";
            }
            else
            {
                s_UserInput = "false";
            }

            GarageManagerLogic.VehicleDetails.CarringColdCargo = bool.Parse(s_UserInput);

            Console.Clear();

            Console.WriteLine("Please enter the air pressure of all wheels:");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 0, 25);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);
            GarageManagerLogic.VehicleDetails.CurrentWheelsAirPressure = float.Parse(s_UserInput);
            Console.Clear();
        }

        private static string getVehicleLicenseInput()
        {
            Console.WriteLine($"Please enter the Vehicle License Number of 6 digits or letters{Environment.NewLine}******");
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckVehicleLicenceInput(s_UserInput);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            return s_UserInput;
        }

        private static string getFilterchoiceInput()
        {
            s_MenuStringBuilder.Clear();
            s_MenuStringBuilder.AppendLine("Please choose an action by number:");
            s_MenuStringBuilder.AppendLine("1.Show all Vehicles");
            s_MenuStringBuilder.AppendLine("2.Show Vehicles in repair");
            s_MenuStringBuilder.AppendLine("3.Show repaired Vehicles");
            s_MenuStringBuilder.AppendLine("4.Show paid Vehicles");
            Console.WriteLine(s_MenuStringBuilder);
            do
            {
                s_UserInput = Console.ReadLine();
                s_ErrorMassage = InputRulescheck.CheckUserMenuChoice(s_UserInput, 1, 4);
                if (s_ErrorMassage.Length > 0)
                {
                    Console.WriteLine(s_ErrorMassage);
                }
            }
            while (s_ErrorMassage.Length > 0);

            return s_UserInput;
        }
    }
}
