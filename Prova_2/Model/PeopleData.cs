namespace Prova_2.Model;

public class PeopleData
{
    public PeopleData(int age, string gender, int drivingExperience, string education, string income, int vehicleYear, string vehicleType, string annualMileage)
    {
        Age = age;
        Gender = gender;
        DrivingExperience = drivingExperience;
        Education = education;
        Income = income;
        VehicleYear = vehicleYear;
        VehicleType = vehicleType;
        AnnualMileage = annualMileage;
    }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int DrivingExperience { get; set; }
    public string Education { get; set; }
    public string Income { get; set; }
    public int VehicleYear { get; set; }
    public string VehicleType { get; set; }
    public string AnnualMileage { get; set; }

    public string GetAgeGroup(int age)
    {
        if (age < 16)
            return "";
        else if (age < 26)
            return "16-25";
        else if (age < 40)
            return "26-39";
        else if (age < 65)
            return "40-64";
        else
            return "65+";
    }
    public string GetDrivingExperienceGroup(int drivingExperience)
    {
        if (drivingExperience < 0)
            return "";
        else if (drivingExperience < 10)
            return "0-9y";
        else if (drivingExperience < 20)
            return "10-19y";
        else if (drivingExperience < 30)
            return "20-29y";
        else
            return "30y+";
    }
    public string GetVehicleYearGroup(int vehicleYear)
    {
        if (vehicleYear < 15)
            return "before 2015";
        else 
            return "after 2015";
    }
    public string GetAnnualMileageGroup(string annualMileage)
    {
        if (annualMileage == "0")
            return "";
        else 
            return annualMileage;
    }
}