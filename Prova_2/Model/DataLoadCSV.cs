using CsvHelper;
using Prova_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_2.Model
{
    public class DataLoadCSV : IDataLoad 
    {
        public async Task<List<DriverData>> Search()
        {
            var driverDataList = await Load<DriverData>("https://carinsuranceclaimcsv.blob.core.windows.net/csv/Car_Insurance_Claim.csv");
            return driverDataList;
        }

        public async Task<List<T>> Load<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode(); 

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        return csv.GetRecords<T>().ToList();
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new ArgumentException($"Erro ao carregar o CSV da URL '{url}': {ex.Message}", ex);
                }
            }
        }
    }
}