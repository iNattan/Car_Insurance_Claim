using Prova_2.Controller;
using Microsoft.Extensions.Logging;
using Moq;
using Prova_2.Model;
using Prova_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Prova_2_test;

public class SearchControllerTest
{
    [Fact]
    public async Task Test1()
    {
        var dataLoadMock = new Mock<IDataLoad>();
        var loggerMock = new Mock<ILogger<SearchController>>();
            
        List<DriverData> driversDataMoq = [new DriverData{CREDIT_SCORE = "0.54155442", AGE = "16-25", GENDER = "male", DRIVING_EXPERIENCE = "0-9y", EDUCATION = "high school", 
                                                          INCOME = "upper class", VEHICLE_YEAR = "after 2015", VEHICLE_TYPE = "sedan", ANNUAL_MILEAGE = "10000.0"}];

        dataLoadMock.Setup(method => method.Search()).ReturnsAsync(driversDataMoq);

        var controllerMock = new SearchController(loggerMock.Object, dataLoadMock.Object);

        var result = await controllerMock.Credit_Score(18, "male", 9, "high school", "upper class", 2020, "sedan", "10000.0");

        Assert.Single(result);
        Assert.Contains("0.54155442", result);
    }
}