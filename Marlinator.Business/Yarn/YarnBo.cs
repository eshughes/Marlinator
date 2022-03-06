using Marlinator.Data.Yarn;

namespace Marlinator.Business.Yarn
{
    public class YarnBo : IYarnBo
    {
        private IYarnWeightDa _yarnWeightDa { get; set; }

        public YarnBo(IYarnWeightDa yarnWeightDa)
        {
            _yarnWeightDa = yarnWeightDa;
        }

        public IEnumerable<YarnWeight> GetYarnWeights()
        {
            return _yarnWeightDa.GetYarnWeights();
        }

        public List<YarnWeight> GetMarledYarnWeight(List<int> ids)
        {
            var metersPer100gEstimates = new List<int>();
            foreach (var id in ids)
            {
                var yarnWeight = GetYarnWeightById(id);
                metersPer100gEstimates.Add((yarnWeight.MinimumMetersPer100g + yarnWeight.MaximumMetersPer100g) / 2);
            }

            var newMetersPer100gEstimate = metersPer100gEstimates.Average() / metersPer100gEstimates.Count();
            return GetYarnWeightByMetersPer100g(Convert.ToInt32(newMetersPer100gEstimate));
        }

        public List<YarnWeight> GetYarnWeightByMetersPer100g(int metersPer100g)
        {
            var yarnWeights = GetYarnWeights();
            var matchingYarnWeights = yarnWeights.Where(x => IsInRange(x, metersPer100g)).ToList();
            return matchingYarnWeights;
        }

        public YarnWeight GetYarnWeightById(int id)
        {
            return GetYarnWeights().Where(x => x.Id == id).First();
        }

        private bool IsInRange(YarnWeight yarnWeight, int metersPer100g)
        {
            return yarnWeight.MinimumMetersPer100g < metersPer100g && yarnWeight.MaximumMetersPer100g > metersPer100g;
        }
    }
}