using Marlinator.Data.Yarn;

namespace Marlinator.Business.Yarn
{
    public interface IYarnBo
    {
        List<YarnWeight> GetMarledYarnWeight(List<int> ids);
        List<YarnWeight> GetYarnWeightByMetersPer100g(int metersPer100g);
        IEnumerable<YarnWeight> GetYarnWeights();
    }
}