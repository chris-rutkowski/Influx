using System.Collections.Generic;
using System.Threading.Tasks;
using InfluxDB.Client.Writes;

namespace Influx
{
    public interface IInfluxService
    {
        public Task Add(PointData point) => Add(new List<PointData> { point });
        public Task Add(List<PointData> points);
    }
}
