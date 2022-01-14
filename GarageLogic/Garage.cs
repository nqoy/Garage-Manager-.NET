namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Ex03.GarageLogic.Enums;

    public class Garage
    {
        private static List<GarageVehicles> s_ListOfGarageVehicles = new List<GarageVehicles>();

        private static GarageVehicles s_GarageVehicleRef = new GarageVehicles();

        public static List<GarageVehicles> ListOfGarageVehicles
        {
            get
            {
                return s_ListOfGarageVehicles;
            }
        }

        public static void AddVehicleToGarage(UserVehicleDetails i_VehicleDetails)
        {
            s_ListOfGarageVehicles.Add(ObjectFactory.CreateVehicle(ref i_VehicleDetails));
        }

        
        public static string ShowGarageVehiclesLicenceNumbers(string i_UserFilterChoiseDigit)
        {
            StringBuilder licenceNumbersStr = new StringBuilder();
            switch (i_UserFilterChoiseDigit)
            {
                case "1":
                    foreach (GarageVehicles garageVehicle in s_ListOfGarageVehicles)
                    {
                        licenceNumbersStr.AppendLine(garageVehicle.Vehicle.LiceneceNumber);
                    }

                    break;

                case "2":
                    foreach (GarageVehicles garageVehicle in s_ListOfGarageVehicles)
                    {
                        if (garageVehicle.VehicleStatus == enumVehicleGarageStatus.eVehicleGarageStatus.InRepair.ToString())
                        {
                            licenceNumbersStr.AppendLine(garageVehicle.Vehicle.LiceneceNumber);
                        }
                    }

                    break;

                case "3":
                    foreach (GarageVehicles garageVehicle in s_ListOfGarageVehicles)
                    {
                        if (garageVehicle.VehicleStatus == enumVehicleGarageStatus.eVehicleGarageStatus.Repaired.ToString())
                        {
                            licenceNumbersStr.AppendLine(garageVehicle.Vehicle.LiceneceNumber);
                        }
                    }

                    break;

                case "4":
                    foreach (GarageVehicles garageVehicle in s_ListOfGarageVehicles)
                    {
                        if (garageVehicle.VehicleStatus == enumVehicleGarageStatus.eVehicleGarageStatus.Paid.ToString())
                        {
                            licenceNumbersStr.AppendLine(garageVehicle.Vehicle.LiceneceNumber);
                        }
                    }

                    break;
            }

            return licenceNumbersStr.ToString();
        }

        public static void ChangeVehicleStatus(int i_vehicleIndex, string i_NewVehicleStatus)
        {
            s_GarageVehicleRef = s_ListOfGarageVehicles.ElementAt(i_vehicleIndex);
            switch (i_NewVehicleStatus)
            {
                case "1":
                    s_GarageVehicleRef.VehicleStatus = enumVehicleGarageStatus.eVehicleGarageStatus.InRepair.ToString();
                    break;
                case "2":
                    s_GarageVehicleRef.VehicleStatus = enumVehicleGarageStatus.eVehicleGarageStatus.Repaired.ToString();
                    break;
                case "3":
                    s_GarageVehicleRef.VehicleStatus = enumVehicleGarageStatus.eVehicleGarageStatus.Paid.ToString();
                    break;
            }
        }

        public static string InflateWheelsToMax(int i_vehicleIndex)
        {
            s_GarageVehicleRef = s_ListOfGarageVehicles.ElementAt(i_vehicleIndex);
            string garageMessage = string.Empty;
            Wheel wheelOfVehicleRef = s_GarageVehicleRef.Vehicle.ListOfWheels.ElementAt(0);
            float wheelsMaxAirPressureRef = wheelOfVehicleRef.MaxAirPressure;
            float currentWheelsAirPressureRef = wheelOfVehicleRef.CurrentAirPressure;
            if (currentWheelsAirPressureRef == wheelsMaxAirPressureRef)
            {
                garageMessage = " Wheels air pressure is alredy full to max";
            }
            else
            {
                float maxFillValue = wheelsMaxAirPressureRef - currentWheelsAirPressureRef;
                Vehicle.InflateWheels(maxFillValue, ref s_GarageVehicleRef);
            }

            return garageMessage;
        }

        public static string FuelVehicle(int i_vehicleIndex, string i_FuelType, float i_LitersToFuel)
        {
            s_GarageVehicleRef = s_ListOfGarageVehicles.ElementAt(i_vehicleIndex);
            string errorMesage = string.Empty;
            try
            {
                if (i_FuelType == s_GarageVehicleRef.Vehicle.Engine.EnergySourceType)
                {
                    float maxCapacityRef = s_GarageVehicleRef.Vehicle.Engine.MaxEnergySourceCapacity;
                    float reminingEnergyRef = s_GarageVehicleRef.Vehicle.Engine.ReminingEnergySource;
                    float minValue = 0;
                    float maxValue = maxCapacityRef - reminingEnergyRef;
                    try
                    {
                        if (reminingEnergyRef + i_LitersToFuel <= maxCapacityRef)
                        {
                            Engine.RefeillEnergySource(i_LitersToFuel, ref s_GarageVehicleRef);
                        }
                        else
                        {
                            throw new ValueOutOfRangeException(minValue, maxValue);
                        }
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        errorMesage = ex.Message;
                    }
                }
                else
                {
                    throw new ArgumentException($"Wrong fuel type, it must be: {s_GarageVehicleRef.Vehicle.Engine.EnergySourceType}");
                }
            }
            catch (ArgumentException ex)
            {
                errorMesage = ex.Message;
            }

            return errorMesage;
        }

        public static string ChargeVehicle(int i_vehicleIndex, float i_NumberOfChargeMinutes)
        {
            s_GarageVehicleRef = s_ListOfGarageVehicles.ElementAt(i_vehicleIndex);
            string errorMesage = string.Empty;
            float maxCapacityRef = s_GarageVehicleRef.Vehicle.Engine.MaxEnergySourceCapacity;
            float reminingEnergyRef = s_GarageVehicleRef.Vehicle.Engine.ReminingEnergySource;
            float minValue = 0;
            float maxValue = maxCapacityRef - reminingEnergyRef;
            try
            {
                if (reminingEnergyRef + i_NumberOfChargeMinutes <= maxCapacityRef)
                {
                    Engine.RefeillEnergySource(i_NumberOfChargeMinutes, ref s_GarageVehicleRef);
                }
                else
                {
                    throw new ValueOutOfRangeException(minValue, maxValue);
                }
            }
            catch (ValueOutOfRangeException ex)
            {
                errorMesage = ex.Message;
            }

            return errorMesage;
        }

        public static string ShowGarageVehicleDetails(int i_vehicleIndex)
        {
            StringBuilder vehicleDetails = new StringBuilder();

            s_GarageVehicleRef = s_ListOfGarageVehicles.ElementAt(i_vehicleIndex);
            vehicleDetails.AppendLine(s_GarageVehicleRef.ToString());
            vehicleDetails.AppendLine(s_GarageVehicleRef.Vehicle.ToString());

            return vehicleDetails.ToString();
        }

        public static string GetVehicleType(int i_vehicleIndex)
        {
            s_GarageVehicleRef = s_ListOfGarageVehicles.ElementAt(i_vehicleIndex);

            return s_GarageVehicleRef.Vehicle.Engine.EngineType;
        }
    }
}
