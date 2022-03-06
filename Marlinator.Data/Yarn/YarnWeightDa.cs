using CsvHelper;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;

namespace Marlinator.Data.Yarn
{
    public class YarnWeightDa : IYarnWeightDa
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private readonly string YARN_WEIGHTS_CACHE_KEY = "YarnWeights";

        public IEnumerable<YarnWeight> GetYarnWeights()
        {
            IEnumerable<YarnWeight> yarnWeights;
            if (!_cache.TryGetValue(YARN_WEIGHTS_CACHE_KEY, out yarnWeights))// Look for cache key.
            {
                using (var reader = new StreamReader("..\\Marlinator.Data\\data\\yarn-weights.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    yarnWeights = csv.GetRecords<YarnWeight>().ToList();
                    _cache.Set(YARN_WEIGHTS_CACHE_KEY, yarnWeights);
                }
            }
            return yarnWeights;
        }
    }
}