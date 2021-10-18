using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfluxDB.Client;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Influx.Utilities
{
    class InfluxService : IInfluxService
    {
        private readonly ILogger<InfluxService> _logger;
        private readonly InfluxSettings _settings;

        public InfluxService(
            ILogger<InfluxService> logger,
            IOptions<InfluxSettings> settings)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task Add(List<PointData> points)
        {
            if (_settings == null || _settings.Server == null || _settings.Bucket == null)
                return;

            try
            {
                var client = InfluxDBClientFactory.CreateV1(_settings.Server, _settings.User, _settings.Password.ToCharArray(), _settings.Bucket, "autogen");
                var api = client.GetWriteApiAsync();
                await api.WritePointsAsync(points);
                client.Dispose();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Add points");
            }
        }
    }
}
