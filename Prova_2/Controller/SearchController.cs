using Microsoft.AspNetCore.Mvc;
using Prova_2.Interfaces;
using Prova_2.Model;

namespace Prova_2.Controller;

[ApiController]
[Route("[controller]/[action]")]
public class SearchController : ControllerBase
{
    private readonly IDataLoad _dataLoad;

    private readonly ILogger<SearchController> _logger;

    public SearchController(ILogger<SearchController> logger, IDataLoad DataLoad)
    {
        _logger = logger;
        _dataLoad = DataLoad;
    }

    [HttpGet(Name = "Search Credit_Score")]
    public async Task<IEnumerable<string>> Credit_Score([FromHeader] int age, [FromHeader] string gender, [FromHeader] int drivingExperience, 
                                                        [FromHeader] string education, [FromHeader] string income, [FromHeader] int vehicleYear,
                                                        [FromHeader] string vehicleType, [FromHeader] string annualMileage)
    {
        PeopleData peopleData = new PeopleData(age, gender, drivingExperience, education, income, vehicleYear, vehicleType, annualMileage);
        string ageGroup = peopleData.GetAgeGroup(age);
        string drivingExperienceGroup = peopleData.GetDrivingExperienceGroup(drivingExperience);
        string vehicleYearGroup = peopleData.GetVehicleYearGroup(vehicleYear);
        string annualMileageGroup = peopleData.GetAnnualMileageGroup(annualMileage);

        List<DriverData> driverData = await _dataLoad.Search(); // Aguardando a conclusão da tarefa
        var objDriverData = driverData.Where(d => d.AGE == ageGroup && d.GENDER == gender && d.DRIVING_EXPERIENCE == drivingExperienceGroup 
                                            && d.EDUCATION == education && d.INCOME == income && d.VEHICLE_YEAR == vehicleYearGroup 
                                            && d.VEHICLE_TYPE == vehicleType && d.ANNUAL_MILEAGE == annualMileageGroup);
        var creditScore = objDriverData.Select(d => d.CREDIT_SCORE);
        
        return creditScore; 
    }
}