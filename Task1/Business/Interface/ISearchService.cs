using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Business.Model;

namespace Task1.Business.Interface
{
    public interface ISearchService
    {
        Task <WeatherSearchResponse> SearchWeatherForLocationNr(string location);
    }
}
