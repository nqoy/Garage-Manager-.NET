namespace Ex03.ConsoleUI
{
    using System;
    using Console_UI;
    using Ex03.GarageLogic;
    using Ex03.GarageLogic.Enums;

    public class GarageManagerLogic
    {
        private static UserVehicleDetails s_VehicleDetails = new UserVehicleDetails();
        private static string s_UserCurrentVehicleLicenseInput;
        private static bool s_IsCurrentVehicleInGarage;
        private static int s_CurrentVehicleIndexInList;

        public static UserVehicleDetails VehicleDetails
        {
            get
            {
                return s_VehicleDetails;
            }
        }

        public static void ActiveMenuChoice(string i_UserMenuChoice)
        {
            switch (i_UserMenuChoice)
            {
                case "0":
                    GarageProgram.IsProgramOn = false;
                    break;

                case "1":
                    UserInterface.PrintMassage($"[Add_Vehicle_To_Garage]{Environment.NewLine}");
                    choiceAddVehicleToGarage(i_UserMenuChoice);
                    break;

                case "2":
                    UserInterface.PrintMassage($"[Show_Vehicles_License_Numbers]{Environment.NewLine}");
                    choiceShowVehicleLicenseNumbers(i_UserMenuChoice);
                    break;

                case "3":
                    UserInterface.PrintMassage($"[Change_Vehicle_Status]{Environment.NewLine}");
                    choiceVehicleStatusChange(i_UserMenuChoice);
                    break;

                case "4":
                    UserInterface.PrintMassage($"[Inflate_Wheels_To_Max_Air_Pressure]{Environment.NewLine}");
                    choiceInflateWheelsToMax(i_UserMenuChoice);
                    break;

                case "5":
                    UserInterface.PrintMassage($"[Recharge_Vehicle]:{Environment.NewLine}");
                    getAndSendEnergySourceFillAmont(i_UserMenuChoice);
                    break;

                case "6":
                    UserInterface.PrintMassage($"[Refuel_Vehicle]{Environment.NewLine}");
                    getAndSendEnergySourceFillAmont(i_UserMenuChoice);
                    break;

                case "7":
                    UserInterface.PrintMassage($"[Show_Vehicle_Details]{Environment.NewLine}");
                    choiceShowVehicleDetails(i_UserMenuChoice);
                    break;
            }
        }

        private static void choiceAddVehicleToGarage(string i_UserMenuChoice)
        {
            s_UserCurrentVehicleLicenseInput = UserInterface.PrintUserChosenMenu(i_UserMenuChoice);
            s_CurrentVehicleIndexInList = isVehicleInGarageCheckAndUpdate();
            if (s_IsCurrentVehicleInGarage)
            {
                Garage.ChangeVehicleStatus(s_CurrentVehicleIndexInList, ((int)enumVehicleGarageStatus.eVehicleGarageStatus.InRepair).ToString());
                UserInterface.PrintVehicleInGarageMassage();
            }
            else
            {
                VehicleDetails.License = s_UserCurrentVehicleLicenseInput;
                UserInterface.PrintAddingToGarageSentence();
                UserInterface.AddNewVehicleToGarage();
                Garage.AddVehicleToGarage(VehicleDetails);
                UserInterface.PrintActionSuccess();
            }
        }

        private static void choiceShowVehicleLicenseNumbers(string i_UserMenuChoice)
        {
            string s_UserMenuChoiseInput = UserInterface.PrintUserChosenMenu(i_UserMenuChoice);
            string listOfLicenceNumbers = Garage.ShowGarageVehiclesLicenceNumbers(s_UserMenuChoiseInput);

            UserInterface.PrintMassage(listOfLicenceNumbers);
            UserInterface.PrintWaitingSentence();
        }

        private static void choiceVehicleStatusChange(string i_UserMenuChoice)
        {
            s_UserCurrentVehicleLicenseInput = UserInterface.PrintUserChosenMenu(i_UserMenuChoice);
            s_CurrentVehicleIndexInList = isVehicleInGarageCheckAndUpdate();
            if (s_IsCurrentVehicleInGarage)
            {
                string userVehicleStatusChoise = UserInterface.GetVehicleStatuschoiceInput();

                Garage.ChangeVehicleStatus(s_CurrentVehicleIndexInList, userVehicleStatusChoise);
                UserInterface.PrintActionSuccess();
            }
        }

        private static void choiceInflateWheelsToMax(string i_UserMenuChoice)
        {
            s_UserCurrentVehicleLicenseInput = UserInterface.PrintUserChosenMenu(i_UserMenuChoice);
            s_CurrentVehicleIndexInList = isVehicleInGarageCheckAndUpdate();
            if (s_IsCurrentVehicleInGarage)
            {
                string s_GarageManagerErrorMassege = Garage.InflateWheelsToMax(s_CurrentVehicleIndexInList);

                UserInterface.PrintActionSuccess();
            }
        }

        private static void getAndSendEnergySourceFillAmont(string i_UserMenuChoice)
        {
            s_UserCurrentVehicleLicenseInput = UserInterface.PrintUserChosenMenu(i_UserMenuChoice);
            s_CurrentVehicleIndexInList = isVehicleInGarageCheckAndUpdate();
            if (s_IsCurrentVehicleInGarage)
            {
                string garageManagerErrorMassege = string.Empty;
                float fillAmount;
                bool isWrongMenuChoice = true;

                do
                {
                    string engineType = Garage.GetVehicleType(s_CurrentVehicleIndexInList);

                    switch (i_UserMenuChoice)
                    {
                        case "5":

                            if (engineType.Equals(enumEngineTypes.eEngineTypes.Electric.ToString()))
                            {
                                fillAmount = userEnergySourceFillInput();
                                garageManagerErrorMassege = Garage.ChargeVehicle(s_CurrentVehicleIndexInList, fillAmount);
                            }
                            else
                            {
                                if (isWrongMenuChoice)
                                {
                                    UserInterface.PrintMassage($"Wrong menu choice: this vehicle runs on fuel! redirected to refuling the vehicle...");
                                    isWrongMenuChoice = false;
                                }

                                string fuelType = getFuelTypeChoiceInput();

                                fillAmount = userEnergySourceFillInput();
                                garageManagerErrorMassege = Garage.FuelVehicle(s_CurrentVehicleIndexInList, fuelType, fillAmount);
                            }

                            break;

                        case "6":
                            if (engineType.Equals(enumEngineTypes.eEngineTypes.Fuel.ToString()))
                            {
                                string fuelType = getFuelTypeChoiceInput();

                                fillAmount = userEnergySourceFillInput();
                                garageManagerErrorMassege = Garage.FuelVehicle(s_CurrentVehicleIndexInList, fuelType, fillAmount);
                            }
                            else
                            {
                                if (isWrongMenuChoice)
                                {
                                    UserInterface.PrintMassage("Wrong menu choice: this is an electric vehicle! redirected to charging the vehicle...");
                                    isWrongMenuChoice = false;
                                }

                                fillAmount = userEnergySourceFillInput();
                                garageManagerErrorMassege = Garage.ChargeVehicle(s_CurrentVehicleIndexInList, fillAmount);
                            }

                            break;
                    }

                    if (garageManagerErrorMassege.Length > 1)
                    {
                        UserInterface.PrintMassage(garageManagerErrorMassege);
                    }
                }
                while (garageManagerErrorMassege.Length > 1);
                UserInterface.PrintActionSuccess();
            }
        }

        private static void choiceShowVehicleDetails(string i_UserMenuChoice)
        {
            s_UserCurrentVehicleLicenseInput = UserInterface.PrintUserChosenMenu(i_UserMenuChoice);
            s_CurrentVehicleIndexInList = isVehicleInGarageCheckAndUpdate();
            if (s_IsCurrentVehicleInGarage)
            {
                UserInterface.PrintMassage(Garage.ShowGarageVehicleDetails(s_CurrentVehicleIndexInList));
                UserInterface.PrintWaitingSentence();
            }
        }

        private static int isVehicleInGarageCheckAndUpdate()
        {
            int countVehicleIndex = 0;
            int vehicleIndex = -1;

            s_IsCurrentVehicleInGarage = false;
            if (Garage.ListOfGarageVehicles.Count != 0)
            {
                foreach (GarageVehicles garageVehicle in Garage.ListOfGarageVehicles)
                {
                    if (garageVehicle.Vehicle.LiceneceNumber.Equals(s_UserCurrentVehicleLicenseInput))
                    {
                        s_IsCurrentVehicleInGarage = true;
                        vehicleIndex = countVehicleIndex;
                        break;
                    }

                    countVehicleIndex++;
                }
            }

            if (!s_IsCurrentVehicleInGarage)
            {
                UserInterface.PrintVehicleNotInGarageError();
            }

            return vehicleIndex;
        }

        private static string getFuelTypeChoiceInput()
        {
            string fuelType = UserInterface.PrintAndGetTypeOfFuelInputchoice();

            switch (fuelType)
            {
                case "1":
                    fuelType = enumFuelTypes.eFuelType.Soler.ToString();
                    break;

                case "2":
                    fuelType = enumFuelTypes.eFuelType.Octan95.ToString();
                    break;

                case "3":
                    fuelType = enumFuelTypes.eFuelType.Octan96.ToString();
                    break;

                case "4":
                    fuelType = enumFuelTypes.eFuelType.Octan98.ToString();
                    break;
            }

            return fuelType;
        }

        private static float userEnergySourceFillInput()
        {
            string userEnergySourceAmountInput = UserInterface.GetSourceAmountInput();
            float fillAmount = float.Parse(userEnergySourceAmountInput);

            return fillAmount;
        }
    }
}
