using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApbd3.Shared.Models;

namespace FinalApbd3.Client.Repository
{
    public interface IPolygonRepository
    {

        public Task<string> takePolygonStr();

        public Task<DataContainer> takeDataForChart(string ticker);

    }
}
