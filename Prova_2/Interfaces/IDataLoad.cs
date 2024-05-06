using Prova_2.Model;

namespace Prova_2.Interfaces;
public interface IDataLoad
{
    Task<List<DriverData>> Search();
    Task<List<T>> Load<T>(string url);
}